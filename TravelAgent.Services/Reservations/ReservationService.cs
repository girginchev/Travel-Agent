namespace TravelAgent.Services.Reservations
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TravelAgent.Data;
    using TravelAgent.Data.Models;
    using TravelAgent.Services.Reservations.Models;

    public class ReservationService : IReservationService
    {
        private readonly TravelAgentDbContext db;
        private readonly UserManager<IdentityUser> userManager;

        public ReservationService(TravelAgentDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public AddReservationServiceModel BusSeatsByTripId(int id)
        {
            var bus = this.db
                .Buses
                .Where(b => b.TripId == id)
                .Where(b => b.Seats.Any(s => s.IsReserved == false))
                .Select(b => new AddReservationServiceModel
                {
                    TripId = id,
                    BusId = b.Id,
                    SeatId = b.Seats.OrderBy(s => s.Number).Select(s => s.Id).ToList(),
                    SeatNumbers = b.Seats.OrderBy(s => s.Number).Select(s => s.Number).ToList(),
                    IsReserved = b.Seats.OrderBy(s => s.Number).Select(s => s.IsReserved).ToList()
                })
                .FirstOrDefault();

            return bus;
        }

        public int GetFirstFreeSeat(int tripId)
        {
            var busId = db.Buses
                .Where(b => b.TripId == tripId)
                .Where(b => b.Seats.Any(s => s.IsReserved == false))
                .Select(b => b.Id)
                .FirstOrDefault();
            var seatId = db.Seats.Where(s => s.BusId == busId)
                .Where(s => s.IsReserved == false)
                .Select(s => s.Id)
                .FirstOrDefault();
            return seatId;
        }

        public string GetTourName(int id)
        => db.Tours.Where(t => t.Id == this.GetTourIdByTripId(id)).Select(t => t.Title).FirstOrDefault();

        public decimal GetBasePrice(int id)
        => db.Trips.Where(tr => tr.Id == id).Select(tr => tr.Price).FirstOrDefault();

        public List<AddAdditionalServicesModel> AdditionalServicesByTripId(int id)
        {
            var services = this.db.AdditionalServices.Where(ad => ad.TourId == this.GetTourIdByTripId(id))
                .Select(ad => new AddAdditionalServicesModel
                {
                    Id = ad.Id,
                    Content = ad.Content,
                    Price = ad.Price,
                    IsSelected = false
                }).ToList();
            return services;
        }

        public int GetTourIdByTripId(int id)
        => this.db.Trips.Where(tr => tr.Id == id).Select(tr => tr.TourId).FirstOrDefault();

        public async Task CreateReservation(string id, int tripId, string egn, string email,
            string password, string phone, int reservedSeatId,
            List<AddAdditionalServicesModel> selectedServices, decimal totalPrice, string tourTitle,
            string firstNameCyrilic, string surNameCyrilic, string lastNameCyrilic,
            string firstNameLatin, string surNameLatin, string lastNameLatin,
            string pasportNumber, DateTime pasportDateOfIssue, DateTime pasportValidityDate,
            string idCard, DateTime idCardDateOfIssue, DateTime idCardValidityDate, string address, bool gdprConfirm, bool gdprRead)
        {
            var user = new User { UserName = email, Email = email, EGN = egn, PhoneNumber = phone };
            var result = await userManager.CreateAsync(user, password);
            user.Adress = address;
            user.FirstNameCyrilic = firstNameCyrilic;
            user.FirstNameLatin = firstNameLatin;
            user.SurNameCyrilic = surNameCyrilic;
            user.SurNameLatin = surNameLatin;
            user.LastNameCyrilic = lastNameCyrilic;
            user.LastNameLatin = lastNameLatin;
            user.IdCard = idCard;
            user.IdCardDateOfIssue = idCardDateOfIssue;
            user.IdCardValidityDate = idCardValidityDate;
            user.PasportNumber = pasportNumber;
            user.PasportDateOfIssue = pasportDateOfIssue;
            user.PasportValidityDate = pasportValidityDate;

            var services = new List<AdditionalService>();
            foreach (var ss in selectedServices)
            {
                var service = db.AdditionalServices.FirstOrDefault(ads => ads.Id == ss.Id);
                services.Add(service);
            }
            var seat = db.Seats.Where(s => s.Id == reservedSeatId).FirstOrDefault();
            seat.IsReserved = true;
            db.Seats.Update(seat);
            var reservation = new Reservation
            {
                Id = id,
                IsFinalized = false,
                ReservationTime = DateTime.UtcNow,
                SeatId = reservedSeatId,
                TotalPrice = totalPrice,
                TripId = tripId,
                Tourist = user,
                IncludedAdditionalServices = services,
                TourTitle = tourTitle
            };

            if (gdprConfirm != true || gdprRead != true)
            {
                return;
            }
            db.Reservations.Add(reservation);
            db.SaveChanges();
        }

        public DateTime GetStartDate(int id)
        => this.db.Trips.Where(t => t.Id == id).Select(t=>t.StartDate).FirstOrDefault();

        public List<ReservationsListingServiceModel> GetAllReservationsByTripId(int tripId)
        {
            return db.Reservations.Where(r => r.TripId == tripId)
                .Select(r => new ReservationsListingServiceModel
                {
                    Id = r.Id,
                    IsFinalized = r.IsFinalized,
                    ReservationTime = r.ReservationTime,
                    SeatNumber = r.Seat.Number,
                    TourstId = r.Tourist.Id,
                    TouristFirstName = r.Tourist.FirstNameLatin,
                    TouristLastName = r.Tourist.LastNameLatin
                })
                .ToList();
        }

        public List<ReservationsDetailsServiceModel> GetAllReservationsByTripIdFullDetails(int tripId)
        {
            return db.Reservations.Where(r => r.TripId == tripId)
                .Select(r => new ReservationsDetailsServiceModel
                {
                    Id = r.Id,
                    TripId = r.TripId,
                    TripStartDate = r.Trip.StartDate,
                    Email = r.Tourist.Email,
                    Phone = r.Tourist.PhoneNumber,
                    TourTitle = r.TourTitle,
                    ReservationTime = r.ReservationTime,
                    SeatNumber = r.Seat.Number,
                    IsFinalized = r.IsFinalized,
                    Adress = r.Tourist.Adress,
                    EGN = r.Tourist.EGN,
                    FirstNameCyrilic = r.Tourist.FirstNameCyrilic,
                    FirstNameLatin = r.Tourist.FirstNameLatin,
                    SurNameCyrilic = r.Tourist.SurNameCyrilic,
                    SurNameLatin = r.Tourist.SurNameLatin,
                    LastNameCyrilic = r.Tourist.LastNameCyrilic,
                    LastNameLatin = r.Tourist.LastNameLatin,
                    IdCard = r.Tourist.IdCard,
                    IdCardDateOfIssue = r.Tourist.IdCardDateOfIssue,
                    IdCardValidityDate = r.Tourist.IdCardValidityDate,
                    PasportNumber = r.Tourist.PasportNumber,
                    PasportDateOfIssue = r.Tourist.PasportDateOfIssue,
                    PasportValidityDate = r.Tourist.PasportValidityDate,
                    IncludedAdditionalServices = r.IncludedAdditionalServices.Select(ads => new AddAdditionalServicesModel
                    {
                        //Id = ads.AdditionalService.Id,
                        //Content = ads.AdditionalService.Content,
                        //Price = ads.AdditionalService.Price
                                             Id = ads.Id,
                        Content = ads.Content,
                        Price = ads.Price
                    }).ToList(),
                    TotalPrice = r.TotalPrice,
                })
                .ToList();
        }

        public ReservationsDetailsServiceModel GetReservationDetailsByTripId(string resId)
        {
            var reservation = this.db.Reservations.Where(r => r.Id == resId)
                .Select(r => new ReservationsDetailsServiceModel
                {
                    Id = r.Id,
                    TripId = r.TripId,
                     TripStartDate = r.Trip.StartDate,
                      Email = r.Tourist.Email,
                       Phone = r.Tourist.PhoneNumber,
                    TourTitle = r.TourTitle,
                    ReservationTime = r.ReservationTime,
                     SeatNumber = r.Seat.Number,
                    IsFinalized = r.IsFinalized,
                    Adress = r.Tourist.Adress,
                    EGN = r.Tourist.EGN,
                    FirstNameCyrilic = r.Tourist.FirstNameCyrilic,
                    FirstNameLatin = r.Tourist.FirstNameLatin,
                    SurNameCyrilic = r.Tourist.SurNameCyrilic,
                    SurNameLatin = r.Tourist.SurNameLatin,
                    LastNameCyrilic = r.Tourist.LastNameCyrilic,
                    LastNameLatin = r.Tourist.LastNameLatin,
                    IdCard = r.Tourist.IdCard,
                    IdCardDateOfIssue = r.Tourist.IdCardDateOfIssue,
                    IdCardValidityDate = r.Tourist.IdCardValidityDate,
                    PasportNumber = r.Tourist.PasportNumber,
                    PasportDateOfIssue = r.Tourist.PasportDateOfIssue,
                    PasportValidityDate = r.Tourist.PasportValidityDate,
                    IncludedAdditionalServices = r.IncludedAdditionalServices.Select(ads => new AddAdditionalServicesModel
                    {
                        Id = ads.Id,
                        Content = ads.Content,
                        Price = ads.Price
                    }).ToList(),
                    TotalPrice = r.TotalPrice
                }).FirstOrDefault();

            return reservation;
        }

        public bool ConfirmReservation(bool IsFinalized, string id)
        {
            if (IsFinalized == true)
            {
                var reservation = this.db.Reservations.Where(r => r.Id == id)
                    .FirstOrDefault();
                reservation.IsFinalized = true;
                db.Reservations.Update(reservation);
                db.SaveChanges();
                return true;
            }
            else
            {
                var reservation = this.db.Reservations.Where(r => r.Id == id)
                    .FirstOrDefault();
                reservation.IsFinalized = true;
                db.Reservations.Update(reservation);
                db.SaveChanges();
                return false;
            }
        }

        public string GetEmailByReservationId(string id)
        {
            return this.db.Reservations.Where(r => r.Id == id).Select(r=>r.Tourist.Email).FirstOrDefault();
        }

        public ReservationShortDetailsServiceModel FindReservation(string reservationId)
        {
            var res = db.Reservations.Where(r => r.Id == reservationId).Select(r => new ReservationShortDetailsServiceModel
            {
                FirstNameLatin = r.Tourist.FirstNameLatin,
                LastNameLatin = r.Tourist.LastNameLatin,
                TourTitle = r.TourTitle,
                TotalPrice = r.TotalPrice,
                IsFinalized = r.IsFinalized,
                SeatNumber = r.SeatId,
                TripStartDate = r.Trip.StartDate,
                IncludedAdditionalServices = r.IncludedAdditionalServices.Select(a => new AddAdditionalServicesModel
                {
                    Content = a.Content,
                    Price = a.Price
                } ).ToList()
            }).FirstOrDefault();

            var services = db.Reservations.Where(r => r.Id == reservationId).Select(r => r.IncludedAdditionalServices).ToList();

            return res;
        }
    }
}

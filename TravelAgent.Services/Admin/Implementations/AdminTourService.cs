namespace TravelAgent.Services.Admin.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TravelAgent.Data;
    using TravelAgent.Data.Models;
    using TravelAgent.Data.Models.Enums;
    using TravelAgent.Services.Reservations.Models;
    using TravelAgent.Services.Tours.Models;

    public class AdminTourService : IAdminTourService
    {
        private readonly TravelAgentDbContext db;

        public AdminTourService(TravelAgentDbContext db)
        {
            this.db = db;
        }
        

        public void Create(string title, byte[] headPicture, 
            List<byte[]> tourDayPictures,List<string> tourDayTitles, List<string> tourDayDescriptions, 
            DateTime startDate, DateTime endDate, decimal price, int busSeatsNumber, 
            int nights, string startingPoint, string destination, string destinationType, string description, string usefulInformation, 
            List<string> priceIncludes, List<string> priceDoesNotIncludes, 
            List<string> additionalServicesContents, List<decimal> additionalServicesPrices)
        {
            var days = new List<Day>();
            var additionalServices = new List<AdditionalService>();

            var trip = this.CreateTrip(startDate, endDate, price, busSeatsNumber);

            for (int i = 0; i < tourDayDescriptions.Count; i++)
            {
                var day = new Day
                {
                    DayTitle = tourDayTitles[i],
                    DayDescription = tourDayDescriptions[i],
                    DayPicture = tourDayPictures[i]
                };
                days.Add(day);
            }

            for (int i = 0; i < additionalServicesContents.Count; i++)
            {
                var additionalService = new AdditionalService
                {
                    Content = additionalServicesContents[i],
                    Price = additionalServicesPrices[i]
                };
                additionalServices.Add(additionalService);
            }


            var tour = new Tour
            {
                Title = title,
                HeaderImage = headPicture,
                TourDays = days,
                StartingPoint = startingPoint,
                Destination = destination,
                 DestinationType = (DestinationType)Enum.Parse(typeof(DestinationType),destinationType),
                Description = description,
                AdditionalServices = additionalServices,
                PriceIncludes = string.Join(Environment.NewLine, priceIncludes),
                PriceDoesNotIncludes = string.Join(Environment.NewLine, priceDoesNotIncludes),
                UsefulInformation = usefulInformation,
                 Nights = nights
            };
            tour.Trips.Add(trip);

            this.db.Tours.Add(tour);

            this.db.SaveChanges();
        }

        public void AddTrip(int tourId, DateTime startDate, DateTime endDate, decimal price, int busSeatsNumber)
        {
            var trip = this.CreateTrip(startDate, endDate, price, busSeatsNumber);
            var tour = this.db.Tours.Where(t => t.Id == tourId).FirstOrDefault();
            if (tour == null)
            {
                return;
            }
            tour.Trips.Add(trip);
            db.SaveChanges();

        }

        public Trip CreateTrip(DateTime startDate, DateTime endDate, decimal price, int busSeatsNumber)
        {
            var busSeats = new List<Seat>();
      
            while (busSeatsNumber % 4 != 0)
            {
                busSeatsNumber++;
            }
            for (int i = 1; i <= busSeatsNumber; i++)
            {
                var busSeat = new Seat
                {
                    Number = i,
                    IsReserved = false,
                };
                busSeats.Add(busSeat);
            }

            var bus = new Bus()
            {
                Seats = busSeats,
            };

            var trip = new Trip()
            {
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
            };
            trip.Buses.Add(bus);

            return trip;
        }

        public TourDetailsServiceModel ById(int id)
        {
            var tour = this.db
                .Tours
                .Where(t => t.Id == id)
                .Select(t => new TourDetailsServiceModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    HeaderImage = t.HeaderImage,
                    StartingPoint = t.StartingPoint,
                    Destination = t.Destination,
                    Description = t.Description,
                    PriceIncludes = t.PriceIncludes,
                    PriceDoesNotIncludes = t.PriceDoesNotIncludes,
                    UsefulInformation = t.UsefulInformation,
                    Nights = t.Nights,
                    Trips = t.Trips.Select(td => new TripServiceModel
                    {
                        Id = td.Id,
                        StartDate = td.StartDate,
                        EndDate = td.EndDate,
                        Price = td.Price,
                        Buses = td.Buses.Select(b => new BusServiceModel
                        {
                            Id = b.Id,
                            Seats = b.Seats.Select(s => new SeatServiceModel
                            {
                                Id = s.Id,
                                Number = s.Number,
                                IsReserved = s.IsReserved
                            }).ToList(),
                        }).ToList(),
                    }).ToList(),
                    TourDays = t.TourDays.Select(td => new TourDayDatailsServiceModel
                    {
                        Id = td.Id,
                        DayDescription = td.DayDescription,
                        DayPicture = td.DayPicture,
                        DayTitle = td.DayTitle,
                    }).ToList(),
                    AdditionalSevices = t.AdditionalServices.Select(ads => new TourAdditionalServicesServiceModel
                    {
                        Id = ads.Id,
                        Content = ads.Content,
                        Price = ads.Price,
                    }).ToList(),
                })
                .FirstOrDefault();

            return tour;
        }

        public bool EditHeader(int id, byte[] headPicture, string title)
        {
            var tour = this.db.Tours.Where(t => t.Id == id).FirstOrDefault();
            if (tour == null)
            {
                return false;
            }
            if (title != null)
            {
                tour.Title = title;
            }
            if (headPicture != null)
            {
            tour.HeaderImage = headPicture;
            }
            db.SaveChanges();
            return true;
        }

        public bool EditТourDay(int id, int tourDayId, byte[] dayPicture, string dayTitle, string dayDescription)
        {
            var tour = this.db.Tours.Include(t=>t.TourDays).Where(t => t.Id == id).FirstOrDefault();
            var index = tourDayId - 1;
            if (tour == null)
            {
                return false;
            }
            if (dayTitle != null)
            {
                tour.TourDays[index].DayTitle = dayTitle;
            }
            if (dayDescription != null)
            {
                tour.TourDays[index].DayDescription = dayDescription;
            }
            if (dayPicture != null)
            {
                tour.TourDays[index].DayPicture = dayPicture;
            }
            db.SaveChanges();
            return true;
        }

        public bool EditAdditionalService(int id, int sericeId, string content, decimal price)
        {
            var tour = this.db.Tours.Include(t => t.AdditionalServices).Where(t => t.Id == id).FirstOrDefault();
            var index = sericeId - 1;
            if (tour == null)
            {
                return false;
            }
            if (content != null)
            {
                tour.AdditionalServices[index].Content = content;
            }
            if (price >= 0)
            {
                tour.AdditionalServices[index].Price = price;
            }
            db.SaveChanges();
            return true;
        }

        public void AddAdditionalService(int tourId, string content, decimal price)
        {
            var additionalService = new AdditionalService
            {
                Content = content,
                Price = price
            };
            var tour = this.db.Tours.Where(t => t.Id == tourId).FirstOrDefault();
            if (tour == null)
            {
                return;
            }
            tour.AdditionalServices.Add(additionalService);
            db.SaveChanges();
        }

        public bool DeleteService(int id, int serviceId)
        {
            var service = db.AdditionalServices.FirstOrDefault(s => s.Id == serviceId);
            if (service == null)
            {
                return false;
            }

            db.AdditionalServices.Remove(service);
            db.SaveChanges();
            return true;
        }

        public bool EditUsefulInformation(int id, string content)
        {
            var tour = this.db.Tours.Where(t => t.Id == id).FirstOrDefault();
            if (tour == null)
            {
                return false;
            }
            if (content != null)
            {
                tour.UsefulInformation = content;
            }
            db.SaveChanges();
            return true;
        }

        public bool EditPriceIncludes(int id, string content)
        {
            var tour = this.db.Tours.Where(t => t.Id == id).FirstOrDefault();
            if (tour == null)
            {
                return false;
            }
            if (content != null)
            {
                tour.PriceIncludes = content;
            }
            db.SaveChanges();
            return true;
        }

        public bool EditPricePriceDoesNotIncludes(int id, string content)
        {
            var tour = this.db.Tours.Where(t => t.Id == id).FirstOrDefault();
            if (tour == null)
            {
                return false;
            }
            if (content != null)
            {
                tour.PriceDoesNotIncludes = content;
            }
            db.SaveChanges();
            return true;
        }

        public bool EditTrip(int id, DateTime startDate, DateTime endDate, decimal price)
        {
            var trip = this.db.Trips.FirstOrDefault(t => t.Id == id);
            if (trip == null)
            {
                return false;
            }
            if (startDate != null && endDate != null && price >= 0)
            {
                trip.StartDate = startDate;
                trip.EndDate = endDate;
                trip.Price = price;
            }
            db.SaveChanges();
            return true;
        }

        public bool DeleteTrip(int id, int tripId)
        {
            var trip = this.db.Trips.FirstOrDefault(t=>t.Id == tripId);
            if (trip == null)
            {
                return false;
            }
            db.Trips.Remove(trip);
            db.SaveChanges();
            return true;
        }

        public BusSeatsListingServiceModel BusSeatsByTripId(int id)
        {
            var bus = this.db
                .Buses
                .Where(b => b.TripId == id)
                .Where(b => b.Seats.Any(s => s.IsReserved == false))
                .Select(b => new BusSeatsListingServiceModel
                {
                    TripId = id,
                    BusId = b.Id,
                    SeatId = b.Seats.OrderBy(s => s.Number).Select(s => s.Id).ToList(),
                    SeatNumbers = b.Seats.OrderBy(s => s.Number).Select(s => s.Number).ToList(),
                     IsReserved = b.Seats.OrderBy(s=>s.Number).Select(s=>s.IsReserved).ToList()
                })
                .FirstOrDefault();

            return bus;
        }

        public void SetSeatAvailability(List<int> seatId, List<bool> isReserved, List<int> seatNumbers, int busId, int tripId)
        {
            var seats = new List<Seat>();
            for (int i = 0; i < seatId.Count; i++)
            {
                var seat = new Seat
                {
                    BusId = busId,
                    Id = seatId[i],
                    IsReserved = isReserved[i],
                    Number = seatNumbers[i]
                };
                seats.Add(seat);
            }
            this.db.Seats.UpdateRange(seats);
            this.db.SaveChanges();
        }


        public List<AddAdditionalServicesModel> AddititionalServicesByTripId(int id)
        {
            var tourId = db.Trips.Where(tr => tr.Id == id).Select(tr => tr.TourId).FirstOrDefault();
            var basePrice = db.Trips.Where(t => t.Id == id).Select(tr => tr.Price).FirstOrDefault();
            var additionalServices = db.AdditionalServices
                .Where(ad => ad.TourId == id)
                .Select(ad => new AddAdditionalServicesModel
                {
                    Content = ad.Content,
                    Price = ad.Price,
                    IsSelected = false
                }).ToList();
            return additionalServices;
        }

        public void ChangeDestinationType(int tourId, TourDestinationTypesServiceModel type)
        {
            var tour = db.Tours.Where(t => t.Id == tourId).FirstOrDefault();
            tour.DestinationType = (DestinationType)type;
            db.SaveChanges();
        }
    }
}

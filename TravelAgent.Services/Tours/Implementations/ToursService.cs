namespace TravelAgent.Services.Tours.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TravelAgent.Data;
    using TravelAgent.Services.Tours.Models;
    using Microsoft.EntityFrameworkCore;

    public class ToursService : IToursService
    {
        private readonly TravelAgentDbContext db;

        public ToursService(TravelAgentDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ToursListingServiceModel> All(int page = 1)
                => this.db
                .Tours
                .Include(t=>t.Trips)
                .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                .Skip((page - 1) * ServiceConstants.ToursPageSize)
                .Take(ServiceConstants.ToursPageSize)
                .Select(t => new ToursListingServiceModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    HeaderImage = t.HeaderImage,
                    Destination = t.Destination,
                    LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                    TourDaysCount = t.TourDays.Count(),
                })
                .ToList();

        public IEnumerable<ToursListingServiceModel> Bulgaria(int page = 1)
            => this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr=>tr.DestinationType == Data.Models.Enums.DestinationType.Bulgaria)
                    .Skip((page - 1) * ServiceConstants.ToursPageSize)
                    .Take(ServiceConstants.ToursPageSize)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();

        public IEnumerable<ToursListingServiceModel> Abroad(int page = 1)
            => this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType != Data.Models.Enums.DestinationType.Bulgaria)
                    .Skip((page - 1) * ServiceConstants.ToursPageSize)
                    .Take(ServiceConstants.ToursPageSize)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();

        public IEnumerable<ToursListingServiceModel> ByMonth(int month, int page)
            => this.db
                .Tours
                .Include(t => t.Trips)
                .Where(t => t.Trips.Any(tr => tr.StartDate.Month== month && tr.StartDate >= DateTime.UtcNow))
                .Skip((page - 1) * ServiceConstants.ToursPageSize)
                .Take(ServiceConstants.ToursPageSize)
                .Select(t => new ToursListingServiceModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    HeaderImage = t.HeaderImage,
                    Destination = t.Destination,
                    LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                    TourDaysCount = t.TourDays.Count(),
                })
                .ToList();

        public IEnumerable<ToursListingServiceModel> BySearchTerm(string searchTerm, int page)
          => this.db
                .Tours
                .Include(t => t.Trips)
                .Where(t => t.Trips.Any(tr=>tr.StartDate >= DateTime.UtcNow))
                .Where(t=>t.Title.Contains(searchTerm) || t.Description.Contains(searchTerm) || t.TourDays.Any(td=>td.DayDescription.Contains(searchTerm)))
                .Skip((page - 1) * ServiceConstants.ToursPageSize)
                .Take(ServiceConstants.ToursPageSize)
                .Select(t => new ToursListingServiceModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    HeaderImage = t.HeaderImage,
                    Destination = t.Destination,
                    LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                    TourDaysCount = t.TourDays.Count(),
                })
                .ToList();

        public IEnumerable<ToursListingServiceModel> ByPriceRange(decimal priceFrom, decimal priceTo, int page)
          => this.db
                .Tours
                .Include(t => t.Trips)
                .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow && tr.Price >= priceFrom && tr.Price <= priceTo))
                .Skip((page - 1) * ServiceConstants.ToursPageSize)
                .Take(ServiceConstants.ToursPageSize)
                .Select(t => new ToursListingServiceModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    HeaderImage = t.HeaderImage,
                    Destination = t.Destination,
                    LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                    TourDaysCount = t.TourDays.Count(),
                })
                .ToList();


        public int Total()
            => this.db.Tours
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Count();

        public int TotalBulgaria()
           => this.db.Tours
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
            .Where(t=>t.DestinationType == Data.Models.Enums.DestinationType.Bulgaria)
            .Count();

        public int TotalAbroad()
             => this.db.Tours
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
            .Where(t=>t.DestinationType != Data.Models.Enums.DestinationType.Bulgaria)
            .Count();

        public int TotalForMonth(int month)
            => this.db.Tours
                    .Where(t => t.Trips.Any(tr => tr.StartDate.Month == month && tr.StartDate >= DateTime.UtcNow))
                    .Count();

        public int TotalBySearchTerm(string searchTerm)
            => this.db.Tours
                    .Where(t => t.Trips.Any(tr=>tr.StartDate >= DateTime.UtcNow))
                    .Where(t => t.Title.Contains(searchTerm) || t.Description.Contains(searchTerm) || t.TourDays.Any(td => td.DayDescription.Contains(searchTerm)))
                    .Count();

        public int TotalByPriceRange(decimal priceFrom, decimal priceTo)
               => this.db.Tours
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow && tr.Price >= priceFrom && tr.Price <=priceTo))
                    .Count();


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
                    Duration = this.GetTourDurationDays(id),
                     DestinationType = (TourDestinationTypesServiceModel)Enum.Parse(typeof(TourDestinationTypesServiceModel), t.DestinationType.ToString()),
                    Trips = t.Trips.Select(td => new TripServiceModel
                    {
                        Id = td.Id,
                        StartDate = td.StartDate,
                        EndDate = td.EndDate,
                         Price = td.Price,
                        Buses = td.Buses.Select(b => new BusServiceModel
                        {
                              Id = b.Id,
                               Seats = b.Seats.Select(s=> new SeatServiceModel
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

        public int GetTourDurationDays(int tourId)
           => (int)this.db.Trips
           .Where(t => t.TourId == tourId)
           .Select(t => (t.EndDate - t.StartDate).TotalDays)
           .FirstOrDefault();

        public IEnumerable<ToursListingServiceModel> TopTours()
        {
            var tours = new List<ToursListingServiceModel>();
            var bulgarianTours = this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType == Data.Models.Enums.DestinationType.Bulgaria)
                    .Take(4)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();
            tours.AddRange(bulgarianTours);

            var abroadTours = this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType != Data.Models.Enums.DestinationType.Bulgaria)
                    .Take(4)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();
            tours.AddRange(abroadTours);
            return tours;
        }

        public IEnumerable<ToursListingServiceModel> TopAlbania()
        => this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType == Data.Models.Enums.DestinationType.Albania)
                    .Take(2)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();

        public IEnumerable<ToursListingServiceModel> TopBulgaria()
        => this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType == Data.Models.Enums.DestinationType.Bulgaria)
                    .Take(2)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();

        public IEnumerable<ToursListingServiceModel> TopCroatia()
        => this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType == Data.Models.Enums.DestinationType.Croatia)
                    .Take(2)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();

        public IEnumerable<ToursListingServiceModel> TopGreece()
        => this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType == Data.Models.Enums.DestinationType.Greece)
                    .Take(2)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();

        public IEnumerable<ToursListingServiceModel> TopMacedonia()
                => this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType == Data.Models.Enums.DestinationType.Macedonia)
                    .Take(2)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();

        public IEnumerable<ToursListingServiceModel> TopRomania()
                => this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType == Data.Models.Enums.DestinationType.Romania)
                    .Take(2)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();

        public IEnumerable<ToursListingServiceModel> TopAustria()
                => this.db
                    .Tours
                    .Include(t => t.Trips)
                    .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
                    .Where(tr => tr.DestinationType == Data.Models.Enums.DestinationType.Austria)
                    .Take(2)
                    .Select(t => new ToursListingServiceModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        HeaderImage = t.HeaderImage,
                        Destination = t.Destination,
                        LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                        TourDaysCount = t.TourDays.Count(),
                    })
                    .ToList();

        public IEnumerable<ToursListingServiceModel> TopSerbia()
        => this.db
            .Tours
            .Include(t => t.Trips)
            .Where(t => t.Trips.Any(tr => tr.StartDate >= DateTime.UtcNow))
            .Where(tr => tr.DestinationType == Data.Models.Enums.DestinationType.Serbia)
            .Take(2)
            .Select(t => new ToursListingServiceModel
            {
                Id = t.Id,
                Title = t.Title,
                HeaderImage = t.HeaderImage,
                Destination = t.Destination,
                LowestPrice = t.Trips.OrderBy(tr => tr.Price).Select(tr => tr.Price).First(),
                TourDaysCount = t.TourDays.Count(),
            })
            .ToList();
    }
}

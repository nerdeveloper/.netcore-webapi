using System;
using System.Collections.Generic;
using kevinWebAPI.Models;

namespace kevinWebAPI
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set;  }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id  = 1,
                    Name = "New york city",
                    Description = "the one with the finest",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()

                        {
                      Id  = 1,
                    Name = "New york city",
                    Description = "the one with the finest",
                        },
                        new PointOfInterest()

                        {
                      Id  = 2,
                    Name = "New york city",
                    Description = "the one with the finest",
                        },
                        new PointOfInterest()

                        {
                      Id  = 3,
                    Name = "New york city",
                    Description = "the one with the finest",
                        }
                    }
                },
                new CityDto()
                {
                    Id  = 2,
                    Name = "Atlanta",
                    Description = "World largest Market"
                },
                new CityDto()
                {
                    Id  = 3,
                    Name = "Alabama",
                    Description = "Most beautiful"
                }
            };
        }
    }
}

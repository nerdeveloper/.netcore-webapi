using System;
using System.Collections.Generic;
using kevinWebAPI.Models;

namespace kevinWebAPI
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityInfo> Cities { get; set;  }

        public CitiesDataStore()
        {
            Cities = new List<CityInfo>()
            {
                new CityInfo()
                {
                    Id  = 1,
                    Name = "New york city",
                    Description = "the one with the finest",
                    PointOfInterests = new List<PointOfInterest>()
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
                 new CityInfo()
                {
                    Id  = 2,
                    Name = "Atlanta",
                    Description = "World largest Market"
                },
                 new CityInfo()
                {
                    Id  = 3,
                    Name = "Alabama",
                    Description = "Most beautiful"
                }
            };
        }
    }
}

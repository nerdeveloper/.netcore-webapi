using System;
using System.Collections.Generic;
using System.Linq;
using kevinWebAPI.Entities;

namespace kevinWebAPI
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context )
        {
            if (context.Cities.Any())
            {
                return;
            }
          var  cities = new List<City>()
            {
                new City
                {
   
                    Name = "New york city",
                    Description = "the one with the finest",
                    PointsOfInterest = new List<PointOfInterest>()

                    {
                        new PointOfInterest()

                        {
           
                    Name = "New york city",
                    Description = "the one with the finest",
                        },
                        new PointOfInterest()

                        {
        
                    Name = "New york city",
                    Description = "the one with the finest",
                        },
                        new PointOfInterest()

                        {
             
                    Name = "New york city",
                    Description = "the one with the finest",
                        }
                    }
                },
                new City()
                {
              
                    Name = "Atlanta",
                    Description = "World largest Market"
                },
                 new City()
                {
                
                    Name = "Alabama",
                    Description = "Most beautiful"
                }
            };
            context.Cities.AddRange(cities);
            context.SaveChanges() ; 
        }
    }
}

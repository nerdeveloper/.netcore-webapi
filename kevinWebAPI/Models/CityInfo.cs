using System;
using System.Collections.Generic;

namespace kevinWebAPI.Models
{
    public class CityInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointInterest { get 
            {
                return PointOfInterests.Count;

            }           
        }
        public ICollection<PointOfInterest> PointOfInterests { get; set; } = new List<PointOfInterest>();
    }
}

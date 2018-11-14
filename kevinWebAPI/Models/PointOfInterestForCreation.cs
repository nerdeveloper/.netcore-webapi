using System;
using System.ComponentModel.DataAnnotations;

namespace kevinWebAPI.Models
{
    public class PointOfInterestForCreation
    {
        [Required(ErrorMessage= "You should provide a name value")]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}

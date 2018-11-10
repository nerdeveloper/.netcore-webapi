using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace kevinWebAPI.Contollers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities()

        {
            return Ok(CitiesDataStore.Current.Cities);
        }
        [HttpGet("{id}")]
        public IActionResult GetACity(int id)
        {
            var cityReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if(cityReturn == null)
            {
                return NotFound();
            }
            return Ok(cityReturn);
          //  return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
        }
    }
}

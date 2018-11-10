using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace kevinWebAPI.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointofinterests")]
        public IActionResult GetPointOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();


            }
            return Ok(city.PointOfInterests);
        }
        [HttpGet("{cityId}/pointofinterests/{id}")]
        public IActionResult GetEachPointOfInterest(int cityId, int id)
        {
            var PointOI = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (PointOI == null)
            {
                return NotFound();
            }
            var pointOfInterest = PointOI.PointOfInterests.FirstOrDefault(p => p.Id == id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }
    }
}
;
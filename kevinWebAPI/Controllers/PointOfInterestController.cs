using System;
using System.Linq;
using kevinWebAPI.Services;
using kevinWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kevinWebAPI.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {
        private ILogger<PointOfInterestController> _logger;
        private IMailService _mailService;

        public PointOfInterestController(ILogger<PointOfInterestController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{cityId}/pointofinterests", Name = "GetPointOfInterest")]
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
            try
            {

                var PointOI = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                if (PointOI == null)
                {
                    _logger.LogInformation($"City with id {cityId} was not found in the point of interest");
                    return NotFound();
                }
                var pointOfInterest = PointOI.PointOfInterests.FirstOrDefault(p => p.Id == id);
                if (pointOfInterest == null)
                {
                    return NotFound();
                }
                return Ok(pointOfInterest);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception while getting points of interest for the city {cityId}.", ex);
                return StatusCode(500, "A problem while getting data from the server");
            }
        }


        [HttpPost("{cityId}/pointofinterests")]
        public IActionResult CreatePointOfInterest(int cityId,
                 [FromBody] PointOfInterestForCreation pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointOfInterests).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterest()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description

            };
            city.PointOfInterests.Add(finalPointOfInterest);

            return CreatedAtRoute(routeName: "GetPointOfInterest", routeValues: new { cityId = cityId, id = finalPointOfInterest.Id }, value: finalPointOfInterest);
        }


        [HttpPut("{cityId}/pointofinterests/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id,
               [FromBody] PointOfInterestForUpdate pointOfInterests)
        {

            if (pointOfInterests == null)
            {
                return BadRequest();
            }
            if (pointOfInterests.Description == pointOfInterests.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = city.PointOfInterests.FirstOrDefault(p => p.Id == id);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            pointOfInterestFromStore.Name = pointOfInterests.Name;
            pointOfInterestFromStore.Description = pointOfInterests.Description;

            return NoContent();

        }
        [HttpPatch("{cityId}/pointofinterests/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,
                                                            [FromBody] JsonPatchDocument<PointOfInterestForUpdate> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            if (CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id) == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id).PointOfInterests.FirstOrDefault(c => c.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }
            var pointOfInterestoPatch = new PointOfInterestForUpdate()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description
            };
            patchDoc.ApplyTo(pointOfInterestoPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            if (pointOfInterestoPatch.Description == pointOfInterestoPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name.");
            }

            TryValidateModel(pointOfInterestoPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pointOfInterestFromStore.Name = pointOfInterestoPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestoPatch.Description;

            return NoContent();
        }

        [HttpDelete("{cityId}/pointofinterests/{id}")]
        public IActionResult DeletePointOfInterest (int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if(city == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = city.PointOfInterests.FirstOrDefault(f => f.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }
            city.PointOfInterests.Remove(pointOfInterestFromStore);
            _mailService.Send("Point of interest deleted.",
                   $"Point of interest {pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was deleted.");

            return NoContent();

        }
    }
}

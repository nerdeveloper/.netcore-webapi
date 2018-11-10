using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace kevinWebAPI.Contollers
{
    public class CitiesController : Controller
    {
        public JsonResult GetCities()

        {
            return new JsonResult(new List<object>()
            {
                new { id=1, Name="New york"},
                new {id = 2, Name="Nigeria"}
            });
        }
    }
}

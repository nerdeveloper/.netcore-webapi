using System;
using kevinWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kevinWebAPI.Controllers
{
    public class DummyController: Controller
    {
        private CityInfoContext _ctx;

        public DummyController (CityInfoContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/database")]

        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}

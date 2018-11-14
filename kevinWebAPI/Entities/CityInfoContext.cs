﻿using System;
using Microsoft.EntityFrameworkCore;

namespace kevinWebAPI.Entities
{
    public class CityInfoContext: DbContext
    {
       
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }
    }
}

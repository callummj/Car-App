using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Car_App.Models;

namespace Car_App.Data
{
    public class Car_AppContext : DbContext
    {
        public Car_AppContext (DbContextOptions<Car_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Car_App.Models.Car> Car { get; set; }
    }
}

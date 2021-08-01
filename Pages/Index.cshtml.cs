using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car_App.Data;
using Car_App.Models;

namespace Car_App.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Car_App.Data.Car_AppContext _context;

        public string engineSort { get; set; }
        public string makeSort { get; set; }
        public string modelSort { get; set; }
        public string colourSort { get; set; }

        public IndexModel(Car_App.Data.Car_AppContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {

            // Sorting vars
            engineSort = engineSort = sortOrder == "engine" ? "engineDesc" : "engine";
            makeSort = String.IsNullOrEmpty(sortOrder) ? "make" : "";
            modelSort = String.IsNullOrEmpty(sortOrder) ? "model" : "";
            colourSort = String.IsNullOrEmpty(sortOrder) ? "colour" : "";

            IQueryable<Car> cars = from c in _context.Car
                                             select c;


            switch(sortOrder)
            {
                
                case "engine":
                    cars = cars.OrderBy(s => s.engineSize).Reverse();
                    break;
                case "engineDesc":
                    cars = cars.OrderBy(s => s.engineSize);
                    break;

                case "make":
                    cars = cars.OrderBy(s => s.Make);
                    break;
                case "model":
                    cars = cars.OrderBy(s => s.Model);
                    break;
                case "colour":
                    cars = cars.OrderBy(s => s.Colour);
                    break;
                default:
                    cars = cars.OrderBy(s => s.Make);
                    break;
                }

           
            Car = await cars.AsNoTracking().ToListAsync();

        }
    }
}

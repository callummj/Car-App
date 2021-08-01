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

        public IndexModel(Car_App.Data.Car_AppContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }
    }
}

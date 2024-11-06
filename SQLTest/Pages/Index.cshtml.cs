using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLTest.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public IndexModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> Employees { get; set; } // Ensure this property exists

        public async Task OnGetAsync()
        {
            Employees = await _dbContext.Employees.ToListAsync(); // Populate the Employees list
        }

        public IActionResult OnPostDisplayEmployees()
        {
            return RedirectToPage("DisplayEmployees");
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLTest.Data;

namespace SQLTest.Pages
{
    public class DisplayEmployeesModel : PageModel
    {
        private readonly AppDbContext _context;
	    
        public DisplayEmployeesModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Employee> Employees { get; set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.ToListAsync();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLTest.Data;

namespace SQLTest.Pages
{
    public class FindEmployeesModel : PageModel
    {
		private readonly AppDbContext _context;

		public FindEmployeesModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
		public List<Employee> Employees { get; set; }

		public void OnGet()
        {
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Employee.Name))
            {
                return Page();
            }

            Employees = await _context.Employees.Where(e => e.Name.Contains(Employee.Name)).ToListAsync();

            return Page();
        }
    }
}

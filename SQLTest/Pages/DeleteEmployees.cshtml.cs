using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLTest.Data;

namespace SQLTest.Pages
{
    public class DeleteEmployeesModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteEmployeesModel(AppDbContext context)
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
            Employees = new List<Employee>();

            if (!string.IsNullOrWhiteSpace(Employee.Name))
            {
                Employees = await _context.Employees.Where(e => e.Name.Contains(Employee.Name)).ToListAsync();
            }
            else if (!string.IsNullOrWhiteSpace(Employee.Title))
            {
                Employees = await _context.Employees.Where(e => e.Title.Contains(Employee.Title)).ToListAsync();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}

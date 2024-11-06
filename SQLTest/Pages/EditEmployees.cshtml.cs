using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLTest.Data;
using System.Linq.Expressions;

namespace SQLTest.Pages
{
    public class EditEmployeesModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditEmployeesModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await _context.Employees.FindAsync(id);
       
            if(Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingEmployee= await _context.Employees.FindAsync(Employee.Id);
            if(existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = Employee.Name;
            existingEmployee.Title = Employee.Title;

            await _context.SaveChangesAsync();

            return RedirectToPage("/UpdateEmployees");
        }
        
    }
}

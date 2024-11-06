using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLTest.Data;

namespace SQLTest.Pages
{
    public class AddEmployeesModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddEmployeesModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}

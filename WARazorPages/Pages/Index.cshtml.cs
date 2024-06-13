using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WARazorPages.Data;

namespace WARazorPages.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Username == Username && c.Email == Email);

                if (customer != null)
                {
                    // Logic for successful login (e.g., setting a session, redirecting, etc.)
                    return RedirectToPage("/Index");
                }
                else
                {
                    ErrorMessage = "Invalid username or email.";
                }
            }

            return Page();
        }
    }
}

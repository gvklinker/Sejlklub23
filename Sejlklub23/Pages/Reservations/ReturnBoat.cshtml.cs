using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sejlklub23.Pages.Reservations
{
    public class ReturnBoatModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostReturned() 
        {
            
            return RedirectToPage("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Boats
{
    public class CreateBoatModel : PageModel
    {
        private IBoatRepository _boatRepository;
        [BindProperty]
        public Boat Boat {  get; set; }
        public void OnGet()
        {
        }

        public CreateBoatModel(IBoatRepository bRepo)
        {
            _boatRepository = bRepo;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
                return Page();
            _boatRepository.CreateBoat(Boat);
            return RedirectToPage("Index");
        }
    }
}

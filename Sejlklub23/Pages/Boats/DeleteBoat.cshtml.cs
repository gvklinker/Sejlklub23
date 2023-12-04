using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private IBoatRepository _repo;

        //[BindProperty]
        public Boat DeleteBoat { get; set; }


        public DeleteBoatModel(IBoatRepository repo)
        {
            _repo = repo;
        }
        public IActionResult OnGet(int deleteId)
        {
            DeleteBoat = _repo.GetBoat(deleteId);
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _repo.DeleteBoat(id);
            return RedirectToPage("Index");
        }
    }
}

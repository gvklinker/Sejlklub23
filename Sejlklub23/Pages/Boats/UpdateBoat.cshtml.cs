using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Services;
using Sejlklub23.Models;
using Sejlklub23.Interfaces;

namespace Sejlklub23.Pages.Boats
{
    public class UpdateBoatModel : PageModel
    {
        [BindProperty]
        public Boat BoatToUpdate { get; set; }
        private IBoatRepository _BoatRepository;

        public UpdateBoatModel(IBoatRepository boatRepository)
        {
            _BoatRepository = boatRepository;
        }

        public void OnGet(int id)
        {
            BoatToUpdate = _BoatRepository.GetBoat(id);
        }

        public IActionResult OnPostUpdate()
        {
            _BoatRepository.UpdateBoat(BoatToUpdate);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete()
        {
            _BoatRepository.DeleteBoat(BoatToUpdate.Id);
            return RedirectToPage("Index");
        }
    }
}

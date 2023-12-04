using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Reservations
{
    public class DeleteReservationModel : PageModel
    {
        private IReservationRepository _repo;

        //[BindProperty]
        public Reservation DeleteReservation { get; set; }


        public DeleteReservationModel(IReservationRepository repo)
        {
            _repo = repo;
        }
        public IActionResult OnGet(int deleteId)
        {
            DeleteReservation = _repo.GetReservation(deleteId);
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _repo.DeleteReservation(id);
            return RedirectToPage("Index");
        }
    }
}

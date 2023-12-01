using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sejlklub23.Models;
using Sejlklub23.Interfaces;

namespace Sejlklub23.Pages.Reservations
{
    public class CreateReservationModel : PageModel
    {
        private IReservationRepository reservationRepository;
        public SelectList MemberList { get; set; }
        public SelectList BoatList { get; set; }
        [BindProperty]
        public Reservation NewReservation { get; set; }

        public CreateReservationModel(IReservationRepository repo, IMemberRepository mRepo, IBoatRepository bRepo)
        {
            reservationRepository = repo;
            MemberList = new SelectList(mRepo.GetAllMembers(),"Id", "Name");
            BoatList = new SelectList(bRepo.GetAllBoats(), "Id", "Name");
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost() { 
            if(!ModelState.IsValid)
            {
                return Page();
            }
            reservationRepository.CreateReservation(NewReservation);
            return RedirectToPage("Index");
        }    
    }
}

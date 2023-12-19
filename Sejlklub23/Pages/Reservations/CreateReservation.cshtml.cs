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
        private IBoatRepository boatRepository;
        private IMemberRepository memberRepository;
        private Dictionary<int, Member> Members {get; set;}
        private List<Boat> Boats { get; set;}
        public SelectList MemberList { get; set; }
        public SelectList BoatList { get; set; }
        [BindProperty]
        public Reservation NewReservation { get; set; }
        public string ErrorMessage { get; set; }

        public CreateReservationModel(IReservationRepository repo, IMemberRepository mRepo, IBoatRepository bRepo)
        {
            boatRepository = bRepo;
            memberRepository = mRepo;
            Members = memberRepository.GetAllMembers();
            Boats = boatRepository.GetAllBoats();
            reservationRepository = repo;
            MemberList = new SelectList( Members.Values,"Id", "Name");
            BoatList = new SelectList(Boats, "Id", "Name");
        }
        public IActionResult OnGet()
        {
           if (HttpContext.Session.GetString("MemberId") != null)
                return Page();
           return RedirectToPage("/Members/LoginSystem");
        }

        public IActionResult OnPost() { 
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int userId = int.Parse(HttpContext.Session.GetString("MemberId"));
            NewReservation.MemberId = userId;
            try {

                reservationRepository.AcceptableReservation(NewReservation);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
            ErrorMessage = string.Empty;
            reservationRepository.CreateReservation(NewReservation);
            return RedirectToPage("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Reservations
{
    public class UpdateReservationModel : PageModel
    {
        private IReservationRepository _reservationRepository;
        private IBoatRepository boatRepository;
        private IMemberRepository memberRepository;
        private Dictionary<int, Member> Members { get; set; }
        private List<Boat> Boats { get; set; }
        public SelectList MemberList { get; set; }
        public SelectList BoatList { get; set; }
        [BindProperty]
        public Reservation ReservationToUpdate { get; set; }

        public UpdateReservationModel(IReservationRepository repo, IMemberRepository mRepo, IBoatRepository bRepo)
        {
            boatRepository = bRepo;
            memberRepository = mRepo;
            Members = memberRepository.GetAllMembers();
            Boats = boatRepository.GetAllBoats();
            _reservationRepository = repo;
            MemberList = new SelectList(Members.Values, "Id", "Name");
            BoatList = new SelectList(Boats, "Id", "Name");
        }

        public void OnGet(int id)
        {
            ReservationToUpdate = _reservationRepository.GetReservation(id);
        }

        public IActionResult OnPostUpdate()
        {
            _reservationRepository.UpdateReservation(ReservationToUpdate);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete()
        {
            _reservationRepository.DeleteReservation(ReservationToUpdate.Id);
            return RedirectToPage("Index");
        }

        public IActionResult OnGetCancel()
        {
            return RedirectToPage("Index");
        }
    }
}

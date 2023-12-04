using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private IReservationRepository reservationRepository;
        [BindProperty]
        public List<Reservation> Reservations { get; private set; }    
        public IndexModel(IReservationRepository repo)
        {
            reservationRepository = repo;
        }
        public void OnGet()
        {
            Reservations = reservationRepository.GetAllReservations();
        }
    }
}

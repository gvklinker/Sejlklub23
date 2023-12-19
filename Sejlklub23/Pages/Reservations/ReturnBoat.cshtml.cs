using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Models;
using Sejlklub23.Services;
using Sejlklub23.Interfaces;

namespace Sejlklub23.Pages.Reservations
{
    public class ReturnBoatModel : PageModel
    {
        private IReservationRepository _reservationRepository;
        public List<string> Feedback { get; set; }
        public List<string> Problem { get; set; }
        public string Message { get; set; }
        public int NumOfHours { get; set; }
        public int MaxOfHours { get; set; }
        private List<Reservation> _reservs { get; set; }
    [BindProperty]
        public Reservation ReservationToChange { get; set; }

        public ReturnBoatModel(IReservationRepository Repo)
        {
            _reservationRepository = Repo;
        }

        public void OnGet(int returnBoat)
        {
            _reservs = _reservationRepository.GetAllReservations();
            ReservationToChange = _reservationRepository.GetReservation(returnBoat);
            MaxOfHours = 12;
            for (int i = 0; i< _reservs.Count; i++)
            {
                if (_reservs[i].StartOfLocation > ReservationToChange.StartOfLocation.AddHours(ReservationToChange.LocationDuration))
                {
                    double j = (_reservs[i].StartOfLocation - ReservationToChange.StartOfLocation.AddHours(ReservationToChange.LocationDuration)).TotalHours;
                    if (MaxOfHours < j)
                        MaxOfHours = Convert.ToInt32(j);
                }
            }
        }

        public IActionResult OnPostReturned() 
        {
            if (Message != null)
            Feedback.Add(Message);
            ReservationToChange.IsReturned = true;
            _reservationRepository.DeleteReservation(ReservationToChange.Id);
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostProblem()
        {
            if (Message != null)
                Problem.Add(Message);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostCancel()
        {
            if (NumOfHours <= 0 && NumOfHours > MaxOfHours)
                return Page();
            ReservationToChange.LocationDuration += NumOfHours;
            return RedirectToPage("Index");
        }
    }
}

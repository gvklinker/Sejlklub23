using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        private IEventRepository _repo;

        [BindProperty]
        public Event NewEvent { get; set; }
        private CreateEventModel(IEventRepository eventRepository) 
        {
            _repo = eventRepository;
        }


        public IActionResult OnGet()
        {
            if (NewEvent != null)
            {
                _repo.CreateEvent(NewEvent);
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}

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
        public CreateEventModel(IEventRepository eventRepository)
        {
            _repo = eventRepository;
        }
        public void OnGet() { }


        public IActionResult OnPost()
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

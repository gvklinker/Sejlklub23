using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Events
{
    public class AttendEventModel : PageModel
    {
        private IEventRepository _eventRepository;
        [BindProperty]
        public Event TheEvent { get; set; }
        //public List<string> Attendees { get; set; }
        public AttendEventModel(IEventRepository repo)
        {
            _eventRepository = repo;
        }
        public void OnGet(int id)
        {
            
            TheEvent = _eventRepository.GetEvent(id);
        }

        public IActionResult OnPost()
        {

            string attender = HttpContext.Session.GetString("MemberName");
            if (attender != null)
            {
                TheEvent.Attendees.Add(attender);
                _eventRepository.UpdateEvent(TheEvent);
            }

            return RedirectToPage("Index");
        }
    }
}

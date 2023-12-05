using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Events
{
    public class EditEventModel : PageModel
    {
        private IEventRepository _eventRepo;

        [BindProperty]
        public Event EventToUpdate { get; set; }

        public EditEventModel(IEventRepository eventRepository)
        {

            _eventRepo = eventRepository;

        }
        public void OnGet(int id)
        {
            EventToUpdate = _eventRepo.GetEvent(id);
        }

        public IActionResult OnPostUpdate()
        {
            _eventRepo.UpdateEvent(EventToUpdate);
            return RedirectToPage("Index");
        }

    }
}

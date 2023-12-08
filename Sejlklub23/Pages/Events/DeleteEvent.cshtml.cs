using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Events
{
    public class DeleteEventModel : PageModel
    {
        private IEventRepository _repo;

        //[BindProperty]
        public Event DeleteEvent { get; set; }


        public DeleteEventModel(IEventRepository repo)
        {
            _repo = repo;
        }
        public IActionResult OnGet(int id)
        {
            DeleteEvent = _repo.GetEvent(id);
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            DeleteEvent = _repo.GetEvent(id);
            _repo.DeleteEvent(DeleteEvent);
            return RedirectToPage("Index");
        }
    }
}

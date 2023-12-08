using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Events
{
    public class IndexModel : PageModel
    {
        private IEventRepository _repo;
        public List<Event> Events { get; private set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IndexModel(IEventRepository repo)
        {
            _repo = repo;
        }
        public void OnGet()
        {
           
                Events = _repo.GetAllEvents();
           

        }
    }
}

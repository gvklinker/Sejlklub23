using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Models;
using Sejlklub23.Interfaces;

namespace Sejlklub23.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private IBoatRepository _boatRepository;
        public List<Boat> Boats { get; private set; }

        public IndexModel(IBoatRepository bRepo)
        {
            _boatRepository = bRepo;
        }
        public void OnGet()
        {
            Boats = _boatRepository.GetAllBoats();
        }
    }
}

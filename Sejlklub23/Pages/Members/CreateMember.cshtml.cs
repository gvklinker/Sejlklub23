using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Members
{
    public class CreateMemberModel : PageModel
    {
        private IMemberRepository _repo;
        [BindProperty]
        public Member NewMember { get; set; }

        public CreateMemberModel(IMemberRepository repo)
        {
            _repo = repo;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            _repo.CreateMember(NewMember);
            return RedirectToPage("Index");
        }
    }
}

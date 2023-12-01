using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Members
{
    public class DeleteMemberModel : PageModel
    {
        private IMemberRepository _repo;

        //[BindProperty]
        public Member DeleteMember { get; set; }


        public DeleteMemberModel(IMemberRepository repo)
        {
            _repo = repo;
        }
        public IActionResult OnGet(int deleteId)
        {
            DeleteMember = _repo.GetMember(deleteId);
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _repo.DeleteMember(id);
            return RedirectToPage("Index");
        }
    }
}

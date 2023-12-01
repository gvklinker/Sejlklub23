using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Members
{
    public class UpdateMemberModel : PageModel
    {
        [BindProperty]
        public Member MemberToUpdate { get; set; }
        private IMemberRepository _BoatRepository;

        public UpdateMemberModel(IMemberRepository memberRepository)
        {
            _BoatRepository = memberRepository;
        }

        public void OnGet(int id)
        {
            MemberToUpdate = _BoatRepository.GetMember(id);
        }

        public IActionResult OnPostUpdate()
        {
            _BoatRepository.UpdateMember(MemberToUpdate);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete()
        {
            _BoatRepository.DeleteMember(MemberToUpdate.Id);
            return RedirectToPage("Index");
        }
    }
}

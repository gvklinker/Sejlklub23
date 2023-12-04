using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Members
{
    public class IndexModel : PageModel
    {
        private IMemberRepository _memberRepository;
        public Dictionary<int, Member> Members { get; set; }
        public IndexModel(IMemberRepository repo)
        {
            _memberRepository = repo;
        }
        public void OnGet()
        {
            //Members = repo.GetAllMembers();
            Members = _memberRepository.GetAllMembers();
        }
    }
}

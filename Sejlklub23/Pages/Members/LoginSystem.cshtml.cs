using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Pages.Members
{
    public class LoginSystemModel : PageModel
    {
        [BindProperty] public string MemberName { get; set; }
        [BindProperty] public string Password { get; set; }

        public string Message { get; set; }



        private IMemberRepository _memberService;
        public LoginSystemModel(IMemberRepository Memberservice)
        {
            _memberService = Memberservice;
        }

        public void OnGet()
        {
        }
        public void OnGetLogout()
        {
            HttpContext.Session.Remove("MemberName");
        }

        public IActionResult OnPost()
        {
            Member loginMember = _memberService.VerifyMember(MemberName, Password);


            if (loginMember != null)
            {
                HttpContext.Session.SetString("MemberName", loginMember.Name);
                HttpContext.Session.SetString("MemberId", loginMember.Id.ToString());
                return RedirectToPage("/Index");
            }
            else
            {
                Message = "Invalid Membername or password";
                MemberName = "";
                Password = "";
                return Page();
            }
        }
    }
}

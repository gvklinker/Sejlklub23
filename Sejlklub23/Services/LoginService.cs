using Sejlklub23.Models;

namespace LoginSessionTest.Services
{
    public class LogInService
    {
        private Member _loggedInMember;

        public void MemberLogIn(Member member)
        {
            _loggedInMember = member;
        }
        public void MemberLogOut()
        {
            _loggedInMember = null;
        }
        public Member GetLoggedMember()
        {
            return _loggedInMember;
        }
    }
}
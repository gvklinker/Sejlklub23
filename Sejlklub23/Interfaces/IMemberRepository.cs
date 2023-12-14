using Sejlklub23.Models;

namespace Sejlklub23.Interfaces
{
    public interface IMemberRepository
    {
        Dictionary<int ,Member> GetAllMembers();
        Member GetMember(int id);
        //Member GetMemberbByName(string name);
        void CreateMember(Member member);
        void DeleteMember(int id);
        void UpdateMember(Member member);
        public Member VerifyMember(string MemberName, string passWord);
    }
}

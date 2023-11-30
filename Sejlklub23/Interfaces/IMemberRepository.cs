using Sejlklub23.Models;

namespace Sejlklub23.Interfaces
{
    public interface IMemberRepository
    {
        Dictionary<int ,Member> GetAllMembers();
        Member GetMember(int id);
        void CreateMember(Member member);
        void DeleteMember(int id);
        void UpdateMember(Member member);
    }
}

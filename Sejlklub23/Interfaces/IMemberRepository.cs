using Sejlklub23.Models;

namespace Sejlklub23.Interfaces
{
    public interface IMemberRepository
    {
        List<Member> GetAllEvents();
        Event GetMember(int id);
        void CreateMember(Member member);
        void DeleteMember(Member member);
        void UpdateMember(Member member);
    }
}

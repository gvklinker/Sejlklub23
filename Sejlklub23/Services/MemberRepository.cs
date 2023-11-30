using Microsoft.AspNetCore.Mvc;
using Sejlklub23.Helpers;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Services
{
    public class MemberRepository : IMemberRepository
    {
        private Dictionary<int,  Member> _members;
        string jsonFileName = "@Data/Members.json";
        public void CreateMember(Member member)
        {
            if (member != null || !_members.ContainsKey(member.Id))
            {
                _members.Add(member.Id, member);

            }
        }

        public void DeleteMember(int id)
        {
            _members.Remove(id);
        }

        public Member GetMember(int id)
        {
            if (_members.ContainsKey(id))
                return _members[id];
            return null;
        }

        public void UpdateMember(Member member)
        {
            if ( member != null)
            {
                if (_members.ContainsKey(member.Id))
                {
                    _members[member.Id] = member;
                }
            }
        }

        Dictionary< int, Member> IMemberRepository.GetAllMembers()
        {
            _members.Clear();
            List<Member> memberListe = JsonFileReader<Member>.ReadJson(jsonFileName);
            foreach (Member member in memberListe)
            {
                _members.Add((int)member.Id, member);
            }
            return _members;
        }
    }
}

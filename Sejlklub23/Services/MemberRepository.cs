using Microsoft.AspNetCore.Mvc;
using Sejlklub23.Helpers;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Services
{
    public class MemberRepository : IMemberRepository
    {
        //private Dictionary<int,  Member> _members = new Dictionary<int, Member>();
        string jsonFileName = @"Data\Members.json";
        //List<Member> memberListe = new List<Member>();
        public void CreateMember(Member member)
        {
            Dictionary<int, Member> _members = GetAllMembers();
            List<int> ids = new List<int>();
            foreach (var item in _members)
            {
                ids.Add(item.Key);
            }
            if (ids.Count > 0)
                member.Id = ids.Max()+1;
            else
                member.Id = 1;
            if (member != null && !_members.ContainsKey(member.Id))
            {
                _members.Add(member.Id, member);
                JsonFileWriter<Member>.WriteToJson(FromDictonnaryToList(_members), jsonFileName);
            }
        }

        public void DeleteMember(int id)
        {
            Dictionary<int, Member> _members = GetAllMembers();
            if (_members.ContainsKey(id))
            {
                _members.Remove(id);
                JsonFileWriter<Member>.WriteToJson(FromDictonnaryToList(_members), jsonFileName);
            }
        }

        public Member GetMember(int id)
        {
            Dictionary<int, Member> _members = GetAllMembers();
            if (_members.ContainsKey(id))
                return _members[id];
            return null;
        }

        public void UpdateMember(Member member)
        {
            Dictionary<int, Member> _members = GetAllMembers();
            if ( member != null)
            {
                if (_members.ContainsKey(member.Id))
                {
                    _members[member.Id] = member;
                    JsonFileWriter<Member>.WriteToJson(FromDictonnaryToList(_members), jsonFileName);
                }
            }
        }

        public Dictionary< int, Member> GetAllMembers()
        {
             List<Member> memberListe = JsonFileReader<Member>.ReadJson(jsonFileName);
            return FromListToDictionary(memberListe);        
        }

        protected List<Member> FromDictonnaryToList(Dictionary<int, Member> dict)
        {
            List<Member> newList = new List<Member>();
            foreach (var item in dict)
            {
                newList.Add(item.Value);
            }
            return newList;
        }

        private Dictionary<int, Member> FromListToDictionary(List<Member> members)
        {
            Dictionary<int, Member> dict = new Dictionary<int, Member>();
            foreach(Member m in members)
                dict.Add(m.Id, m);            
            return dict;
        }

        public Member VerifyMember(string memberName, string passWord)
        {
            Dictionary<int, Member> _members = GetAllMembers();

            for (int i = 0; i < _members.Count; i++)
            {
                if (_members.ElementAt(i).Value.Name == memberName)
                {
                    if (passWord == _members.ElementAt(i).Value.Password)
                    {
                        return _members.ElementAt(i).Value;
                    }
                }
            }
            return null;
        }
    }
}

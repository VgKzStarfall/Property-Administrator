using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace DataAccess.Repos
{
    public class MemberRepository : IMember
    {
        public void DeleteMember(int memberId) => MemberDAO.Instance.DeleteById(memberId);


        public Member GetMemberByID(int memberId) => MemberDAO.Instance.GetById(memberId);


        public IEnumerable<Member> GetMember() => MemberDAO.Instance.GetList();


        public void InsertMember(Member member) => MemberDAO.Instance.Add(member);  


        public void UpdateMember(Member member) => MemberDAO.Instance.Update(member);

        public List<Member> GetListSearchByName(string name) => MemberDAO.Instance.GetListSearchByName(name);
      
        public List<Member> GetListSearchByCity(string city) => MemberDAO.Instance.GetListSearchByCity(city);

        public List<Member> GetListSearchByCountry(string country) => MemberDAO.Instance.GetListSearchByCountry(country);
     
    }
}

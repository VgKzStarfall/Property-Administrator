using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess.DataAccess;

namespace DataAccess.Repos
{
    public interface IMember
    {
        IEnumerable<Member> GetMember();
        Member GetMemberByID(int carId);
        void InsertMember(Member member);
        void DeleteMember(int memberId);
        void UpdateMember(Member member);
        List<Member> GetListSearchByName(string name);
        List<Member> GetListSearchByCity(string city);
        List<Member> GetListSearchByCountry(string country);

    }
}

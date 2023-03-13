using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repos
{
    public interface IMember
    {
        IEnumerable<MemberObject> GetMember();
        MemberObject GetMemberByID(int carId);
        void InsertMember(MemberObject member);
        void DeleteMember(int memberId);
        void UpdateMember(MemberObject member);
        MemberObject Login(string email, string password);
    }
}

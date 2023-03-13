using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class Member: IMember
    {
        public void DeleteMember(int memberId) => MemberDBContext.Instance.Remove(memberId);


        public MemberObject GetMemberByID(int memberId) => MemberDBContext.Instance.GetMemberByID(memberId);


        public IEnumerable<MemberObject> GetMember() => MemberDBContext.Instance.GetMemberList();


        public void InsertMember(MemberObject member) => MemberDBContext.Instance.AddNew(member);


        public void UpdateMember(MemberObject member) => MemberDBContext.Instance.Update(member);

        public MemberObject Login(string email, string password) => MemberDBContext.Instance.Login(email, password);

    }
}

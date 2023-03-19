using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new MemberDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetList()
        {
            List<Member> members;
            try
            {
                var db = new XstoreContext();
                members = db.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return members;
        }

        public Member GetById(int id)
        {
            try
            {
                var db = new XstoreContext();

                return db.Members.First(m => m.MemberId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Member> GetListSearchByName(string name)
        {
            List<Member> members;
            try
            {
                var db = new XstoreContext();
                members = db.Members.Where(property => property.CompanyName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public List<Member> GetListSearchByCity(string city)
        {
            List<Member> members;
            try
            {
                var db = new XstoreContext();
                members = db.Members.Where(property => property.City.Contains(city)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public List<Member> GetListSearchByCountry(String area)
        {
            List<Member> members;
            try
            {
                var db = new XstoreContext();
                members = db.Members.Where(property => property.Country.Contains(area)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }


        public void DeleteById(int Id)
        {
            try
            {
                var db = new XstoreContext();
                Member mem = new() { MemberId = Id };
                db.Members.Remove(mem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Add(Member mem)
        {
            try
            {
                var db = new XstoreContext();

                db.Members.Add(mem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Member mem)
        {
            try
            {
                var db = new XstoreContext();

                db.Members.Update(mem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


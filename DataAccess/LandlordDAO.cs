using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace DataAccess
{
    public class LandlordDAO
    {
        private static LandlordDAO instance = null;
        private static readonly object instanceLock = new();
        private LandlordDAO() { }
        public static LandlordDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new LandlordDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Landlord> GetList()
        {
            List<Landlord> landlords;
            try
            {
                var db = new PropMngContext();
                landlords = db.Landlords.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return landlords;
        }

        public Landlord GetById(int id)
        {
            try
            {
                var db = new PropMngContext();

                return db.Landlords.First(m => m.LandlordId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Landlord> GetListSearchByName(string name)
        {
            List<Landlord> landlords;
            try
            {
                var db = new PropMngContext();
                landlords = db.Landlords.Where(m => m.Name.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return landlords;
        }

        public List<Landlord> GetListSearchByCity(string city)
        {
            List<Landlord> landlords;
            try
            {
                var db = new PropMngContext();
                landlords = db.Landlords.Where(m => m.Location.Contains(city)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return landlords;
        }


        public void DeleteById(int Id)
        {
            try
            {
                var db = new PropMngContext();
                Landlord mem = new() { LandlordId = Id };
                db.Landlords.Remove(mem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Add(Landlord mem)
        {
            try
            {
                var db = new PropMngContext();

                db.Landlords.Add(mem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Landlord mem)
        {
            try
            {
                var db = new PropMngContext();

                db.Landlords.Update(mem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

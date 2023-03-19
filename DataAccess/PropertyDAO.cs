using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace DataAccess
{
    public class PropertyDAO
    {
        private static PropertyDAO instance = null;
        private static readonly object instanceLock = new();
        private PropertyDAO() { }
        public static PropertyDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new PropertyDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Property> GetList()
        {
            List<Property> properties;
            try
            {
                var db = new XstoreContext();
                properties = db.Properties.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return properties;
        }

        public Property GetById(int id)
        {
            try
            {
                var db = new XstoreContext();

                return db.Properties.First(m => m.PropertyId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Property> GetListSearchByName(string name)
        {
            List<Property> properties;
            try
            {
                var db = new XstoreContext();
                properties = db.Properties.Where(property => property.PName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return properties;
        }

        public List<Property> GetListSearchByLocation(string loc)
        {
            List<Property> properties;
            try
            {
                var db = new XstoreContext();
                properties = db.Properties.Where(property => property.PLocation.Contains(loc)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return properties;
        }

        public List<Property> GetListSearchByArea(double area)
        {
            List<Property> properties;
            try
            {
                var db = new XstoreContext();
                properties = db.Properties.Where(property => property.PArea>=area).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return properties;
        }

        public List<Property> GetListSearchByPrice(double price)
        {
            List<Property> properties;
            try
            {
                var db = new XstoreContext();
                properties = db.Properties.Where(property => property.PPrice >= price).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return properties;
        }

        public void DeleteById(int Id)
        {
            try
            {
                var db = new XstoreContext();
                Property prop = new() { PropertyId = Id };
                db.Properties.Remove(prop);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Add(Property prop)
        {
            try
            {
                var db = new XstoreContext();

                db.Properties.Add(prop);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Property prop)
        {
            try
            {
                var db = new XstoreContext();

                db.Properties.Update(prop);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

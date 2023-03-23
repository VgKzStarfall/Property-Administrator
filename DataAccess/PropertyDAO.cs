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
                var db = new PropMngContext();
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
                var db = new PropMngContext();

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
                var db = new PropMngContext();
                properties = db.Properties.Where(property => property.Name.Contains(name)).ToList();
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
                var db = new PropMngContext();
                properties = db.Properties.Where(property => property.Location.Contains(loc)).ToList();
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
                var db = new PropMngContext();
                properties = db.Properties.Where(property => property.Area>=area).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return properties;
        }

        public List<Property> GetListSearchByPrice(decimal price)
        {
            List<Property> properties;
            try
            {
                var db = new PropMngContext();
                properties = db.Properties.Where(property => property.Price >= price).ToList();
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
                var db = new PropMngContext();
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
                var db = new PropMngContext();

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
                var db = new PropMngContext();

                db.Properties.Update(prop);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Property> getPropertyListByOwner(int landlord)
        {
            List<PropertyOwner> properties;
            List<Property> myProperties;
            try
            {     
                myProperties = new List<Property>();
                var db = new PropMngContext();
                properties = db.PropertyOwners.Where(property => property.LandlordId >= landlord).ToList();

                foreach (var prop in properties)
                {
                    myProperties.Add(GetById((int)prop.PropertyId));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return myProperties;
        }


    }
}

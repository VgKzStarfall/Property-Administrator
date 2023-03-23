using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;
using DataAccess.Repos;
using DataAccess.ModelShow;

namespace DataAccess
{
    public class PropertyOwnerDAO
    {
        private static PropertyOwnerDAO instance = null;
        private static readonly object instanceLock = new();
        private PropertyOwnerDAO() { }
        public static PropertyOwnerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new PropertyOwnerDAO();
                    return instance;
                }
            }
        }
        public void addOwner(Landlord owner, Property prop)
        {
            var db = new PropMngContext();
            PropertyOwner po = db.PropertyOwners.FirstOrDefault(m => m.PropertyId == prop.PropertyId && m.OwnEndDate == null);
            if (po == null)
            {
                newOwner(owner, prop);
            } else
            {
                endOwner(owner, prop);
                newOwner(owner, prop);
            }
        }
        public void newOwner(Landlord owner, Property prop)
        {
            try
            {
                var db = new PropMngContext();
                PropertyOwner po = new PropertyOwner();
                po.LandlordId = owner.LandlordId;
                po.PropertyId = prop.PropertyId;
                po.OwnStartDate = DateTime.Now;
                db.PropertyOwners.Add(po);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void endOwner(Landlord owner, Property prop)
        {
            try
            {
                var db = new PropMngContext();
                PropertyOwner po = db.PropertyOwners.First(m => m.PropertyId == prop.PropertyId && m.OwnEndDate == null);
                if (po==null)
                {
                    throw new Exception("No owner");
                } else
                {
                    po.OwnEndDate = DateTime.Now;
                    db.PropertyOwners.Update(po);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PropertyOwnerShow> getListOwnersHistory(Property prop)
        {
            List<PropertyOwner> properties;
            List<PropertyOwnerShow> propShow = new List<PropertyOwnerShow>();
            try
            {
                var db = new PropMngContext();
                properties = db.PropertyOwners.Where(property => property.PropertyId==prop.PropertyId).ToList();
                for (int i=0;i< properties.Count;i++)
                {
                    PropertyOwnerShow pos = new PropertyOwnerShow();
                    pos.OwnId = properties[i].OwnId;
                    pos.LandlordName = db.Landlords.First(l => l.LandlordId == properties[i].LandlordId).Name;
                    pos.OwnStartDate = (DateTime)properties[i].OwnStartDate;
                    pos.OwnEndDate = properties[i].OwnEndDate;
                    propShow.Add(pos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return propShow;
        }

        public List<PropertyOwnerShow> getPropertyOwnerListByOwner(int landlord)
        {
            List<PropertyOwner> properties;
            List<PropertyOwnerShow> myProperties;
            try
            {
                PropertyRepository propertyRepository = new PropertyRepository();
                myProperties = new List<PropertyOwnerShow>();
                var db = new PropMngContext();
                properties = db.PropertyOwners.Where(property => property.LandlordId >= landlord).ToList();

                foreach (var prop in properties)
                {
                    PropertyOwnerShow pos = new PropertyOwnerShow();
                    pos.PropertyName = db.Properties.FirstOrDefault(l => l.PropertyId == prop.PropertyId).Name;
                    pos.PropertyLocation = db.Properties.FirstOrDefault(l => l.PropertyId == prop.PropertyId).Location;
                    pos.OwnStartDate = (DateTime)prop.OwnStartDate;
                    myProperties.Add(pos);
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

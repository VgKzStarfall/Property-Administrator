using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

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
            try
            {
                var db = new PropMngContext();
                PropertyOwner po = db.PropertyOwners.First(m => m.PropertyId == prop.PropertyId && m.OwnEndDate == null);
                if (po == null)
                {
                    newOwner(owner, prop);
                } else
                {
                    endOwner(owner, prop);
                    newOwner(owner, prop);
                }
                db.PropertyOwners.Update(po);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void newOwner(Landlord owner, Property prop)
        {
            try
            {
                var db = new PropMngContext();
                PropertyOwner po = new PropertyOwner();
                po.OwnId = owner.LandlordId;
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
    }
}

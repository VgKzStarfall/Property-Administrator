using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ModelShow;

namespace DataAccess.Repos
{
    public class PropertyRepository : IPropertyRepository
    {
        public void DeleteProperty(int propertyId) => PropertyDAO.Instance.DeleteById(propertyId);
        public Property GetPropertyByID(int propertyId) => PropertyDAO.Instance.GetById(propertyId);
        public IEnumerable<Property> GetProperties() => PropertyDAO.Instance.GetList();
        public void InsertProperty(Property property) => PropertyDAO.Instance.Add(property);
        public void UpdateProperty(Property property) => PropertyDAO.Instance.Update(property);
        public List<Property> GetListSearchByArea(double area) => PropertyDAO.Instance.GetListSearchByArea(area);
        public List<Property> GetListSearchByLocation(string loc) => PropertyDAO.Instance.GetListSearchByLocation(loc);
        public List<Property> GetListSearchByName(string name) => PropertyDAO.Instance.GetListSearchByName(name);
        public List<Property> GetListSearchByPrice(decimal price) => PropertyDAO.Instance.GetListSearchByPrice(price);
        public void addOwner(Landlord owner, Property prop) => PropertyOwnerDAO.Instance.addOwner(owner, prop);
        public List<PropertyOwnerShow> getOwnerHist(Property prop) => PropertyOwnerDAO.Instance.getListOwnersHistory(prop);
        public string getFeatures(int propId) => FeatureDAO.Instance.listFeatureToString(FeatureDAO.Instance.GetListByPropId(propId));
    }
}

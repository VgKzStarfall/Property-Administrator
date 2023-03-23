using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;
using DataAccess.ModelShow;

namespace DataAccess.Repos
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetProperties();
        Property GetPropertyByID(int propertyId);
        void InsertProperty(Property property);
        void DeleteProperty(int propertyId);
        void UpdateProperty(Property property);
        List<Property> GetListSearchByName(string name);
        List<Property> GetListSearchByLocation(string loc);
        List<Property> GetListSearchByArea(double area);
        List<Property> GetListSearchByPrice(decimal price);
        void addOwner(Landlord owner, Property prop);
        List<PropertyOwnerShow> getOwnerHist(Property prop);
        string getFeatures(int propId);
        List<PropertyOwnerShow> getPropertyOwnerListByOwner(int landlord);
        void endOwner(Property prop);
        List<Feature> listFeatures(Property prop);
        void addFeatures(Feature[] features);
        void updateFeature(Feature f);
        void deleteFeature(int featureId);
    }
}

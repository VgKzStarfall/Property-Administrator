using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

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
    }
}

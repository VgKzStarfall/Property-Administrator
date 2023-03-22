using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace DataAccess.Repos
{
    public interface ILandlordRepository
    {
        IEnumerable<Landlord> GetLandlord();
        Landlord GetLandlordByID(int id);
        void InsertLandlord(Landlord landlord);
        void DeleteLandlord(int id);
        void UpdateLandlord(Landlord landlord);
        List<Landlord> GetListSearchByName(string name);
        List<Landlord> GetListSearchByCity(string city);
    }
}

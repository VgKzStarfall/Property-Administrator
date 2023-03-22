using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class LandlordRepository : ILandlordRepository
    {
        public void DeleteLandlord(int id) => LandlordDAO.Instance.DeleteById(id);
       
        public IEnumerable<Landlord> GetLandlord() => LandlordDAO.Instance.GetList();

        public Landlord GetLandlordByID(int id) => LandlordDAO.Instance.GetById(id);

        public List<Landlord> GetListSearchByCity(string city) => LandlordDAO.Instance.GetListSearchByCity(city);

        public List<Landlord> GetListSearchByName(string name) => LandlordDAO.Instance.GetListSearchByName(name);

        public void InsertLandlord(Landlord landlord) => LandlordDAO.Instance.Add(landlord);

        public void UpdateLandlord(Landlord landlord) => LandlordDAO.Instance.Update(landlord);
 
    }
}

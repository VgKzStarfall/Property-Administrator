using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace DataAccess
{
    public class PriceHistoryDAO
    {
        private static PriceHistoryDAO instance = null;
        private static readonly object instanceLock = new();
        private PriceHistoryDAO() { }
        public static PriceHistoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new PriceHistoryDAO();
                    return instance;
                }
            }
        }

        public List<PriceHistory> getListPriceHist(int propId)
        {
            List<PriceHistory> priceHist;
            try
            {
                var db = new PropMngContext();
                priceHist = db.PriceHistories.Where(f => f.PropertyId == propId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return priceHist;
        }

        public void add(PriceHistory p)
        {
            try
            {
                var db = new PropMngContext();

                db.PriceHistories.Add(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

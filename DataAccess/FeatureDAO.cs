using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace DataAccess
{
    public class FeatureDAO
    {
        private static FeatureDAO instance = null;
        private static readonly object instanceLock = new();
        private FeatureDAO() { }
        public static FeatureDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new FeatureDAO();
                    return instance;
                }
            }
        }


    }
}

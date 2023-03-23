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

        public List<Feature> GetListByPropId(int propId)
        {
            List<Feature> features;
            try
            {
                var db = new PropMngContext();
                features = db.Features.Where(f => f.PropertyId == propId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return features;
        }

        public string listFeatureToString(List<Feature> listF)
        {
            string features = "";
            foreach (var f in listF)
            {
                features +=f.FeatureDescription + ", ";
            }
            if (features.Length>2)
            {
                features = features.Substring(0, features.Length - 2);
            }
            return features;
        }

        public Feature GetById(int id)
        {
            try
            {
                var db = new PropMngContext();

                return db.Features.First(m => m.FeatureId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(Feature[] prop)
        {
            try
            {
                var db = new PropMngContext();

                db.Features.AddRange(prop);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Feature f)
        {
            try
            {
                var db = new PropMngContext();

                db.Features.Update(f);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteById(int Id)
        {
            try
            {
                var db = new PropMngContext();
                Feature f = new() { FeatureId = Id };
                db.Features.Remove(f);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

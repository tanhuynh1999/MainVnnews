using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AdsDAO
    {
        DBvnewsEntities db = new DBvnewsEntities();
        public int Insert(Ad ads)
        {
            try
            {
                ads.ads_bin = false;
                ads.ads_datecreate = DateTime.Now;
                ads.ads_option = true;
                ads.ads_loop = 0;
                db.Ads.Add(ads);
                db.SaveChanges();

                return 1;
            }
            catch (Exception) { return 0; }
        }
    }
}

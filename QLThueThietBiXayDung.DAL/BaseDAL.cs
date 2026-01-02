using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QLThueThietBiXayDung.DAL
{
    public class BaseDAL
    {
        protected QLThueThietBiXayDungDBContext db;

        public BaseDAL()
        {
            db = new QLThueThietBiXayDungDBContext();
        }
    }
}

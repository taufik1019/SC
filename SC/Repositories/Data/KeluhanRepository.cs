using SC.Context;
using SC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Repositories.Data
{
    public class KeluhanRepository
    {
        MyContext myContext;

        public KeluhanRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public List<Keluhan> Get()
        {
            var data = myContext.Keluhans.ToList();
            return data;
        }

        public Keluhan Get(int id)
        {
            var data = myContext.Keluhans.FirstOrDefault();
            return data;
        }

        public int Post(Keluhan keluhan)
        {
            myContext.Keluhans.Add(keluhan);
            var result = myContext.SaveChanges();
            if (result > 0)
                return result;
            return 0;
        }

        public int Put(int id, Keluhan keluhan)
        {
            var data = myContext.Keluhans.Find(id);
            data.KeluhanMhs = keluhan.KeluhanMhs;
            data.Tanggal = keluhan.Tanggal;
            myContext.Keluhans.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Remove(Keluhan keluhan)
        {
            myContext.Keluhans.Remove(keluhan);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}

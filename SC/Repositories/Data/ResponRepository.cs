using Microsoft.EntityFrameworkCore;
using SC.Context;
using SC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Repositories.Data
{
    public class ResponRepository
    {
        MyContext myContext;

        public ResponRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public List<Respon> Get()
        {
            var data = myContext.Respons.Include(x => x.Keluhan).ToList();
            return data;
        }

        public Respon Get(int id)
        {
            var data = myContext.Respons
                       .Include(x => x.Keluhan)
                       .Where(x => x.ResponId.Equals(id))
                       .FirstOrDefault();
            return data;
        }

        public Respon Getrespon(int id)
        {
            var data = myContext.Respons
                       .Where(x => x.KeluhanId.Equals(id))
                       .FirstOrDefault();
            return data;
        }

        public int Post(Respon respon)
        {
            myContext.Respons.Add(respon);
            var result = myContext.SaveChanges();
            if (result > 0)
                return result;
            return 0;
        }

        public int Put(int id, Respon respon)
        {
            var data = myContext.Respons.Find(id);
            data.ResponKeluhan = respon.ResponKeluhan;
            data.TanggalRespon = respon.TanggalRespon;
            myContext.Respons.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Remove(Respon respon)
        {
            myContext.Respons.Remove(respon);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}

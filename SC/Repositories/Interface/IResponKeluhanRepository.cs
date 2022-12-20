using SC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Repositories.Interface
{
    public interface IResponKeluhanRepository
    {
        List<ResponKeluhan> Get();
        ResponKeluhan Get(int id);
        int Post(ResponKeluhan ResponKeluhan);
        int Put(int id, ResponKeluhan ResponKeluhan);
        int Delete(ResponKeluhan ResponKeluhan);
    }
}

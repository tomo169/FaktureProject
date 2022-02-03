using FaktureProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.Services
{
    public interface IStavkaData
    {
        IEnumerable<Stavka> GetAll();
        Stavka Get(int id);
        void Add(Stavka stavka);
        void Update(Stavka stavka);
        void Delete(int id);
    }
}

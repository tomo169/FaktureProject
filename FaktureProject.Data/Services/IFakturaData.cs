using FaktureProject.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.Services
{
    public interface IFakturaData
    {
        IEnumerable<Faktura> GetAll();
        Faktura Get(int id);
        void Add(Faktura faktura);
        void Update(Faktura faktura);
        void Delete(int id);
    }
}

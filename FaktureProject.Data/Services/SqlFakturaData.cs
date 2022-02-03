using FaktureProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.Services
{
    public class SqlFakturaData : IFakturaData
    {
        private readonly FaktureProjectDbContext db;

        public SqlFakturaData(FaktureProjectDbContext db)
        {
            this.db = db;
        }
        public void Add(Faktura faktura)
        {
            db.Fakture.Add(faktura);
            db.SaveChanges();
        }

        public Faktura Get(int id)
        {
            return db.Fakture.FirstOrDefault(f => f.Id == id);

        }

        public IEnumerable<Faktura> GetAll()
        {
            return from r in db.Fakture
                   orderby r.BrojFakture
                   select r;
        }

        public void Update(Faktura faktura)
        {
            var entry = db.Entry(faktura);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var faktura = db.Fakture.Find(id);
            db.Fakture.Remove(faktura);
            db.SaveChanges();
        }

    }
}

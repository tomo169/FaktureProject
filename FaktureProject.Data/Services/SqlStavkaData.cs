using FaktureProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.Services
{
    public class SqlStavkaData : IStavkaData
    {
        private readonly FaktureProjectDbContext db;

        public SqlStavkaData(FaktureProjectDbContext db)
        {
            this.db = db;
        }
        public void Add(Stavka stavka)
        {
            db.Stevake.Add(stavka);
            db.SaveChanges();
        }

        public Stavka Get(int id)
        {
            return db.Stevake.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Stavka> GetAll()
        {
            return db.Stevake;
        }

        public void Update(Stavka stavka)
        {
            var entry = db.Entry(stavka);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var stavka = db.Stevake.Find(id);
            db.Stevake.Remove(stavka);
            db.SaveChanges();
        }

    }
}

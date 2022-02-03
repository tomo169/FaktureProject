using FaktureProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.Services
{
    public class FaktureProjectDbContext : DbContext
    {
        public DbSet<Faktura> Fakture { get; set; }
        public DbSet<Stavka> Stevake { get; set; }
    }
}

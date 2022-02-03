using FaktureProject.Data.Models.MEF;
using FaktureProject.Data.UkupneCijene;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.Models
{
    public class Faktura
    {
        private readonly Porez p = new Porez();

        public int Id { get; set; }
        public int BrojFakture { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatumStvaranjaFakture { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatumDospijecaFakture { get; set; }
        public string Tax { get; set; }
        public decimal? UkupnaCijenaBezPoreza { get { return Stavke.Sum(s => s.UkupnaCijena); } }
        public decimal? UkupnaCijenaSPorezom { get { return p.obr.Obracunaj(Tax, UkupnaCijenaBezPoreza); } }
        public string Korisnik { get; set; }
        public string Primatelj { get; set; }

        public virtual ICollection<Stavka> Stavke { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.Models
{
    public class Stavka
    {
        public int Id { get; set; }
        public int FakturaId { get; set; }
        public string OpisStavke { get; set; }
        public int KolicinaStavke { get; set; }
        public decimal CijenaStavke { get; set; }
        public decimal UkupnaCijena 
        { 
            get { return KolicinaStavke * CijenaStavke; }
        }
        public virtual Faktura Faktura { get; set; }
    }
}

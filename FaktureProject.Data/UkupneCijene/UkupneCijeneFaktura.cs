using FaktureProject.Data.Models;
using FaktureProject.Data.Models.MEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.UkupneCijene
{
    public class UkupneCijeneFaktura
    {
        private Faktura f = new Faktura();
        private Stavka s = new Stavka();
        private Porez p = new Porez();

        public decimal? UkpnaCijenaBezPoreza()
        {
            return f.Stavke.Sum(s => s.UkupnaCijena);
        }

        public decimal? UkupnaCijenaSPorezom()
        {
            return p.obr.Obracunaj(f.Tax, f.UkupnaCijenaBezPoreza);
        }

        public decimal UkupnaCijena()
        {
            return s.CijenaStavke * s.KolicinaStavke;
        }
    }
}

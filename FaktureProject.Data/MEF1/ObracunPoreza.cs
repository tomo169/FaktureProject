
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.Models.MEF
{
    [Export(typeof(IObracun))]
    public class ObracunPoreza : IObracun
    {
        public decimal? Obracunaj(string s, decimal? x)
        {
            var hr = "HRVtax";
            var ba = "BiHtax";


            if (s == hr)
            {
                return (x * 25/100) + x;
            }

            if (s == ba)
            {
                return (x * 17/100) + x;
            }
            
            return x;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaktureProject.Data.Models.MEF
{
    public class Porez
    {
        private CompositionContainer _container;

        public Porez()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Porez).Assembly));


            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }

        [Import(typeof(IObracun))]
        public IObracun obr;
    }
}

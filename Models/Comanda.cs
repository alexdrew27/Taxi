using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi.Models
{
    public class Comanda
    {
        public int ComandaId { set; get; }
        public String Nume { get; set; }
        public String NrTelefon { get; set; }
        public String Email { get; set; }
        public String CartierCurent { set; get; }
        public String StradaCurenta { set; get; }
        public String DetaliiAdresaCurent { set; get; }

        public String CartierDestinatie { set; get; }
        public String StradaDestinatie { set; get; }
        public String DetaliiAdresaDestinatie { set; get; }

        public Boolean Status { set; get; }
        public int Timp { set; get; }
        public Taxii taxi { set; get; }

    }
}

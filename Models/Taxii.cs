using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxi.Models
{
    public class Taxii
    {
        public int TaxiiId { set; get; }
        public ICollection<Comanda> Comenzi { set; get; }
        public String Marca { get; set; }
        public int Nr { get; set; }
    }

   
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlupp_2
{
    public class Kvitto
    {
        public Product Produkt { get; set; }
        public int Antal { get; set; }
        public decimal Sum { get; set; }

        public decimal Rabatt { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Inlupp_2
{
    public class Produkt
    {
        public Produkt(int id)
        {
            Id = id;

        }

        public int Id { get; set; }
        public string Namn { get; set; }
        public string PrisTyp { get; set; }
        public decimal Pris { get; set; }

        



        

        
    }

    
}
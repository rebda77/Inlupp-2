using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;

namespace Test
{
    class Kvitto
    {
        public Produkt Produkt { get; set; }
        public decimal Antal { get; set; }
        public decimal Summa { get; set; }
        public decimal Rabatt { get; set; }

        public static void SkrivKvittoTillFil(List<Kvitto> kvittoList)
        {

            using (StreamWriter streamaKvitto = File.AppendText(Kassa.filKvitto))
            {

                decimal summera = 0;
                foreach (var kvitto in kvittoList)
                {
                    streamaKvitto.WriteLine($"{kvitto.Produkt.Namn}, {kvitto.Produkt.Pris}, {kvitto.Produkt.Pris} * {kvitto.Antal} = {kvitto.Summa}");
                    summera += kvitto.Summa;
                }
                streamaKvitto.WriteLine($"Total Summa: {summera}");
                streamaKvitto.WriteLine("========================");

            }

            Console.WriteLine("Välkommen åter!");

        }

        public static List<Kvitto> TaBortVara(int korrektID, List<Kvitto> kvittoList)
        {
            kvittoList.RemoveAll(x => x.Produkt.Id == korrektID && x.Antal < 2);
            foreach (var kvitto in kvittoList)
            {
                if (kvitto.Produkt.Id == korrektID)
                {
                    if (kvitto.Antal > 1)
                    {
                        kvitto.Antal = kvitto.Antal - 1;
                        kvitto.Summa -= kvitto.Produkt.Pris;
                    }
                }
            }

            return kvittoList;
        }
    }

}



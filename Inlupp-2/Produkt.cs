using System;
using System.Collections.Generic;
using System.IO;

namespace Inlupp_2
{
    class Produkt
    {
        public Produkt(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public decimal Pris { get; set; }
        public string PrisTyp { get; set; }
        public string Namn { get; set; }


        public static void InitieraProdukter()
        {
            var prod1 = new Produkt(0001)
            {
                Pris = 4,
                PrisTyp = "Pris kg",
                Namn = "Morötter",
            };
            var prod2 = new Produkt(0002)
            {
                Pris = 39,
                PrisTyp = "Pris st",
                Namn = "Körsbärstomater",
            };
            var prod3 = new Produkt(0003)
            {
                Pris = 29,
                PrisTyp = "Pris kg",
                Namn = "Purjolök",
            };
            var prod4 = new Produkt(0004)
            {
                Pris = 25,
                PrisTyp = "Pris st",
                Namn = "Choklad",
            };
            var prod5 = new Produkt(0005)
            {
                Pris = 23,
                PrisTyp = "Pris st",
                Namn = "Earl Grey",
            };
            var productList = new List<Produkt>
            {
                prod1,
                prod2,
                prod3,
                prod4,
                prod5
            };

            var filExisterar = File.Exists(Kassa.filProdukt);

            if (filExisterar)
            {
                if (string.IsNullOrEmpty(File.ReadAllText(Kassa.filProdukt)))
                {
                    using (StreamWriter productWriter = new StreamWriter(Kassa.filProdukt))
                    {
                        foreach (var prod in productList)
                        {
                            productWriter.WriteLine($"{prod.Id},{prod.Pris},{prod.PrisTyp},{prod.Namn}");

                        }
                    }
                }
            }
            else
            {
                using (StreamWriter productWriter = File.CreateText(Kassa.filProdukt))
                {
                    foreach (var prod in productList)
                    {
                        productWriter.WriteLine($"{prod.Id},{prod.Pris},{prod.PrisTyp},{prod.Namn}");
                    }
                }

            }

        }

        public static List<Produkt> HittaProdukter()
        {
            var produktList = new List<Produkt>();
            using (StreamReader hittaProdukter = new StreamReader(Kassa.filProdukt, true))
            {
                var readLineResult = "";
                while ((readLineResult = hittaProdukter.ReadLine()) != null)
                {
                    var prodLine = readLineResult.Split(",");
                    var prodObject = new Produkt(int.Parse(prodLine[0]))
                    {
                        Pris = decimal.Parse(prodLine[1]),
                        PrisTyp = prodLine[2],
                        Namn = prodLine[3]
                    };
                    produktList.Add(prodObject);
                }

            }
            return produktList;
        }





    }

}



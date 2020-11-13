using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace Inlupp_2
{
    class Kassa
    {
        static public string filProdukt = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"produkter.txt");
        static public string filKvitto = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"kvitton_{DateTime.Now.ToString("yyyyMMdd")}.txt");

        public static void Kund()
        {
            List<Kvitto> kvittoLista = new List<Kvitto>();

            Console.WriteLine("Kommandon: ");
            Console.WriteLine("PAY");
            Console.WriteLine("<PRODUKTID> <antal>");

            bool betala = false;
            bool formatinput = false;
            int idformat = 0;

            while (!betala)
            {
                if (formatinput)
                {
                    if (kvittoLista.Count > 0)
                    {
                        Console.WriteLine("Kommandon: ");
                        Console.WriteLine("<PRODUKTID> <antal> ");
                        Console.WriteLine("RETURN <PRODUKTID>");
                        Console.WriteLine("PAY");
                    }
                }

                formatinput = false;
                var inputVal = Console.ReadLine().ToUpper().Split(" ");
                if (inputVal[0] == "PAY")
                {
                    Kvitto.SkrivKvittoTillFil(kvittoLista);
                    kvittoLista.Clear();
                    betala = true;
                }

                else if (inputVal[0] == "RETURN" && kvittoLista.Count > 0 && inputVal.Length == 2)
                {
                    var korrektID = 0;
                    while (!int.TryParse(inputVal[1], out korrektID) &&
                           kvittoLista.Exists(x => x.Produkt.Id != korrektID))
                    {
                        Console.WriteLine("Fel ID, finns inte i korgen");
                        inputVal[1] = Console.ReadLine();
                    }


                    Kvitto.TaBortVara(korrektID, kvittoLista);
                    formatinput = true;

                }
                else if (inputVal.Length != 2)
                {
                    Console.WriteLine("Felaktigt kommando");
                }



                var prodID = inputVal[0];

                var hittaProdukter = Produkt.HittaProdukter();
                if (int.TryParse(prodID, out idformat) && hittaProdukter.Exists(x => x.Id == idformat) &&
                    inputVal.Length == 2)
                {
                    var antal = inputVal[1];
                    decimal korrektFormatAntal = 0;

                    while (!decimal.TryParse(antal, out korrektFormatAntal))
                    {
                        Console.WriteLine($"Fel kommando {antal} Testa igen");
                        antal = Console.ReadLine();
                    }

                    foreach (var prod in hittaProdukter)
                    {
                        if (idformat == prod.Id)
                        {
                            var summa = korrektFormatAntal * prod.Pris;
                            decimal rabatt = 0;
                            if (summa > 1000)
                            {
                                rabatt = summa * (decimal)0.02;
                            }

                            if (summa > 2000)
                            {
                                rabatt = summa * (decimal)0.03;
                            }

                            var kvittoProdukt = new Kvitto
                            {
                                Antal = korrektFormatAntal,
                                Produkt = prod,
                                Summa = summa,
                                Rabatt = rabatt,
                            };
                            kvittoLista.Add(kvittoProdukt);
                        }
                    }

                    formatinput = true;
                }

                decimal totala = 0;
                decimal allRabatt = 0;
                if (formatinput)
                {
                    Console.Clear();
                    Console.WriteLine("KASSA");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"KVITTO: {DateTime.Now}");
                    foreach (var kprod in kvittoLista)
                    {
                        Console.WriteLine(
                            $"{kprod.Produkt.Namn}, {kprod.Antal} * {kprod.Produkt.Pris} = {kprod.Antal * kprod.Produkt.Pris} kr");
                        totala += kprod.Produkt.Pris * kprod.Antal;
                        allRabatt += kprod.Rabatt;
                    }

                    Console.WriteLine($"Produkter totalt: {totala} kr");
                    decimal rabatt1 = 1000;
                    if (totala > rabatt1)
                    {
                        Console.WriteLine($"Sammanlagd Rabatt: -{allRabatt}");
                        Console.WriteLine($"Totalt efter rabatt: {totala - allRabatt}");
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                }


            }
        }

    }
}
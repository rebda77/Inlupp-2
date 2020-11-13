using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Inlupp_2
{
    class Kassa
    {
        //static string filProdukt = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"produkter.txt");
        //static string filKvitto = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"kvitton_{DateTime.Now.ToString("yyyyMMdd")}.txt");
        public void Kund()
        {

            Console.WriteLine("Ge kommando...");
            Console.WriteLine("PAY");
            Console.WriteLine("RETURN <PRODUKTID>");


            var betala = false;
            var formatInput = false;
            var idFormat = 0;


            while (!betala)
            {
                if (formatInput)
                {
                    if (kvittoLista.Count > 0)
                    {
                        Console.WriteLine("Kommandon");
                        Console.WriteLine("<PRODUKTID> <antal>");
                        Console.WriteLine("RETURN <PRODUKTID");
                        Console.WriteLine("PAY");
                    }
                }

                var inputVal = Console.ReadLine().ToUpper().Split("");
                if (inputVal[0] == "PAY")
                {
                    //SkrivTillKvitto(kvittoLista);
                    betala = true;
                }
                else if (inputVal[0] == "RETURN" && inputVal.Length == 2)
                {
                    var felID = 0;
                    while (!int.TryParse(inputVal[1], out felID) &&
                        kvittoLista.Exists(x => x.Product.Id != felID))
                }
                




            }
        }
    }
}

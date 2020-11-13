using System;

namespace Inlupp_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Produkt.InitieraProdukter();
            Produkt.HittaProdukter();

            bool MenyBool = true;
            while (MenyBool)
            {
                Console.WriteLine("Huvudmeny:");
                Console.WriteLine("1. Ny kund");
                Console.WriteLine("0. Avsluta");
                var menyVal = Console.ReadLine();
                int valformat;

                while ((!int.TryParse(menyVal, out valformat)) || valformat < 0 )
                {
                    Console.WriteLine("Du har skrivit in fel format, prova igen!");
                    menyVal = Console.ReadLine();
                }

                if (valformat == 1)
                {
                    Console.Clear();
                    Kassa.Kund();
                }
                
                else if (valformat == 0)
                {
                    MenyBool = false;
                }

            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlupp_2
{
    class Kassa
    {
        public void Run()
        {
            var quit = false;
            while (!quit)
            {
                Console.WriteLine("1. Ny kund");
                Console.WriteLine("0. Avsluta");
                int selection = int.Parse(Console.ReadLine());
                if (selection == 1)
                {
                    //Kvittoprinter go
                }
                else
                {
                    quit = true;
                }


            }
        }
    }
}

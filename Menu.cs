using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudySK
{
    class Menu
    {
        /*here we create the menu of our console app*/
        public static void Print()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Scrap App - Make a choice!");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Type YOUTUBE to enter a word and scrap the last videos from the search query!");
            Console.WriteLine("Type INDEED to enter the name of a job and scrap the last job posts!");
            Console.WriteLine("Type REDDIT to enter a word and scrap the last posts containing that word! a company from the list.");
            Console.WriteLine(" ");
            Console.Write("Enter choice: ");
        }

    }

}

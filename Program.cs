using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudySK
{
    class Program
    {
        static void Main(string[] args)
        {
            /*here we create a do while loop where our user can make a choice. Then depending on the choice made by the user, the corresponding method is called.*/
            do
            {
                Menu.Print();
                string choice = Console.ReadLine().ToUpper();

                if (choice == "YOUTUBE")
                {
                    Youtube ST1 = new Youtube();
                    ST1.YouTubeScraping();
                    Console.ReadLine();
                }
                else if (choice == "INDEED")
                {
                    Indeed ST2 = new Indeed();
                    ST2.IndeedScraping();
                    Console.ReadLine();
                }
                else if (choice == "REDDIT")
                {
                    Reddit ST3 = new Reddit();
                    ST3.RedditScraping();
                    Console.ReadLine();
                }
            } while (true);
        }
    }
}

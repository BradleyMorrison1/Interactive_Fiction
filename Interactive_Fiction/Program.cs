using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Fiction
{
    class Program
    {
        static string[] lines = System.IO.File.ReadAllLines("Story.txt");

        static string currentPage = lines[0];

        static string[] splitPage = currentPage.Split(';');

        static TextWriter textWriter = StreamWriter("SaveFile1");

        static void Main(string[] args)
        {
            string restart;
            string currentPage = lines[0];

            Console.WriteLine("|Time Traveling Interactive Fiction - Bradley Morrison|\n"); // Title
            do // Loop for the entire game
            {
                string savedPage;

                savedPage)

                ChoiceLoop();
                Console.WriteLine("\nThe End");
                Console.WriteLine("\nWould you like to restart? (Y)es or (N)o");
                restart = Console.ReadLine();
            }
            while (restart == "Y" || restart == "y");
         
        }
        
        static void ChoiceLoop() // a loop that allows the player to pick their pages
        {
            PagePrint(splitPage);
            do
            {
                int playerChoice = Convert.ToInt32(Console.ReadLine());
                
                switch (playerChoice)
                {
                    case 1:
                        NextPage(3);
                        break;
                    case 2:
                        NextPage(4);
                        break;
                    default:
                        Console.WriteLine("Sorry that wasn't an accepted answer. Please type 1 or 2.");
                        return;                        
                }
            }
            while (!String.IsNullOrEmpty(splitPage[1])); // Loops picking pages until you reach an ending
        }

        static void PagePrint(string[] printedPage) // Prints the Delimited string
        {
            //public string Replace ("\r\n", Environment.NewLine);

            Console.WriteLine(printedPage[0].Replace("\\n", "\n"));
            if (!String.IsNullOrEmpty(printedPage[1])) Console.WriteLine(printedPage[1]); // Skips this and the next line if the current page is an ending.
            else return;
            Console.WriteLine(printedPage[2]);
        }

        static void NextPage(int pageNum) // Calculates then Prints the next page. The int represents the location of the next page in the array.
        {
            int nextPageNum = Int32.Parse(splitPage[pageNum]); // Uses the number at the end of the delimeted string to find the next page

            currentPage = lines[nextPageNum - 1]; // Sets the current page to the next page
            splitPage = currentPage.Split(';'); // Delimits the current page 

            PagePrint(splitPage);
        }
    }
}

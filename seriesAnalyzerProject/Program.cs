using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seriesAnalyzerProject
{
    internal class Program
    {

        static void Main(string[] args) // Receives an array of strings and runs a conversion function to a list of strings with the received value
        {
            araayToList(args);
        }

        static void araayToList(string[] seriesNumbers) // Takes an array of strings and converts it to a list of strings
        {
            List<string> ListStrSeries = new List<string>();
            foreach (var val in seriesNumbers)
            {
                ListStrSeries.Add(val);

            }
            start(ListStrSeries);
        }  
        

        static void start(List<string> ListStrSeries)
        {
            if (!validEmpty(ListStrSeries))
            {
                validInt(ListStrSeries);
            }
            else
            {
                Console.WriteLine("No number entered.");
                inputNum();
            }
            
        }

        static void inputNum()
        {
            Console.WriteLine("Please enter at least three positive numbers:");
            string[] seriesNumbers = Console.ReadLine().Split(' ');
            
            araayToList(seriesNumbers);
        }// Receives an array of strings from the user.




        static bool validEmpty(List<string> ListStrSeries)
        {
            return ListStrSeries.Count == 0;
        }

        static void validInt(List<string> ListStrSeries)
        {
            foreach (var val in ListStrSeries)
            {

                if (!int.TryParse(val, out int num))
                {
                    Console.WriteLine($"The value {val} is not a number!");
                    inputNum();
                }
               
            }
            ListStrToListInt(ListStrSeries);
        } // Receives a list of strings and confirms that all iterations contain only numbers.

        static void ListStrToListInt(List<string> ListStrSeries) // Receives a list of strings and converts it to a list of integers.
        {
            List<int> ListIntSeries = new List<int>();
            foreach (var val in ListStrSeries)
            {
                ListIntSeries.Add(Convert.ToInt32(val));
            }
            validPositive(ListIntSeries);
        }

        static void validPositive(List<int> ListIntSeries) // Receives a list of integers and checks if all numbers in the list are positive.
        {
            foreach (var val in ListIntSeries)
            {
                if (val < 0)
                {
                    Console.WriteLine($"The number {val} is not a positive number.");
                    inputNum();
                }
            }
            validThree(ListIntSeries);
        }

        static bool validThree(List<int> ListIntSeries)
        {
            return ListIntSeries.Count >= 3;
        } // Gets a list of integers and checks if the list contains at least three numbers. 

    }
}












using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace seriesAnalyzerProject
{
    internal class Program
    {
        

        static bool flag = true;
        static void Main(string[] args)      // Receives an array of strings and runs a conversion function to a list of strings with the received value.
        {
            Start(args);
        }

           
        static void Start(string[] arrayStrSeries)                                  // Converts the array to a list of strings.
        {

            List<string> listStrSeries = ArrayToList(arrayStrSeries);              // Makes sure the list is complete, and contains only numbers.

            if (ValidIsFull(listStrSeries) && ValidInteger(listStrSeries))
            {
                List<int> listIntSeries = ListStrToListInt(listStrSeries);

                if (ValidPositive(listIntSeries) && ValidThree(listIntSeries))     // Makes sure all numbers in the list are positive, and that there are at least three numbers.
                {
                    while (flag)
                    {
                        Menu();
                        MakingChoice(listIntSeries);
                    }
                }
            }
            else                                                                   // If the above conditions are not met, new input is requested from the user.
            {
                InputNum();
            }
        }















        static List<string> ArrayToList(string[] seriesNumbers)  // Takes an array of strings and converts it to a list of strings.

        {
            List<string> listStrSeries = new List<string>();

            foreach (var val in seriesNumbers)
            {
                listStrSeries.Add(val);
            }
            return listStrSeries;
        }







        static bool ValidIsFull(List<string> listStrSeries)
        {

            if (listStrSeries.Count == 0)
            {            
                Console.WriteLine("ERROR - The value entered is not a number! ");
                return false;
            }
            return true;
        }

        static bool ValidInteger(List<string> listStrSeries)   // Receives a list of strings and confirms that all iterations contain only numbers.
        {
            foreach (var val in listStrSeries)
            {
                if (!int.TryParse(val, out int num))
                {
                    Console.WriteLine("ERROR - The value entered is not a number! ");
                    return false;
                }
            }
            return true;
        }





        static bool ValidPositive(List<int> listIntSeries) //  Receives a list of integers and checks if all numbers in the list are positive.

        {
            foreach (var val in listIntSeries)
            {
                if (val < 0)
                {
                    Console.WriteLine("ERROR - The number entered is not a positive number! ");
                    return false;
                }
            }
            return true;
        }





        static bool ValidThree(List<int> listIntSeries) // Gets a list of integers and checks if the list contains at least three numbers. 

        {
            if (listIntSeries.Count < 3)
            {
                Console.WriteLine("ERROR - Fewer than three numbers entered! ");
                return false;
            }
            return true;
        }


        static void InputNum() // Receives an array of strings from the user.
        {
            Console.WriteLine("Please enter at least three positive numbers:");
            string[] arrayStrSeries = Console.ReadLine().Split(' ');

            Start(arrayStrSeries);
        }



        static List<int> ListStrToListInt(List<string> listStrSeries)      // Receives a list of strings and converts it to a list of integers.

        {
            List<int> listIntSeries = new List<int>();
            foreach (var val in listStrSeries)
            {
                listIntSeries.Add(Convert.ToInt32(val));
            }

            return listIntSeries;
        }
        static void Menu()
        {
            Console.WriteLine("\nPlease select one of the following options: \n" +
                "\n1. Enter a new series of numbers" +
                "\n2. Display numbers in the order they were entered" +
                "\n3. Display numbers from end to beginning" +
                "\n4. Display numbers from smallest to largest" +
                "\n5. Display the largest number" +
                "\n6. Display the smallest number" +
                "\n7. Display the average of the numbers" +
                "\n8. Display the number of elements in the series" +
                "\n9. Display the sum of the elements in the series" +
                "\n10. Exit\n");
        }
        static void MakingChoice(List<int> listIntSeries)
        {
            string choice = Console.ReadLine();
            Console.WriteLine("");

            switch (choice)
            {
                case "1":
                    InputNum();
                    break;

                case "2":
                    DisplayInOrder(listIntSeries);
                    break;

                case "3":
                    DisplayFromEnd(listIntSeries);
                    break;

                case "4":
                    DisplayFromSmallest(listIntSeries);
                    break;

                case "5":
                    LargestNumber(listIntSeries);
                    break;

                case "6":
                    SmallestNumber(listIntSeries);
                    break;

                case "7":
                    Average(listIntSeries);
                    break;

                case "8":
                    NumberOfElements(listIntSeries);
                    break;

                case "9":
                    SumOfElements(listIntSeries);
                    break;

                case "10":
                    Console.WriteLine("good bye! ");
                    flag = false;
                    break;

                default:
                    Console.WriteLine("ERROR - Invalid input was entered!");
                    break;


            }
        }


        static void DisplayInOrder(List<int> listIntSeries) // Display numbers in the order they were entered
        {
            foreach (var num in listIntSeries)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine("\n");
        }


        static void DisplayFromEnd(List<int> listIntSeries) // Display numbers from end to beginning.
        {
            for (int i = listIntSeries.Count - 1; i >= 0; i--)
            {
                Console.Write($"{listIntSeries[i]} ");
            }
            Console.WriteLine("\n");
        }


        static void DisplayFromSmallest(List<int> listIntSeries) // Display numbers from smallest to largest.

        {
            foreach (int num in OptimalBubbleSorting(listIntSeries))
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine("");
        }

        static void LargestNumber(List<int> listIntSeries)   //Display the largest number.
        {
            Console.Write($"The largest number on the list is: " +
                $" {OptimalBubbleSorting(listIntSeries)[listIntSeries.Count - 1]}\n");
        }

        static void SmallestNumber(List<int> listIntSeries)  //Display the smallest number.
        {
            Console.Write($"The smallest number on the list is: " +
                $"{OptimalBubbleSorting(listIntSeries)[0]}\n");
        }
        static void Average(List<int> listIntSeries)   //Display the average of the numbers.
        {
            int average = SumOfElements(listIntSeries) / listIntSeries.Count;

            Console.Write($"The average of the numbers in the list is: {average} \n");
        }
        static void NumberOfElements(List<int> listIntSeries) //Display the number of elements in the series
        {
            Console.Write($"The number of members in the list is: " +
                $"{listIntSeries.Count} \n");
        }
        static int SumOfElements(List<int> listIntSeries)  // Display the sum of the elements in the series.
        {
            int sum = 0;
            foreach (int num in listIntSeries)
                sum += num;
            return sum;
        }

        static List<int> OptimalBubbleSorting(List<int> listIntSeries)
        {
            List<int> sortSeries = listIntSeries;
            int temp = 0;
            bool flag;
            for (int i = 0; i < sortSeries.Count; i++)
            {
                flag = true;

                for (int j = 0; j < sortSeries.Count - i - 1; j++)
                {
                    if (sortSeries[j] > sortSeries[j + 1])
                    {
                        temp = sortSeries[j];
                        sortSeries[j] = sortSeries[j + 1];
                        sortSeries[j + 1] = temp;
                        flag = false;
                    }
                }
                if (flag)
                    return sortSeries;
            }
            return sortSeries;
        }
    }
}


















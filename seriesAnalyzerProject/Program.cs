using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace seriesAnalyzerProject
{
    internal class Program
    {

        static void Main(string[] args) // Receives an array of strings and runs a conversion function to a list of strings with the received value.
        {
            Start(args);
        }

        static void Start(string[] arrayStrSeries)
        {
            List<string> listStrSeries = new List<string>();
            List<int> listint = new List<int>();

            listStrSeries = ArrayToList(arrayStrSeries);


            if (ValidIsFull(listStrSeries) && ValidInt(listStrSeries))
            {
                listint = ListStrToListInt(listStrSeries);

                if (ValidPositive(listint) && ValidThree(listint))
                {
                    Menu();
                    MakingChoice(listint);
                }
            }
            else
            {
                InputNum();
            }















        }

        static List<string> ArrayToList(string[] seriesNumbers) // Takes an array of strings and converts it to a list of strings.
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
            bool full = true;

            if (listStrSeries.Count == 0)
            {
                full = false;
                ErrorMessage(1);
            }
            return full;

        }


        static bool ValidInt(List<string> listStrSeries) // Receives a list of strings and confirms that all iterations contain only numbers.
        {
            foreach (var val in listStrSeries)
            {
                if (!int.TryParse(val, out int num))
                {
                    ErrorMessage(2);
                    return false;
                }
            }
            return true;
        }

        static bool ValidPositive(List<int> listIntSeries) // Receives a list of integers and checks if all numbers in the list are positive.
        {
            foreach (var val in listIntSeries)
            {
                if (val < 0)
                {
                    ErrorMessage(3);
                    return false;
                }
            }
            return true;
        }


        static bool ValidThree(List<int> listIntSeries) // Gets a list of integers and checks if the list contains at least three numbers. 
        {
            if (listIntSeries.Count < 3)
            {
                ErrorMessage(4);
                return false;
            }
            return true;

        }

        static void ErrorMessage(int num)
        {
            switch (num)
            {
                case 1:
                    Console.WriteLine("ERROR - No number entered! ");
                    break;
                case 2:
                    Console.WriteLine("ERROR - The value entered is not a number! ");
                    break;
                case 3:
                    Console.WriteLine("ERROR - The number entered is not a positive number! ");
                    break;
                case 4:
                    Console.WriteLine("ERROR - Fewer than three numbers entered! ");
                    break;
                default:
                    // code block
                    break;
            }
        }
        static void InputNum() // Receives an array of strings from the user.
        {
            Console.WriteLine("Please enter at least three positive numbers:");
            string[] arrayStrSeries = Console.ReadLine().Split(' ');

            Start(arrayStrSeries);
        }
        static List<int> ListStrToListInt(List<string> listStrSeries) // Receives a list of strings and converts it to a list of integers.
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
        static void MakingChoice(List<int> listNum)
        {
            string choice = Console.ReadLine();
            Console.WriteLine("");

            switch (choice)
            {
                case "1":
                    InputNum();
                    break;
                case "2":
                    DisplayInOrder(listNum);
                    Menu();
                    MakingChoice(listNum);
                    break;
                case "3":
                    DisplayFromEnd(listNum);
                    Menu();
                    MakingChoice(listNum);
                    break;
                case "4":
                    DisplayFromSmallest(listNum);
                    Menu();
                    MakingChoice(listNum);
                    break;
                case "5":
                    LargestNumber(listNum);
                    Menu();
                    MakingChoice(listNum);
                    break;
                case "6":
                    SmallestNumber(listNum);
                    Menu();
                    MakingChoice(listNum);
                    break;
                case "7":
                    Average(listNum);
                    Menu();
                    MakingChoice(listNum);
                    break;
                case "8":
                    NumberOfElements(listNum);
                    Menu();
                    MakingChoice(listNum);
                    break;
                case "9":
                    SumOfElements(listNum);
                    Menu();
                    MakingChoice(listNum);
                    break;

                case "10":
                    Console.WriteLine("good bye :) ");
                    break;

                default:
                    Console.WriteLine("Please enter a valid input: ");
                    Menu();
                    MakingChoice(listNum);
                    break;

            }
        }


        static void DisplayInOrder(List<int> listint) //Display numbers in the order they were entered
        {
            foreach (var num in listint)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine("\n");
        }

        static void DisplayFromEnd(List<int> listint)   //Display numbers from end to beginning.
        {
            for (int i = listint.Count - 1; i >= 0; i--)
            {
                Console.Write($"{listint[i]} ");
            }
            Console.WriteLine("\n");
        }

        static void DisplayFromSmallest(List<int> listint)  //Display numbers from smallest to largest.
        {
            foreach (int num in BubbleSort(listint))
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine("");
        }

        static void LargestNumber(List<int> listint)   //Display the largest number.
        {
            Console.Write($"The largest number on the list is: {BubbleSort(listint)[listint.Count - 1]}\n");
        }

        static void SmallestNumber(List<int> listint)  //Display the smallest number.
        {
            Console.Write($"The smallest number on the list is: {BubbleSort(listint)[0]}\n");
        }
        static void Average(List<int> listint)   //Display the average of the numbers.
        {
            int average = SumOfElements(listint) / listint.Count;
            Console.Write($"The average of the numbers in the list is: {average} \n");
        }
        static void NumberOfElements(List<int> listint) //Display the number of elements in the series
        {
            Console.Write($"The number of members in the list is: {listint.Count} \n");
        }
        static int SumOfElements(List<int> listint)  // Display the sum of the elements in the series.
        {
            int sum = 0;
            foreach (int num in listint)
                sum += num;
            return sum;
        }

        static List<int> BubbleSort(List<int> listint)
        {
            List<int> sortSeries = listint;
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
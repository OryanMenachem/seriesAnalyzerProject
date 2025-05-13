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
            List<string> listStrSeries =  AraayToList(arrayStrSeries);
            
            ValidEmpty(listStrSeries);
            
            List<int> listint;

            ValidInt(listStrSeries);
            
            ListStrToListInt(listStrSeries);
            
            listint = ListStrToListInt(listStrSeries);
            
            ValidPositive(listint);
            
            ValidThree(listint);
            
            Menu();
            
            MakingChoice(listint);
        }

        static List<string> AraayToList(string[] seriesNumbers) // Takes an array of strings and converts it to a list of strings.
        {
            List<string> ListStrSeries = new List<string>();

            foreach (var val in seriesNumbers)
            {
                ListStrSeries.Add(val);
            }
            
            return ListStrSeries;
        }





        static void InputNum() // Receives an array of strings from the user.
        {
            Console.WriteLine("Please enter at least three positive numbers:");
            string[] seriesNumbers = Console.ReadLine().Split(' ');

            Start(seriesNumbers);
        }




        static void ValidEmpty(List<string> ListStrSeries)
        {
            if (ListStrSeries.Count == 0)
            {
                Console.WriteLine("No number entered");
                InputNum();
            }

        }

        static void ValidInt(List<string> ListStrSeries) // Receives a list of strings and confirms that all iterations contain only numbers.
        {
            foreach (var val in ListStrSeries)
            {

                if (!int.TryParse(val, out int num))
                {
                    Console.WriteLine($"The value {val} is not a number!");
                    InputNum();
                }

            }
        } 

        static List<int> ListStrToListInt(List<string> ListStrSeries) // Receives a list of strings and converts it to a list of integers.
        {
            List<int> ListIntSeries = new List<int>();
            foreach (var val in ListStrSeries)
            {
                ListIntSeries.Add(Convert.ToInt32(val));
            }
            return ListIntSeries;
        }

        static void ValidPositive(List<int> ListIntSeries) // Receives a list of integers and checks if all numbers in the list are positive.
        {
            foreach (var val in ListIntSeries)
            {
                if (val < 0)
                {
                    Console.WriteLine($"The number {val} is not a positive number.");
                    InputNum();
                }
            }
        }

        static void ValidThree(List<int> ListIntSeries) // Gets a list of integers and checks if the list contains at least three numbers. 
        {
             if (ListIntSeries.Count < 3)
                InputNum();
        }

        static void Menu()
        {
            Console.WriteLine("Please select one of the following options:" +
                "\n1. Enter a new series of numbers" +
                "\n2. Display numbers in the order they were entered" +
                "\n3. Display numbers from end to beginning" +
                "\n4. Display numbers from smallest to largest" +
                "\n5. Display the largest number" +
                "\n6. Display the smallest number" +
                "\n7. Display the average of the numbers" +
                "\n8. Display the number of elements in the series" +
                "\n9. Display the sum of the elements in the series" +
                "\n10. Exit");
        }
        static void MakingChoice(List<int> listNum)
        {
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    InputNum();
                    break;
                case "2":
                    DisplayInOrder(listNum);
                    break;
                case "3":
                    DisplayFromEnd(listNum);
                    break;
                case "4":
                    DisplayFromSmallest(listNum);
                    break;
                case "5":
                    LargestNumber(listNum);
                    break;
                case "6":
                    SmallestNumber(listNum);
                    break;
                case "7":
                    Average(listNum);
                    break;
                case "8":
                    NumberOfElements(listNum);
                    break;
                case "9":
                    SumOfElements(listNum);
                    break;
             
                case "10":
                    break;
                default:
                    Menu();
                    MakingChoice(listNum);
                    break;

            }
        }


        static void DisplayInOrder(List<int> listint) //Display numbers in the order they were entered
        {
            foreach (var num in listint)
            {
                Console.Write($" {num}");
            }
        }

        static void DisplayFromEnd(List<int> listint)   //Display numbers from end to beginning.
        {
            for (int i = listint.Count - 1; i >= 0; i--)
            {
                Console.Write($" {listint[i]}");
                    
            }
        }

        static void DisplayFromSmallest(List<int> listint)  //Display numbers from smallest to largest.
        {
            foreach (int num in BubbleSort(listint))
            { 
                Console.Write($" {num}"); 
            }

        }

        static void LargestNumber (List<int> listint)   //Display the largest number.
        {
            Console.Write("The largest number on the list is: ");
            Print(BubbleSort(listint)[listint.Count - 1]);
            //return BubbleSort(listint)[listint.Count -1];
        }
        static void SmallestNumber(List<int> listint)  //Display the smallest number.
        {
            Console.Write("The smallest number on the list is: ");
            Print(BubbleSort(listint)[0]);
            //return BubbleSort(listint)[0];
        }
        static void Average(List<int> listint)   //Display the average of the numbers.
        {
            Console.Write("The average of the numbers in the list is: ");
            Print(SumOfElements(listint) / listint.Count);
            //return sumOfElements(listint) / listint.Count;
        }
        static void NumberOfElements (List<int> listint) //Display the number of elements in the series
        {
            Console.Write("The number of members in the list is: ");
            Print(listint.Count);
            //return listint.Count;
        }
        static int SumOfElements(List<int> listint)  // Display the sum of the elements in the series.
        {
          int sum = 0;
            foreach (int num in listint)
                sum += num;
            Console.Write("The sum of all the elements in the list is: ");
            Print(sum);
            return sum;
        }

        static List<int> BubbleSort(List<int> listint)
        {
            int temp = 0;
            bool flag;
            for (int i = 0; i < listint.Count; i++)
            {
                flag = true;

                for (int j = 0; j < listint.Count - i - 1; j++)
                {
                    if (listint[j] > listint[j + 1])
                    {
                        temp = listint[j];
                        listint[j] = listint[j + 1];
                        listint[j + 1] = temp;
                        flag = false;
                    }
                }
                if (flag)
                    return listint;
            }
            return listint;
        }

        static void Print(int Write)
        { 
            Console.WriteLine(Write); 
        }
    }
}










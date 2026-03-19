using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] daysInAWeek = { "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
            int[] daysInAMonth = { 31, 28 };

            
            int[] startDay = { 3, 6 }; 


            Console.Write("January\t\t\t February");
            Console.WriteLine();
            
            for (int m = 0; m < 2; m++)
            {
                for (int d = 0; d < 7; d++)
                    Console.Write($"{daysInAWeek[d],2} ");
                Console.Write("\t");
            }
            Console.WriteLine();

            int day1 = 1;
            int day2 = 1; 

       
            for (int week = 0; week < 6; week++)
            {
                // Январь
                for (int i = 0; i < 7; i++)
                {
                    
                    if (week == 0 && i < startDay[0])
                    {
                        Console.Write("   ");
                        continue;
                    }

                    if (day1 <= 31)
                        Console.Write($"{day1++,2} ");
                    else
                        Console.Write("   ");
                }
                Console.Write("\t");

                // Февраль
                for (int i = 0; i < 7; i++)
                {
                    
                    if (week == 0 && i < startDay[1])
                    {
                        Console.Write("   ");
                        continue;
                    }

                    if (day2 <= 28)
                        Console.Write($"{day2++,2} ");
                    else
                        Console.Write("   ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] daysInAWeek = { "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
            int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] monthNames = {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December" };

            int[] startDay = { 3, 6, 6, 2, 4, 0, 2, 5, 1, 3, 6, 1 };

            int day = 1;


            int month = int.Parse(Console.ReadLine());
            Console.Write("Calendar 2026 year\n");
            Console.WriteLine();
            Console.Write($"\t{monthNames[month-1],2} \n");
            for (int m = 0; m < 1; m++)
            {
                for (int d = 0; d < 7; d++)
                    Console.Write($"{daysInAWeek[d],2} ");
                Console.Write("\t");
            }
            Console.WriteLine();

            for (int week = 0; week < 6; week++)
            {
               
                for (int i = 0; i < 7; i++)
                {
                  
                    if (week == 0 && i < startDay[month-1])
                    {
                        Console.Write("   ");
                        continue;
                    }

                    if (day <= daysInMonths[month-1])
                        Console.Write($"{day++,2} ");
                    else
                        Console.Write("   ");
                }
                Console.Write("\n");
            }
        }
     }
}

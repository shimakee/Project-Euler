using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 1.\nGet multiples of 3 & 5 below what number?");
            string input = Console.ReadLine();
            int maxNumber;
            Int32.TryParse(input, out maxNumber);

            List<int> intList = new List<int>();

            for (int i = 0; i < maxNumber; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    intList.Add(i);
                }
            }

            int total = 0;

            foreach (var number in intList)
            {
                total += number;
            }

            Console.WriteLine(total);
            Console.ReadLine();

        }
    }
}

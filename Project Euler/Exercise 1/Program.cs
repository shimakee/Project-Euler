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
            Console.WriteLine("Exercise 2.\nGet even fibonacci numbers.");
            Console.WriteLine("Max fibonacci number?");
            string input = Console.ReadLine();
            int maxNumber;
            Int32.TryParse(input, out maxNumber);

            List<int> intList = new List<int>() { 0, 1 };
            int total = 0;

            for (int i = 0; intList[i] < maxNumber; i++)
            {

                if (i == 0)
                    continue;

                int n = intList[i] + intList[i - 1];

                intList.Add(n);

                if (n % 2 == 0)
                    total += n;
            }

            Console.WriteLine(total);
            Console.ReadLine();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherYatesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Random random = new Random();
            array = array.OrderBy(x => random.Next()).ToArray();
            foreach (var i in array)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}

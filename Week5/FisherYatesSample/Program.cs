using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherYatesSample
{
    class Program
    {
        /// <summary>
        /// In this example, I created a simple array along with a "random" variable that would suffle in this case.
        /// The numbers listed are from 1 through 5 and they will be randomly shuffled when the application is being run.
        /// </summary>
        /// <param name="args"></param>
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

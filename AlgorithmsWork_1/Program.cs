using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Integer to test
            int[] testArray = new int[5000];

            //Using the constant O(1) notation
            BigO1(testArray);

            //Using the linear O(n) notation
            BigOn(testArray);

            //Using the quadratic O(n^2) notation
            BigOn2(testArray);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        //This method will output the constant O(1) notation. The result will be 1.
        //Since the initial integer starts at 5000, the output will always be 1.
        static void BigO1(int[] inArray)
        {
            int loopCount = 0;
            inArray[0] = 1;
            loopCount++;
            Console.WriteLine("O(1) complete in " + loopCount.ToString() + " steps.");
        }

        //This method will output the linear O(n) notation. The result will be 5000.
        //Since the integer "n" is equal to 5000, the output of O(n) will always be 5000
        static void BigOn(int[] inArray)
        {
            int loopCount = 0;

            for (int i = 0; i < inArray.Length; i++)
            {
                loopCount++;
                inArray[i] = 1;
            }
            Console.WriteLine("O(n) complete in " + loopCount.ToString() + " steps.");
            return;
        }

        //This method will output the quadratic O(n^2) notation. The result will be 25000000
        //This output will square the result of "n" resulting in 25000000.
        static void BigOn2(int[] inArray)
        {
            int loopCount = 0;
            for (int i = 0; i < inArray.Length; i++)
            {
                for (int j = 0; j < inArray.Length; j++)
                {
                    loopCount++;
                }
            }
            Console.WriteLine("O(n^2) complete in " + loopCount.ToString() + " steps.");
        }
    }
}

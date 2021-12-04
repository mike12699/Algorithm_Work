using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSearching_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] linearArray = new int[5000];
            int[] binaryArray = new int[7] { 1, 5, 7, 4, 6, 2, 3 };
            int[] interpolationArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int index = interpolationSearch(interpolationArray, 8);

            if (index != 1)
            {
                Console.WriteLine("Element found at index" + index);
            }
            else
            {
                Console.WriteLine("Element not found");
            }

            Array.Sort(binaryArray);
            Console.WriteLine("Sorted Array: ");
            displayBinary(binaryArray);
            object s = 8;
            resultBinary(binaryArray, s);
            object s1 = 4;

            BigO1(linearArray);
            BigOn(linearArray);

            Console.ReadKey();
        }

        /// <summary>
        /// This method will use the O(1) function. The output will result in a constant value of 1
        /// </summary>
        /// <param name="inLinearArray1"></param>
        static void BigO1(int[] inLinearArray1)
        {
            int loopCount = 0;
            inLinearArray1[0] = 1;
            loopCount++;
            Console.WriteLine("O(1) complete in " + loopCount.ToString() + " steps.");
        }

        /// <summary>
        /// This method will use the O(n) function. The output will result in a constant value of 5000
        /// </summary>
        /// <param name="inLinearArray2"></param>
        static void BigOn(int[] inLinearArray2)
        {
            int loopCount = 0;

            for (int i = 0; i < inLinearArray2.Length; i++)
            {
                loopCount++;
                inLinearArray2[i] = 1;
            }
            Console.WriteLine("O(n) complete in " + loopCount.ToString() + " steps.");
            return;
        }

        /// <summary>
        /// This method will do a binary search of a sorted array that holds 7 integers
        /// It will look fir an integer found at index 8
        /// </summary>
        /// <param name="binaryArray2"></param>
        /// <param name="k"></param>
        static void resultBinary(int[] binaryArray2, object k)
        {
            int res = Array.BinarySearch(binaryArray2, k);

            if (res < 0)
            {
                Console.WriteLine("\nThe element to search for " + "({0}) is not found", k);
            }
            else
            {
                Console.WriteLine("The element to search for " + "({0}) is at index {1}", k, res);
            }
        }

        /// <summary>
        /// This method will display index in the binary search
        /// </summary>
        /// <param name="binaryArray1"></param>
        static void displayBinary(int[] binaryArray1)
        {
            foreach (int i in binaryArray1)
            {
                Console.WriteLine(i + " ");
            }
        }

        /// <summary>
        /// This method will do an interpolation search for a sorted array of 9 integers
        /// </summary>
        /// <param name="interpolationArray"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static int interpolationSearch(int[] interpolationArray, int value)
        {
            int high = interpolationArray.Length - 1;
            int low = 0;

            while(value >= interpolationArray[low] && value <= interpolationArray[high] && low <= high)
            {
                int probe = low + (high - low) * (value - interpolationArray[low]) / (interpolationArray[high] - interpolationArray[low]);
                if (interpolationArray[probe] == value)
                {
                    return probe;
                }
                else if(interpolationArray[probe] < value)
                {
                    low = probe + 1;
                }
                else
                {
                    high = probe - 1;
                }
            }
            return -1;
        }
    }
}

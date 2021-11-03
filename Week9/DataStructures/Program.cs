using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the method to call the stack and queue variables

            Stack<string> stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            Console.WriteLine(stack.Peek());
            stack.Pop();
            Console.WriteLine(stack.Peek());

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            Console.WriteLine(queue.Peek());
            queue.Dequeue();
            Console.WriteLine(queue.Peek());


            //Calls over the ArraysandDictionaries class
            var collections = new ArraysandDictionaries();
            collections.ArrayFunction();
            collections.DictionaryFunction();

            Console.ReadLine();
        }
    }
}

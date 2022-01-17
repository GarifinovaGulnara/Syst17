using System;
using System.Threading.Tasks;

namespace Syst17
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            Task<int[]> taskGen = new Task<int[]>(() => Generation(array));
            Task<int[]> task2 = taskGen.ContinueWith(doublearr => doubleArray(doublearr.Result));
            Task task3 = task2.ContinueWith(buff => Summ(buff.Result));
            taskGen.Start();
            task2.Wait();
        }

        static int[] Generation(int[] array)
        {
            Random rnd = new Random();
            for (int i=0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 10);
            }
            return array;
        }

        static int[] Summ(int[] array)
        {
            int buff = 0;
            foreach (var item in array)
            {
                buff += item; 
            }
            Console.WriteLine(" ");
            Console.WriteLine(buff);
            return array;
        }

        static int[] doubleArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= 2;
                Console.Write(array[i]+" ");
            }
            return array;
        }
    }
}

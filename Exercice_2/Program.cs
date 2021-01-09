using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace DesignPattern_Project
{
    class Program
    {
        static void Output_Array(int[,] mat)
        {
            for (int a = 0; a < mat.GetLength(0); a++)
            {
                for (int b = 0; b < mat.GetLength(1); b++)
                {
                    if (mat[a, b] > 9)
                        Console.Write(mat[a, b] + " ");
                    else
                        Console.Write(mat[a, b] + "  ");
                }
                Console.WriteLine();
            }
        }
        static int[,] RandomArray(int rows, int cols)
        {
            int[,] array = new int[rows, cols];
            
            Random rnd = new Random();
            for (int a = 0; a < rows; a++)
            {
                for (int b = 0; b < cols; b++)
                {
                    array[a, b] = rnd.Next(1, 11);
                }
            }
            return array;
        }
        static int[] get_row(int[,] mat, int row)
        {
            int[] result = new int[mat.GetLength(1)];
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                result[i] = mat[row, i];
            }
            Console.WriteLine(result.ToString());
            return result;
        }

        
        private static Dictionary<int, int> Reduce(List<Dictionary<int, int>> dictionaries)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach (Dictionary<int, int> d in dictionaries)
            {
                foreach (var x in d)
                {
                    if (result.ContainsKey(x.Key))
                        result[x.Key] += x.Value;
                    else
                        result[x.Key] = x.Value;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Generating random matrix...");
            // generate Matrix with the size as input
            int[,] arrTest = RandomArray(5, 5);
            Console.WriteLine("Generated matrix : ");
            Output_Array(arrTest);

            Console.WriteLine("\nDoing MapReduce...");
            int rows = arrTest.GetLength(1);
            ClusterTask[] tasks = new ClusterTask[rows];
            Thread[] t = new Thread[rows];

            // Doing the mapping part. 
            for (int i = 0; i < rows; i++)
            {
                tasks[i] = new ClusterTask(get_row(arrTest, i));
                t[i] = new Thread(new ThreadStart(tasks[i].execute));
                t[i].Start();

            }

            // We need to wait for the threads to end.
            foreach (Thread th in t)
                th.Join();

            // We will collect the results of each thread or node. 
            List<Dictionary<int, int>> results = new List<Dictionary<int, int>>();
            for (int i = 0; i < rows; i++)
            {
                results.Add(tasks[i].GetResults());
            }

            // Doing the Reduce part for our dictionary. 
            Dictionary<int, int> final = Reduce(results);

            // Printing the dictionary ordered by the key.   
            var list = final.Keys.ToList();
            list.Sort();

            // Looping through our keys.
            foreach (var key in list)
            {
                Console.WriteLine("Number = {0}, Occurence = {1}", key, final[key]);
            }

            Console.ReadKey();
        }
    }
}


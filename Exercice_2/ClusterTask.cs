using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DesignPattern_Project
{
    class ClusterTask
    {
        private int[] array;
        private Dictionary<int, int> results;
        public ClusterTask(int[] array)
        {
            this.array = array;
            results = new Dictionary<int, int>();
        }
        public void execute()
        {
            int rows = array.Length;

            for (int a = 0; a < rows; a++)
            {
                int val = array[a];

                if (results.ContainsKey(val))
                {
                    results[val] = results[val] + 1;
                }
                else
                {
                    results[val] = 1;
                }
            }
        }
        public Dictionary<int, int> GetResults()
        {
            return results;
        }
    }
}

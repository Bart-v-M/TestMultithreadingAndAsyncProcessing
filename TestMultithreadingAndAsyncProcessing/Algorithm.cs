using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultithreadingAndAsyncProcessing
{
    public class Algorithm
    {
        public double computeAverages(long numOfValues)
        {
            double total = 0;
            Random random = new Random();

            for (long values = 0; values < numOfValues; values++)
            {
                total += random.NextDouble();
            }

            return total / numOfValues;
        }
    }
}

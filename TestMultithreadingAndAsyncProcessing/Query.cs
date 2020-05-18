using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultithreadingAndAsyncProcessing
{
    public class Query
    {
        public void UseAsParallel(List<string> listOfCellContent)
        {
            for (int i = 0; i < 9999999; i++)
            {
                //// Test #1
                //var result = from content in listOfCellContent.AsParallel()
                //             select content;

                // Test #2
                var result = from content in listOfCellContent.AsParallel()
                             select content;
            }
        }

        public void UseForceParallelism(List<string> listOfCellContent)
        {
            for (int i = 0; i < 9999999; i++)
            {
                //// Test #1
                //var result = from content in listOfCellContent.AsParallel()
                //                                .WithDegreeOfParallelism(4)
                //                                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                //             select content;

                // Test #2
                var result = from content in listOfCellContent.AsParallel()
                                                .WithDegreeOfParallelism(4)
                                                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                             select content;
            }
        }

        public void UseAsSequential(List<string> listOfCellContent)
        {
            var result = from content in listOfCellContent.AsParallel()
                         select content;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun_with_SystemGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********* Fun with System.GC *********");
            Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));

            Console.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));
            Car refToMyCar = new Car("Zippy", 100, 200);
            Console.WriteLine(refToMyCar.ToString());
            Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));
        }
    }
}

using System;
using System.Diagnostics;
using System.Threading;

namespace OOP07SolidPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Thread.Sleep(100);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            int a = int.MaxValue;
            try
            {
                a +=  0; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            uint y = (uint)a + 1;
            int x;
            try
            {
                x = int.Parse(y.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw new ArgumentException();  stop the program
            }

            try
            {
                int.TryParse(y.ToString(), out x);
            }
            catch (Exception)
            {
                //TryParse handle the exeption and the code is executed
                throw;
            }

            Console.WriteLine($"x = {x}");

            uint z = (uint)x;
            if (uint.TryParse(a.ToString(), out z))
            {
                Console.WriteLine($"z = {z}");
            }
            
        }
    }
}

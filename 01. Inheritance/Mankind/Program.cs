using System;

namespace Mankind
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var studentArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(studentArgs[0], studentArgs[1], studentArgs[2]);
                Console.WriteLine(student.ToString());

                var workerArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Worker worker = new Worker(workerArgs[0], workerArgs[1], decimal.Parse(workerArgs[2]), decimal.Parse(workerArgs[3]));
                Console.WriteLine(worker.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

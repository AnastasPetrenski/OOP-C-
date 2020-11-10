
using WildFarm.Engine.Contracts;

namespace WildFarm.Engine
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}

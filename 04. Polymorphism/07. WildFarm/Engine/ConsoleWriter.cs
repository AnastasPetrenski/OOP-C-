
using WildFarm.Engine.Contracts;

namespace WildFarm.Engine
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            System.Console.Write(text);
        }

        public void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }

        public void WriteLine()
        {
            System.Console.WriteLine();
        }
    }
}

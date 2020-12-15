using Moq;
using System;

namespace Container
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            Axe axe = new Axe(100, 0);
            Dummy dummy = new Dummy(100, 100);

            try
            {
                axe.Attack(dummy);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

             
        }


    }


}

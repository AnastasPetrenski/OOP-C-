using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    [Author("Peio")]
    public class Tracker
    {
        [Author("Pesho")]
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);

            //var type = Assembly.GetExecutingAssembly().GetTypes();
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(typeof(AuthorAttribute));
                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine("{0} is writen by {1}", method.Name, attribute.Name);
                    }


                }
            }

        }
    }
}

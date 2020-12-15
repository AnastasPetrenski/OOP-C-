using System;
using System.Reflection;

namespace AuthorProblem
{
    [Author("Nasko")]
    public class StartUp
    {
        [Author("Paq")]
        [Author("Paqlani")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();

            tracker.PrintMethodsByAuthor();

            var allTypes = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in allTypes)
            {
                var methods = type.GetMethods();
                var attrs = type.GetCustomAttributes(typeof(AuthorAttribute));
                foreach (AuthorAttribute item in attrs)
                {
                    Console.WriteLine($"{type.Name} {item.Name} ");
                }

                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes();
                    foreach (var item in attributes)
                    {
                        if (item.GetType().Name == "AuthorAttribute")
                        {
                            Console.WriteLine(((AuthorAttribute)item).Name);
                        }
                    }
                }
            }
        }

        [Author("Baj Mangal")]
        public void Print()
        {

        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}

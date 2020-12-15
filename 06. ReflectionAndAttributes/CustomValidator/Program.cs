using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CustomValidator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat();
            cat.Name = "Nasko";
            cat.Age = 22;
            cat.Color = "Black";

            var validator = new ObjectValidator();

            var result = validator.Validate(cat);

            Console.WriteLine(result.IsValid ? "Valid" : "Invalid");

            foreach (var error in result.Error)
            {
                Console.WriteLine(error.Key);
                foreach (var errorMsg in error.Value)
                {
                    Console.WriteLine($"---{errorMsg}");
                }

            }

            var attr = cat.GetType().GetProperties();
            foreach (var item in attr)
            {
                var propertyValue = item.GetValue(cat);
                Console.WriteLine($"type:{item.PropertyType}, Name:{item.Name}, Value:{propertyValue}"); 
                var x = item.GetCustomAttributes(true);

                //foreach (var itemx in x)
                //{
                //    if (itemx.GetType().Name == "RangeAttribute")
                //    {
                //        Console.WriteLine($"{itemx.GetType().Name} - {((RangeAttribute)itemx).IsValid(cat.Age)} - {((RangeAttribute)itemx).Min}:{((RangeAttribute)itemx).Max}");
                //    }
                //    else if (itemx.GetType().Name == "StringLengthAttribute")
                //    {
                //        Console.WriteLine($"{itemx.GetType().Name} - {((StringLengthAttribute)itemx).IsValid(cat.Name)}");
                //    }
                //    else 
                //    {
                //        Console.WriteLine($"{itemx.GetType().Name} - {((RequiredAttribute)itemx).IsValid(cat.Color)} ");
                //    }
                    
                //}
            }


        }
    }
}

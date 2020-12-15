namespace HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var types = Type.GetType("HarvestingFields");
            var type = typeof(HarvestingFields);
            IEnumerable<FieldInfo> fields = null;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                if (command == "private")
                {
                    fields = GetPrivateFields(type);
                }
                else if (command == "protected")
                {
                    fields = GetProtectedFields(type);
                }
                else if (command == "protected")
                {
                    fields = GetPublicFields(type);
                }
                else if (true)
                {
                    fields = GetAllFields(type);
                }
            }

            foreach (var field in fields)
            {
                string accessModifier = field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected";
                Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
            }
        }

        private static IEnumerable<FieldInfo> GetAllFields(Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
        }

        private static IEnumerable<FieldInfo> GetPublicFields(Type type)
        {
            return type.GetFields(BindingFlags.Instance | BindingFlags.Public).Where(f => f.IsPublic);
        }

        private static IEnumerable<FieldInfo> GetProtectedFields(Type type)
        {
            return type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.IsFamily);
        }

        private static IEnumerable<FieldInfo> GetPrivateFields(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.IsPrivate);
            return fields;
        }
    }
}

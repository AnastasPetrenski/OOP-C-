using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            var sb = new StringBuilder();
            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb
                .AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {

                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");

            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            var sb = new StringBuilder();

            Type classType = Type.GetType(className);

            var fields = classType.GetFields();

            foreach (var item in fields)
            {
                if (item.IsPublic)
                {
                    sb.AppendLine($"{item.Name} must be private!");
                };
            }

            var properties = classType.GetProperties();

            var classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be public!");

            }

            var classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            //Type type = className.GetType();
            Type type = Type.GetType(className);
            var baseClass = type.BaseType;
            var allPrivateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic );

            var sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base class {baseClass}");
            foreach (var item in allPrivateMethods)
            {
                sb.AppendLine(item.Name);
            }

            return (sb.ToString().Trim());
        }

        public string CollectGetterAndSetter(string className)
        {
            Type type = Type.GetType(className);
            var allMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Dictionary<string, List<MethodInfo>> results = new Dictionary<string, List<MethodInfo>>();
            foreach (var method in allMethods)
            {
                if (method.Name.StartsWith("get"))
                {
                    if (!results.ContainsKey("get"))
                    {
                        results.Add("get", new List<MethodInfo>());
                    }

                    results["get"].Add(method);
                }
                else if (method.Name.StartsWith("set"))
                {
                    if (!results.ContainsKey("set"))
                    {
                        results.Add("set", new List<MethodInfo>());
                    }

                    results["set"].Add(method);
                }
            }

            var sb = new StringBuilder();

            foreach (var method in results.Where(m => m.Key == "get"))
            {
                foreach (var item in method.Value)
                {
                    sb.AppendLine($"{item.Name} will return {item.ReturnType}");
                }
                
            }

            foreach (var method in results.Where(m => m.Key == "set"))
            {
                foreach (var item in method.Value)
                {
                    var parameters = item.GetParameters();
                    foreach (var parameter in parameters)
                    {
                        sb.AppendLine($"{item.Name} will set field of {parameter.ParameterType}");
                    }
                    
                }
            }

            return sb.ToString().Trim();
        }
    }
}

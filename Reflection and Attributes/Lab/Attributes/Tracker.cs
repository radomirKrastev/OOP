using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(Program);

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Static 
            | BindingFlags.Instance 
            | BindingFlags.Public 
            | BindingFlags.NonPublic);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes();

                foreach (AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine("{0} is written by {1}", method.Name, attribute.Name);
                }                
            }
        }
    }
}
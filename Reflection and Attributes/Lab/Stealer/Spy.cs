using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsNames)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Public
            | BindingFlags.NonPublic
            | BindingFlags.Instance
            | BindingFlags.Static);

        var output = new StringBuilder();

        object classInstance = Activator.CreateInstance(classType, new object[] { });

        output.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in classFields.Where(f => fieldsNames.Contains(f.Name)))
        {
            output.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return output.ToString().TrimEnd();
    }
}


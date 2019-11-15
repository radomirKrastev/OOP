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

        StringBuilder output = new StringBuilder();

        object classInstance = Activator.CreateInstance(classType, new object[] { });

        output.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in classFields.Where(f => fieldsNames.Contains(f.Name)))
        {
            output.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return output.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Static 
            | BindingFlags.Instance 
            | BindingFlags.Public);

        MethodInfo[] classPublicMethods = classType.GetMethods(
            BindingFlags.Static 
            | BindingFlags.Instance 
            | BindingFlags.Public);

        MethodInfo[] classNonPublicMethods = classType.GetMethods(
            BindingFlags.Static 
            | BindingFlags.Instance
            | BindingFlags.NonPublic);

        object classInstance = Activator.CreateInstance(classType);

        var result = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo nonPublicProperty in classNonPublicMethods.Where(p => p.Name.StartsWith("get")))
        {
            result.AppendLine($"{nonPublicProperty.Name} have to be public!");
        }

        foreach (MethodInfo publicProperty in classPublicMethods.Where(p => p.Name.StartsWith("set")))
        {
            result.AppendLine($"{publicProperty.Name} have to be private!");
        }

        return result.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        string baseClassName = classType.BaseType.Name;

        StringBuilder result = new StringBuilder();
        result.AppendLine($"All Private Methods of Class: {className}");
        result.AppendLine($"Base Class: {baseClassName}");

        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (MethodInfo classMethod in classNonPublicMethods)
        {
            result.AppendLine(classMethod.Name);
        }

        return result.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder result = new StringBuilder();

        foreach (var method in classMethods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return result.ToString().TrimEnd();
    }
}
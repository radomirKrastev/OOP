 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);

            var command = Console.ReadLine();

            while (command != "HARVEST")
            {
                FieldInfo[] allFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                switch (command)
                {
                    case "private":
                        PrintFields(allFields.Where(x => x.IsPrivate).ToArray());
                        break;
                    case "public":
                        PrintFields(allFields.Where(x => x.IsPublic).ToArray());
                        break;
                    case "protected":
                        PrintFields(allFields.Where(x => x.IsFamily).ToArray());
                        break;
                    default:
                        PrintFields(allFields);
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void PrintFields(FieldInfo[] fields)
        {
            StringBuilder output = new StringBuilder();

            foreach (FieldInfo fieldInfo in fields)
            {
                output.AppendLine($"{fieldInfo.Attributes.ToString().ToLower()} " +
                    $"{fieldInfo.FieldType.Name} " +
                    $"{fieldInfo.Name}");
            }

            Console.WriteLine(output.ToString().TrimEnd()); 
        }
    }
}

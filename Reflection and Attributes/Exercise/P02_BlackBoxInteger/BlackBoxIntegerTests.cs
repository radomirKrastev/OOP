namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInteger);

            MethodInfo[] methods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            BlackBoxInteger classInstance = (BlackBoxInteger)Activator.CreateInstance(typeof(BlackBoxInteger), true);
            
            var command = Console.ReadLine();
            
            while (command != "END")
            {
                string[] commandParts = command.Split("_");
                string methodName = commandParts[0];
                int number = int.Parse(commandParts[1]);

                methods.Where(x => x.Name == methodName).FirstOrDefault()?.Invoke(classInstance, new object[1] { number });

                PrintResult(classType, classInstance);
                command = Console.ReadLine();
            }
        }

        private static void PrintResult(Type classType, BlackBoxInteger classInstance)
        {
            FieldInfo field = classType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            field.GetValue(classInstance);

            Console.WriteLine(field.GetValue(classInstance));
        }
    }
}

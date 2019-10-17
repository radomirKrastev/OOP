namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            var customStack = new StackOfStrings();
            customStack.AddRange("");
            System.Console.WriteLine(customStack.IsEmpty());
        }
    }
}

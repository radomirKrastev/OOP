namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        public void AddRange(params string[] strings)
        {
            foreach (var item in strings)
            {
                base.Push(item);
            }
        }
    }
}

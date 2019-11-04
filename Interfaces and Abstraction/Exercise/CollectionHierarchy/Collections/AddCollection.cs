namespace CollectionHierarchy.Collections
{
    using Interfaces;

    public class AddCollection : IAdder
    {
        private string[] collection;
        private int counter;

        public AddCollection()
        {
            this.collection = new string[100];
        }

        public int Add(string item)
        {
            this.collection[this.counter++] = item;
            return this.counter - 1;
        }
    }
}

namespace CollectionHierarchy.Collections
{
    using Interfaces;

    public class AddRemoveCollection : IRemover
    {
        private string[] collection;
        private int counter;

        public AddRemoveCollection()
        {
            this.collection = new string[100];
        }

        public int Add(string item)
        {
            for (int i = this.counter; i > 0; i--)
            {
                this.collection[i] = this.collection[i - 1];
            }

            this.collection[0] = item;
            this.counter++;

            return 0;
        }

        public string Remove()
        {
            var item = this.collection[this.counter - 1];

            this.collection[--this.counter] = null;

            return item;
        }
    }
}

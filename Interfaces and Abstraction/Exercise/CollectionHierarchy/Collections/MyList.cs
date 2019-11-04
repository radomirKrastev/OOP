namespace CollectionHierarchy.Collections
{
    using Interfaces;

    public class MyList : IMyList
    {
        private string[] collection;
        private int counter;

        public MyList()
        {
            this.collection = new string[100];
        }

        public int Used => this.counter;

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
            var item = this.collection[0];

            for (int i = 0; i < this.counter; i++)
            {
                this.collection[i] = this.collection[i + 1];
            }

            this.collection[--this.counter] = null;
            
            return item;
        }
    }
}

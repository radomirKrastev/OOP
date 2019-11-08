namespace WildFarm.Foods
{
    public class Food
    {
        private string type;
        private int quantity;

        public Food(int quantity, string type)
        {            
            this.quantity = quantity;
            this.type = type;
        }

        public string Type => this.type;

        public int Quantity => this.quantity;
    }
}

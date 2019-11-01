namespace BorderControl
{
    public class Robot : Passer
    {
        private string id;
        private string model;

        public Robot(string model, string id)
        {
            this.model = model;
            this.id = id;
        }

        public override string Id => this.id;
    }
}

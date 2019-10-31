namespace Ferrari
{
    public class Ferrari : ICar
    {
        private string model = "488-Spider";
        private string driver;

        public Ferrari(string driver)
        {
            this.driver = driver;
        }
        
        public string PressTheGas()
        {
            return "Gas!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.model}/{this.UseBrakes()}/{this.PressTheGas()}/{this.driver}";
        }
    }
}

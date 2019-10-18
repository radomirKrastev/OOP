namespace MordorCruelPlan.Food
{
    public class FoodFactory
    {
        public Food GetFood(string food)
        {
            switch (food)
            {
                case "apple":                    
                       return new Apple(); 
                case "cram":
                    return new Cram();
                case "honeycake":
                    return new HoneyCake();
                case "lembas":
                    return new Lembas();
                case "melon":
                    return new Melon();
                case "mushroom":
                    return new Mushroom();
                default:
                    return new Food();
            }
        }
    }
}

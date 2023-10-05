class Buffet
{
    public List<Food> Menu;

    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Spaghetti ", 300 , false, false)
            new Food("Tikka ", 400 , True, false)
            new Food("Cake", 1000, false, True)
            new Food("Buffalo Wings", 450 , True, false)
            new Food("Pineapple Pizza", 250 , false, True)
            new Food("Strawberry Yogurt", 150 , false, True)
            new Food("Sushi Roll", 250 , false, false)
        };
    }

    public Food Serve()
    {
        Random rand = new Random();
        Food dish = Menu[rand.Next(Menu.Count())];
        return dish;
    }
}
public class Wizard : Human 
{

    public Wizard(string name , int dexterity ,int strength ):base(name,strength,50,dexterity,25)
    {

    }
    public override int Attack(Human target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        Health += dmg;
        Console.WriteLine($"{Name} Healed {dmg} Health");
        return target.Health;
    }
    public  int Heal(Human target)
    {
        int heal= Intelligence*3;
        target.Health += heal;
        return target.Health;
    }
}
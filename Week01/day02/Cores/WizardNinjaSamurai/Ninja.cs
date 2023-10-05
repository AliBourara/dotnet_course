public class Ninja : Human 
{

    public Ninja(string name ,int strength, int intelligence,int health ):base(name,strength,intelligence,75,health)
    {

    }

    public override int Attack(Human target)
    
    {
    Random rnd = new Random();
    int cd = rnd.Next(1,6);
    if (cd == 3) 
    {
        System.Console.WriteLine(cd);
        int dmg = Dexterity;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }

    else // 10% of the time
    {
        System.Console.WriteLine(cd);
        int dmg = Dexterity;
        target.Health -= dmg + 10;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} CRITICAL DAMAGE !");
        return target.Health;
    }
    }
    public  int Steal(Human target)
    {
        
        target.Health -= 5;
        Health += 5;
        return target.Health;
    }
    
}
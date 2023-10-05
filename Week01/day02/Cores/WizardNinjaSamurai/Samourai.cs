public class Samourai: Human
{
    public Samourai(string name , int dexterity ,int strength,int intelligence ):base(name,strength,intelligence,dexterity,200)
    {

    }
    public override int Attack(Human target)
    {
        if(target.Health < 50 ){
        target.Health = 0;
        Console.WriteLine($"{Name} Destroyed {target.Name}");
        }else
        {
        int dmg = Strength * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
        }

return target.Health;
    }
    public int Meditate()
    {
        Health = 200;
        return Health;
    }

}
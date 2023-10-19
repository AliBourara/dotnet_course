namespace WeddingPlanner.Models;

public class AllWeddingsView 
{
    public List<Wedding> AllWeddings {get ; set;} = new();
    public Participation Part {get ; set;} = new();
}
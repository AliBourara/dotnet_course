int[] numbers = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
string[] names = new string[4] { "Tim", "Martin", "Nikki", "Sara" };
bool[] isIt = new bool[10] { true, false, true, false, false, true, false, true, false, false };

List<string> iceCream = new List<string>();
iceCream.Add("Chocolat");
iceCream.Add("Vanille");
iceCream.Add("Cafe");
iceCream.Add("Banana");
iceCream.Add("Oreo");
iceCream.Add("Mint");
// Console.WriteLine(iceCream.Count);
// Console.WriteLine(iceCream[3]);
// iceCream.RemoveAt(3);
// Console.WriteLine(iceCream.Count);
// Console.WriteLine(iceCream[3]);

Random rand = new Random();
Dictionary<string, string> favorites = new Dictionary<string, string>();
foreach (string name in names)
{
    favorites[name] = iceCream[rand.Next(iceCream.Count)];
}
foreach (KeyValuePair<string, string> entry in favorites)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}
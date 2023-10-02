static int[] RandomArray()
{
    int[] numbers = new int[10];
    Random rand = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = rand.Next(5, 26);
    }
    return numbers;
}
int[] numbers = RandomArray();
int max = numbers[0];
int min = numbers[0];
int sum = numbers[0];
for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] < min)
    {
        min = numbers[i];
    }
    if (numbers[i] > max)
    {
        max = numbers[i];
    }
    sum += numbers[i];
}
Console.WriteLine("Min = " + min + " Max = " + max + ".");
Console.WriteLine("Sum of array values = " + sum + ".");

static string TossCoin()
{
    System.Console.WriteLine("Tossing a Coin!");
    Random rand = new Random();
    string side = "";
    int coin = rand.Next(0, 2);
    if (coin == 0)
    {
        side = "head";
    }
    else { side = "tails"; }
    return side;
}
string side = TossCoin();
System.Console.WriteLine(side);

static double TossMultipleCoins(int num)
{
    Random rand = new Random();
    int count = 0;
    double ratio;
    for (int flip = 1; flip <= num; flip++)
    {
        int result = rand.Next(2);
        if (result == 0)
        {
            count++;
        }
    }
    ratio = Convert.ToDouble(count) / Convert.ToDouble(num);
    return ratio;
}

static List<string> Names()
{
    Random rand = new Random();
    List<string> names = new List<string>()
            {
                "Todd", "Tiffany", "Charlie", "Geneva", "Sydney"
            };
    // Shuffle names in list
    int count = names.Count;
    for (var i = 0; i < count / 2; i++)
    {
        int randIdx = rand.Next(count);
        string temp = names[randIdx];
        names[randIdx] = names[i];
        names[i] = temp;
    }
    // print shuffled list
    foreach (var name in names)
    {
        Console.WriteLine(name);
    }
    // Remove names 5 char or less
    for (var idx = 0; idx < count; idx++)
    {
        if (names[idx].Length <= 5)
        {
            names.RemoveAt(idx);
        }
    }
    return names;
}
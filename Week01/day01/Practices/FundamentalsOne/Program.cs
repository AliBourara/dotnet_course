int i = 1;
while(i <=255)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        System.Console.WriteLine($"FizzBizz");
    }
    else if (i % 5 == 0)
    {
        System.Console.WriteLine($"Bizz");
    }
    else if (i % 3 == 0)
    {
        System.Console.WriteLine($"Fizz");
    }
    i++;
}

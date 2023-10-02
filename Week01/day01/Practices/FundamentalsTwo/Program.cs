static void Print1to255()
{
    for (int val = 1; val <= 255; val++)
    {
        Console.WriteLine(val);
    }
}
// Prints sum of 1 to 255
static void Sum1to255()
{
    int sum = 0;
    for (int num = 0; num <= 255; num++)
    {
        sum += num;
        Console.WriteLine($"New Number: {num} Sum: {sum}");
    }
}
// Iterate through an Array
static void IterateArray(int[] arr)
{
    string output = "[";
    for (int idx = 0; idx < arr.Length; idx++)
    {
        output += arr[idx] + ", ";
    }
    output += "]";
    Console.WriteLine(output);
}
// Find max value in an array
static void MaxArray(int[] arr)
{
    int max = arr[0];
    foreach (int val in arr)
    {
        if (val > max)
        {
            max = val;
        }
    }
    Console.WriteLine("The max value is {0}", max);
}
// Get Avg. value of an array
static void AvgArray(int[] arr)
{
    int sum = GetSum1to255(arr);
    Console.WriteLine("This average is " + (double)sum / (double)arr.Length);
}
static int GetSum1to255(int[] arr)
{
    int sum = 0;
    for (int num = 0; num < arr.Length; num++)
    {
        sum += arr[num];
    }
    return sum;
}
// Create array of odd numbers between 1 to 255
static int[] CreateOddArray()
{
    List<int> oddList = new List<int>();
    for (int val = 1; val < 256; val++)
    {
        if (val % 2 == 1)
        {
            oddList.Add(val);
        }
    }
    return oddList.ToArray();
}
// Count all values greater than Y
static void GreaterY(int[] arr, int y)
{
    int count = 0;
    foreach (int val in arr)
    {
        if (val > y)
        {
            count++;
        }
        Console.WriteLine($"There are {count} values greater than Y");
    }
}
// Square all values in an array
static void SquareArrayValues(int[] arr)
{
    for (int idx = 0; idx < arr.Length; idx++)
    {
        arr[idx] *= arr[idx];
    }
}
// Eliminate all Negitave numbers
static void NegNum(int[] arr)
{
    for (int idx = 0; idx < arr.Length; idx++)
    {
        if (arr[idx] < 0)
        {
            arr[idx] = 0;
        }
    }
}
// Retrieve Min, Max, and Avg. from an array
static void MinMaxAvg(int[] arr)
{
    int sum = 0;
    int max = arr[0];
    int min = arr[0];
    foreach (int val in arr)
    {
        sum += val;
        if (val < min)
        {
            min = val;
        }
        if (val > max)
        {
            max = val;
        }
    }
    Console.WriteLine("The max of the array is {0}, the min is {1}, and the average is {2}", max, min, sum / (double)arr.Length);
}
// Shift an array to the front by one number and add 0 to the end
static void ShiftArrayVal(int[] arr)
{
    for (int idx = 0; idx < arr.Length - 1; idx++)
    {
        arr[idx] = arr[idx + 1];
    }
    arr[arr.Length - 1] = 0;
}
// Number to String
static object[] NumtoString(object[] arr)
{
    for (int idx = 0; idx < arr.Length; idx++)
    {
        if ((int)arr[idx] < 0)
        {
            arr[idx] = "Dojo";
        }
    }
    return arr;
}
static void Main(string[] args)
{
    // Prints values 1 to 255
    Print1to255();
    // Prints odd values 1 to 255
    for (int val = 1; val < 256; val++)
    {
        if (val % 2 == 1)
        {
            Console.WriteLine(val);
        }
    }
    Sum1to255();
    int[] myArr = new int[6] { 1, 3, 5, 7, 9, 13 };
    IterateArray(myArr);
    MaxArray(myArr);
    AvgArray(myArr);
    CreateOddArray();
    GreaterY(myArr, 4);
    SquareArrayValues(myArr);
    NegNum(myArr);
    MinMaxAvg(myArr);
    ShiftArrayVal(myArr);
    object[] boxedArray = new object[] { -1, 3, 2, -16 };
    NumtoString(boxedArray);
}
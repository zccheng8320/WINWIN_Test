// See https://aka.ms/new-console-template for more information
var sortedList = new SortedList<int, int>();
while (sortedList.Count <=10)
{
    var value = Console.ReadLine();
    if (int.TryParse(value, out var intResult) == false)
    {
        Console.WriteLine("請輸入數字");
        continue;
    }
    sortedList.Add(intResult,intResult);
}

Console.WriteLine(string.Join(",",sortedList.Values));

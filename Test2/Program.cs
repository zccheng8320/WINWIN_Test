var array = new int[] { 1,4,3,6,9,11,8,36};
// 轉換資料結構(list)
var list = array.ToList();
list.Insert(2,23);
Console.WriteLine(string.Join(",",list.Select(x=>x.ToString())));

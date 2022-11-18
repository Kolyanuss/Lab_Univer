
var res = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };//.GetRange(2, 5);
res.RemoveRange(4, res.Count - 4);
res.InsertRange(4, new List<int>() { 0, 0, 0 });
foreach (var item in res)
{
    Console.WriteLine(item);
}

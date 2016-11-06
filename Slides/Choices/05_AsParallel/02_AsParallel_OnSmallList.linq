<Query Kind="Program" />

void Main()
{
	//tworzymy 100 elemntową listę
	const int _numberCount = 100;
	var list = new List<int>(_numberCount);
	for (var i = 0; i < _numberCount; i++)
	{
	    list.Add(i);
	}
	
	//jednowątkowo
	MeasureTime(() => list.Where(a => a % 2 == 0).Count());
	//wielowątkowo
	MeasureTime(
	    () => list
	    .AsParallel()
	    .Where(a => a % 2 == 0).Count()
	);
}
//wypisywanie pomiaru
private static void MeasureTime(Func<int> a)
{
    var sw = Stopwatch.StartNew();
    a();
    sw.Stop();
    Console.WriteLine("Zajęło: " + sw.ElapsedMilliseconds);
}
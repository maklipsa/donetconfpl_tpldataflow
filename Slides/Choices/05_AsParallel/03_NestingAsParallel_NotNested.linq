<Query Kind="Program" />

void Main()
{
	//tworzymy listę
    const int _numberCount = 1*1000*1000;
    var list = new List<int>(_numberCount);
    for (var i = 0; i < _numberCount; i++)
    {
        list.Add(i);
    }	
	//wykonanie jednowątkowe
	MeasureTime(() => list.Where(IsPrime).Count());
	//wykonanie wielowątkowe
	MeasureTime(() => CalcInSingleAsParallel(list).Count());
}
private static IEnumerable<int> CalcInSingleAsParallel(List<int> numbers)
{
    return numbers
        .AsParallel()
        .Where(IsPrime)
        ;
}
internal static bool IsPrime(int number)
{
    if (number == 1) return false;
    if (number == 2) return true;

    var boundary = (int) Math.Floor(Math.Sqrt(number));

    for (var i = 2; i <= boundary; ++i)
    {
        if (number%i == 0) return false;
    }

    return true;
}

private static void MeasureTime(Func<int> a)
{
    var sw = Stopwatch.StartNew();
    a();
    sw.Stop();

    Console.WriteLine("Zajęło: " + sw.ElapsedMilliseconds);
}
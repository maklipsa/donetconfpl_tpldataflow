<Query Kind="Program" />

void Main()
{
    const int _numberCount = 1*1000*1000;
    var list = new List<int>(_numberCount);
    for (var i = 0; i < _numberCount; i++)
    {
        list.Add(i);
    }
	//dzielimy 2 razy po 10
	var tenFragments=CalcInThreeNestedAsParallel(list, 10);
    MeasureTime(
        	() => tenFragments.Sum(a => a.Sum(b => b.Count()))
        );
	//dzielimy 2 razy po 100
	var hundretFragments=CalcInThreeNestedAsParallel(list, 100);
    MeasureTime(
        	() => hundretFragments.Sum(a => a.Sum(b => b.Count()))
        );
	//dzielimy 2 razy po 1000
	var thousandFragments=CalcInThreeNestedAsParallel(list, 1000);
    MeasureTime(
        	() => thousandFragments.Sum(a => a.Sum(b => b.Count()))
        );
}
private static IEnumerable<IEnumerable<IEnumerable<int>>> CalcInThreeNestedAsParallel(List<int> numbers,
    int chunkNumber)
{
    var numbersChunks = ToChunks(numbers, chunkNumber);
    var secondnNumberChunks = numbersChunks
        .Select(a => ToChunks(a, chunkNumber))
        .ToList();
    return secondnNumberChunks
        .AsParallel()
        .Select(a =>
            a
                .AsParallel()
                .Select(CalcInSingleAsParallel)
        )
        ;
}
private static IEnumerable<IEnumerable<int>> CalcInTwoNestedAsParallel(List<int> numbers, int chunkNumber)
{
    var numbersChunks = ToChunks(numbers, chunkNumber);
    return numbersChunks
        .AsParallel()
        .Select(CalcInSingleAsParallel)
        ;
}
private static IEnumerable<int> CalcInSingleAsParallel(List<int> numbers)
{
    return numbers
        .AsParallel()
        .Where(IsPrime)
        ;
}

private static List<List<int>> ToChunks(List<int> source, int nSize = 30)
{
    var ret = new List<List<int>>();

    for (var i = 0; i < source.Count; i += nSize)
    {
        var tmp = source.GetRange(i, Math.Min(nSize, source.Count - i));
        ret.Add(tmp);
    }

    return ret;
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
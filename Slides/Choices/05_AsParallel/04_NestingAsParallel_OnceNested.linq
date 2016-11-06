<Query Kind="Program" />

void Main()
{
    const int _numberCount = 1*1000*1000;
    var list = new List<int>(_numberCount);
    for (var i = 0; i < _numberCount; i++)
    {
        list.Add(i);
    }
	// dzielimy na 10 fragmentów
	var tenFragments = CalcInTwoNestedAsParallel(list, 10);
    MeasureTime(
    			() => tenFragments.Sum(a => a.Count())
    );
	
	// dzielimy na 100 fragmentów
	var hundretFragments=CalcInTwoNestedAsParallel(list, 100);
    MeasureTime(
	    		() => hundretFragments.Sum(a => a.Count())
    );
	
	// dzielimy na 1000 fragmentów
	var thousandFragments=CalcInTwoNestedAsParallel(list, 1000);
	MeasureTime(
	    () => thousandFragments.Sum(a => a.Count())
	);
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
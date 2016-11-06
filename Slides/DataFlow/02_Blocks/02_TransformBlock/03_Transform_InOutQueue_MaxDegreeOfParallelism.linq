<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var colorFormat= @"<span style='color:Green;'>{0}</span>";

//tworzę blok
var tfBlock = new TransformBlock<int, int>(
	n => {
		Thread.Sleep(400);
		return n*n;
	}
, new ExecutionDataflowBlockOptions(){ MaxDegreeOfParallelism = 2 });//domyślnie 1

for (int i = 0; i < 10; i++) 
{
	tfBlock.Post(i);
	Console.WriteLine(Util.RawHtml(string.Format(colorFormat,string.Format("InQueue:{0} OutQueue:{1}",tfBlock.InputCount,tfBlock.OutputCount))));
}
Console.WriteLine();
Console.WriteLine("Poczekamy chwilę");
Thread.Sleep(1000);

Console.WriteLine("Odbieramy");
Console.WriteLine();
for (int i = 0; i < 10; i++) 
{
	Console.WriteLine("Całkowita ilość wiadomości w bloku:"+(10-i));
	Console.WriteLine(Util.RawHtml(string.Format(colorFormat,string.Format("InQueue:{0} OutQueue:{1}",tfBlock.InputCount,tfBlock.OutputCount))));
	Console.WriteLine();
	int result = tfBlock.Receive();
}

Console.WriteLine("Koniec!");
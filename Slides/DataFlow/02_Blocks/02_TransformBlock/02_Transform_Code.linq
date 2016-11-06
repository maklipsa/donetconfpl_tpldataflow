<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var tfBlock = new TransformBlock<int, int>(
	n => {
		Thread.Sleep(500);
		return n * n;
	}
);

for (int i = 0; i < 10; i++) 
{
	tfBlock.Post(i);
	Console.WriteLine("Liczba elementów w kolejce wejściowej: " + tfBlock.InputCount);
}

for (int i = 0; i < 10; i++) 
{
	int result = tfBlock.Receive();
 	Console.WriteLine(result);
	Console.WriteLine("Liczba elementów w kolejce wyjściowej: " + tfBlock.OutputCount);
}

Console.WriteLine("Koniec!");
<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

//tworzymy blok
var batchBlock = new BatchBlock<int>(3); //parametrem jest wielość batcha

//wysyłamy
for (int i = 0; i < 10; i++) 
{
	batchBlock.Post(i);
}

//odbieramy
for (int i = 0; i < 5; i++) 
{
	int[] result = batchBlock.Receive();
	
	foreach (var r in result) 
	{
		Console.Write(r + " ");
	}
	
	Console.Write("\n");
}

Console.WriteLine("Koniec!");
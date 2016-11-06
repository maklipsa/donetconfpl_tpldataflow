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

//sygnalizujemy koniec
batchBlock.Complete();

//odbieramy
for (int i = 0; i < 5; i++) 
{
	int[] result=null;
	if(batchBlock.TryReceive(null,out result)){
		foreach (var r in result) 
		{
			Console.Write(r + " ");
		}
		
		Console.Write("\n");
	
	}
	else 
		Console.WriteLine("To jest już koniec. Nie ma już nic...");
}

Console.WriteLine("Koniec!");
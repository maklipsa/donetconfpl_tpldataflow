<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var generator = new Random();

var actionBlock = new ActionBlock<int>(
	n => {
		Thread.Sleep(generator.Next(1000));
	 	Console.WriteLine("ThreadId "+Thread.CurrentThread.ManagedThreadId+" wiadomość:"+n);
	}
	, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1 }
);

for (int i = 0; i < 100; i++) 
{
	actionBlock.Post(i);
}

Console.WriteLine("Koniec!");
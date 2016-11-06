<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var actionBlock = new ActionBlock<int>(n =>{
    Thread.Sleep(1000);
    Console.WriteLine(n);
});

for (int i = 0; i < 10; i++) {
    actionBlock.Post(i);
	Console.WriteLine("Liczba elementów w kolejce wejściowej: "+actionBlock.InputCount);
}

Console.WriteLine("Koniec!");
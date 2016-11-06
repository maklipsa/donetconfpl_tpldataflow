<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var colorFormat= @"<span style='color:{0};'>{1}</span>";

var source = new BufferBlock<string>(); // pierwszy blok

var printBlock = new ActionBlock<string>(n => {
	Console.WriteLine(Util.RawHtml(n));
	Thread.Sleep(500);
});

// linkuję bloki ustawiając propagację zakończenia
source.LinkTo(printBlock, new DataflowLinkOptions()
										{ 
											PropagateCompletion = true  //domyślie false!
										});
//wysyłam wiadomości
for (int i = 0; i < 10; i++) 
{
	source.Post(string.Format(colorFormat,"Blue","Wiadomość: "+ i));
}
Console.WriteLine("Koniec!");

// zapisuję się na zakończenie 2 bloku
printBlock.Completion.ContinueWith(a => Console.WriteLine("Faktyczny koniec"));
// wysyłam sygnał o zakończeniu
source.Complete();
// i czekam
printBlock.Completion.Wait();
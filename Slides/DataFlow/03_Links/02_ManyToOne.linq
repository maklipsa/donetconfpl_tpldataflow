<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var colorFormat= @"<span style='color:{0};'>{1}</span>";

// tworzę pierwszego producenta
var source1 = new TransformBlock<string, string>(n =>
				{
					Thread.Sleep(300);			
					return n;
				});
// tworzę drugiego producenta				
var source2 = new TransformBlock<string, string>(n =>
				{
					Thread.Sleep(500);			
					return n;
				});

// tworzę odbiorcę
var printBlock = new ActionBlock<string>(n => Console.WriteLine(Util.RawHtml(n)));

// linkuję obu producentów do jednego
source1.LinkTo(printBlock);
source2.LinkTo(printBlock);

// wysyłam
for (int i = 0; i < 10; i++) 
{
	source1.Post(string.Format(colorFormat,"Blue","P1: "+i));
 	source2.Post(string.Format(colorFormat,"Red","P2: "+ (-i)));
}
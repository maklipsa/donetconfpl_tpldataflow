<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var colorFormat= @"<span style='color:{0};'>{1}</span>";

//tworzymy BrodcastBlock
var bcBlock = new BroadcastBlock<int>(n => n);
//var bcBlock = new BufferBlock<int>();

//tworzymy pierwszy blok wypisujący
var console1 = new ActionBlock<int>(n => Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Blue","Console1: "+n))));
//tworzymy drugi blok wypisujący
var console2 = new ActionBlock<int>(n => Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Red","Console2: "+n))));

bcBlock.LinkTo(console1);
bcBlock.LinkTo(console2);

//wysyłamy wiadomości
for (int i = 0; i < 10; i++)
{
	bcBlock.Post(i);
}

Console.WriteLine("Koniec!");
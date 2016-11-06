<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var colorFormat= @"<span style='color:{0};'>{1}</span>";
// tworzę pierwszego odbiorcę
var console1 = new ActionBlock<int>(n => Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Blue","Console1: "+n))));
// tworzę drugiego odbiorcę
var console2 = new ActionBlock<int>(n => Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Red","Console2: "+n))));

//tworzę producenta
var bcBlock = new TransformBlock<int,int>(n => n);

// pierwszy odbiorca przyjmie tylko parzyste
bcBlock.LinkTo(console1, n => n % 2 == 0);

// drugi odbiorca przyjmie wszystko
bcBlock.LinkTo(console2);

// wysyłam
for (int i = 0; i < 10; i++)
{
	bcBlock.Post(i);
}

Console.WriteLine("Koniec");
<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var colorFormat = @"<span style='color:{0};'>{1}</span>";

//tworzymy JoinBlock
var jBlock = new JoinBlock<int, int>(
		new GroupingDataflowBlockOptions { 
											Greedy = false //zachłanny, domyślnie true
										 });

//wysyłamy wiadomości do pierwszego źródła
for (int i = 0; i < 10; i++) 
{
	if (jBlock.Target1.Post(i)){
		Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Blue","Console1 accepted: " + i)));
	}else{
		Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Blue","Console1 REFUSED: "+ i)));
	}
}

//wysyłamy wiadomości do drugiego źródła
for (int i = 0; i < 10; i++) 
{
	if (jBlock.Target2.Post(i))	{
		Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Red","Console2 accepted: " + i)));
	}else{
		Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Red","Console2 REFUSED: " + i)));
	}
}

for (int i = 0; i < 10; i++) 
{
	Console.WriteLine(jBlock.Receive());
}

Console.WriteLine("Koniec!");
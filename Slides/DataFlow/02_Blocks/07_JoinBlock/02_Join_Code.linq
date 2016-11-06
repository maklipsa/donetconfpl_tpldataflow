<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var colorFormat = @"<span style='color:{0};'>{1}</span>";

//tworzymy JoinBlock
var jBlock = new JoinBlock<string, string>();

// piszemy do pierwszego źródła
for (int i = 0; i < 10; i++) 
{
	// Dla każdego źródła jest osobny Target
	jBlock.Target1.Post(string.Format(colorFormat,"Blue","P1: "+i));
}

// piszemy do drugiego źródła
for (int i = 0; i < 10; i++) 
{
	// Dla każdego źródła jest osobny Target
	jBlock.Target2.Post(string.Format(colorFormat,"Red","P2: "+i));
}

// dane odbierane są sparowane
for (int i = 0; i < 10; i++) 
{
	var res = jBlock.Receive();
	Console.WriteLine(Util.RawHtml("("+res.Item1+";"+res.Item2+")"));
}

Console.WriteLine("Koniec");
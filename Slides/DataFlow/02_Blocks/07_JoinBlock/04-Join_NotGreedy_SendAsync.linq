<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var colorFormat = @"<span style='color:{0};'>{1}</span>";

//tworzymy JoinBlock
var jBlock = new JoinBlock<string, string>(
			new GroupingDataflowBlockOptions { 
									Greedy = false, //zachłanny
									BoundedCapacity = 2 //tylko 2 wiadomości w kolejce wejściowej
									});

//pierwszy producent wysyła wiadomości
for (int i = 0; i < 10; i++) 
{
	Task<bool> task = jBlock.Target1.SendAsync(string.Format(colorFormat,"Blue","P1:"+i));
	int iCopy = i; 
	task.ContinueWith(t => {
		if (t.Result){
			Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Blue","Console1 accepted: " + iCopy)));
		} 
		else{
			Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Blue","Console1 REFUSED: "+ iCopy)));
		}
	});
}
Console.WriteLine("Producent pierwszy wszystko wysłał");

//drugi producent wysyła wiadomości
for (int i = 0; i < 10; i++) 
{
	Task<bool> task = jBlock.Target2.SendAsync(string.Format(colorFormat,"Red","P2:"+i));
	int iCopy = i; 
	
	task.ContinueWith(t => {
	if (t.Result){
		Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Red","Console2 accepted: " + iCopy)));
	}
	else{
		Console.WriteLine(Util.RawHtml(string.Format(colorFormat,"Red","Console2 REFUSED: " + iCopy)));
	}
	});
}
Console.WriteLine("Producent drugi wszystko wysłał");

for (int i = 0; i < 10; i++) 
{
	var res=jBlock.Receive();
	Console.WriteLine(Util.RawHtml("("+res.Item1+";"+res.Item2+")"));
}

Console.WriteLine("Koniec!");
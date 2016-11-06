<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var colorFormat= @"<span style='color:{0};'>{1}</span>";

//tworzymy blok buforujący 3 wiadomości
var bjBlock = new BatchedJoinBlock<string, string>(3, new GroupingDataflowBlockOptions()
{
										Greedy = true, //nie może mieć innej wartości
										BoundedCapacity= -1 //nie może mieć innej wartości
										});

for (int i = 0; i < 20; i++) 
{
	if(i%2==0) //pierwszy producent
		bjBlock.Target1.Post(string.Format(colorFormat,"Blue","P1: "+i));
	else //drugi producent
		bjBlock.Target2.Post(string.Format(colorFormat,"Red","P2: "+i));
}
//Synagnalizujemy koniec
bjBlock.Complete();

//odbieramy
for (int i = 0; i < 10; i++) 
{
	Tuple<IList<string>,IList<string>> item=null;
	if(!bjBlock.TryReceive(out item)){			
		Console.WriteLine("Odebrałem resztę, więcej nie będzie");
		break;
	}
	Console.WriteLine(Util.RawHtml("["+string.Join(",",item.Item1)+"],["+string.Join(",",item.Item2)+"]"));
}

Console.WriteLine("Koniec");
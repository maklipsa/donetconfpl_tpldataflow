<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

//techniczny kod
var colorFormat= @"<span style='color:Red;'>{0}</span>";

//tworzymy bufor
var bb = new BufferBlock<int>() ;

//tworzymy konsumentów
var a1 = new ActionBlock<int>(
a => {
		Console.WriteLine("Action A1 executing with value {0}", a);
  		Thread.Sleep(100);//czekanie
    }
);

var a2 = new ActionBlock<int>(
a => {
        Console.WriteLine("Action A2 executing with value {0}", a);
		Thread.Sleep(50);//czekanie
   }
);

var a3 = new ActionBlock<int>(
a => {
		Console.WriteLine("Action A3 executing with value {0}", a);
        Thread.Sleep(50);//czekanie     
   }
);

bb.LinkTo(a1);
bb.LinkTo(a2);
bb.LinkTo(a3);

for(int i=0; i<10 ;i++)
{
    Thread.Sleep(10);
    if(!bb.Post(i)){
		Console.WriteLine(Util.RawHtml(string.Format(colorFormat,string.Format("Wiadomość:{0} została odrzucona",i))));
	}
}
Console.WriteLine("Koniec!");
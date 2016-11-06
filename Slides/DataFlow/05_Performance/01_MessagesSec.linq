<Query Kind="Statements">
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

// http://blogs.msdn.com/b/pfxteam/archive/2011/09/27/10217461.aspx
var sw = new Stopwatch();
const int ITERS = 6*1000*1000;
var are = new AutoResetEvent(false);

var ab = new ActionBlock<int>(
						i => { if (i == ITERS) are.Set(); }
						, new ExecutionDataflowBlockOptions { SingleProducerConstrained = true }
						);

for(int j=0;j<10;j++)
{
	sw.Restart();
	for (int i = 1; i <= ITERS; i++){
		ab.Post(i);
	}
	are.WaitOne();
	sw.Stop();
	
	Console.WriteLine("Wiadomości / sec: {0:N0}", (ITERS / sw.Elapsed.TotalSeconds));
}
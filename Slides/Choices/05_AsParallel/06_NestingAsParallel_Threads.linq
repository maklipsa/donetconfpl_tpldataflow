<Query Kind="Statements" />

var folder = Path.GetDirectoryName (Util.CurrentQueryPath).Replace("/",@"\")+"/";
Console.WriteLine("CalcInTwoNestedAsParallel(list, 10)");
Console.WriteLine (Util.Image ("file://"+folder+"Images/NoNesting.png"));
Console.WriteLine("CalcInTwoNestedAsParallel(list, 10)");
Console.WriteLine (Util.Image ("file://"+folder+"Images/OneNesting_10.png"));
Console.WriteLine("CalcInThreeNestedAsParallel(list, 10)");
Console.WriteLine (Util.Image ("file://"+folder+"Images/TwoNesting_10.png"));
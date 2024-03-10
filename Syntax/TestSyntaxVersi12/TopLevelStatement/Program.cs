// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Console.WriteLine();
foreach (var s in args)
{
    Console.Write(s);
    Console.Write(' ');
}
Console.WriteLine();
// await ShowConsoleAnimation();
await ShowConsoleAnimation(30);


var index = new Random().Next(answers.Length - 1);
Console.WriteLine(answers[index]);

Console.WriteLine();

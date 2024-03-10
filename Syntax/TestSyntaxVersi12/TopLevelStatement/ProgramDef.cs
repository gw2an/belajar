 partial class Program
{
    static string[] answers =
    [
        "It is certain.",
        "Reply hazy, try again.",
        "Don’t count on it.",
        "It is decidedly so.",
        "Ask again later.",
        "My reply is no.",
        "Without a doubt.",
        "Better not tell you now.",
        "My sources say no.",
        "Yes – definitely.",
        "Cannot predict now.",
        "Outlook not so good.",
        "You may rely on it.",
        "Concentrate and ask again.",
        "Very doubtful.",
        "As I see it, yes.",
        "Most likely.",
        "Outlook good.",
        "Yes.",
        "Signs point to yes.",
    ];

    //static async Task ShowConsoleAnimation()
    //{
    //    for (int i = 0; i < 20; i++)
    //    {
    //        Console.Write("| -");
    //        await Task.Delay(50);
    //        Console.Write("\b\b\b");
    //        Console.Write("/ \\");
    //        await Task.Delay(50);
    //        Console.Write("\b\b\b");
    //        Console.Write("- |");
    //        await Task.Delay(50);
    //        Console.Write("\b\b\b");
    //        Console.Write("\\ /");
    //        await Task.Delay(50);
    //        Console.Write("\b\b\b");
    //    }
    //    Console.WriteLine();
    //}

    static string[] animstrarr = { "| -", "/ \\", "- |", "\\ /", "\b\b\b" };
    static async Task ShowConsoleAnimation(int count = 5)
    {
        for (int i = 0; i < count; i++)
        {
            foreach (string s in animstrarr)
            {
                Console.Write(s);
                await Task.Delay(50);
                Console.Write("\b\b\b");
            }
        }
    }


}

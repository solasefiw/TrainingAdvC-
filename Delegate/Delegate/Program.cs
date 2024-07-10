class Program
{
    delegate void DelegateMethod(string text);
    static void Main(string[] args)
    {
        Logfiles log = new Logfiles();

        DelegateMethod consoleDisplay, logFileSave, Multiple;

        consoleDisplay = new DelegateMethod(log.ConsoleDisplay);

        logFileSave = new DelegateMethod(log.LogFileSave);

        Multiple = consoleDisplay + logFileSave;
        Console.WriteLine("Write a Note");

        var note = Console.ReadLine();

        Multiple(note);

        Console.ReadKey();

    }
}

public class Logfiles
{
    public void ConsoleDisplay(string text)
    {
        Console.WriteLine($"Welcome to {text}. The Time is: {DateTime.Now} ");
    }

    public void LogFileSave(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}
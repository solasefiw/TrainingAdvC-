using static System.Net.Mime.MediaTypeNames;

class Program
{
    delegate void DelegateMethod(string text);
    delegate void DelegateFunction(int num1,int num2);
    static void Main(string[] args)
    {
        Logfiles log = new Logfiles();

        DelegateMethod consoleDisplay, logFileSave, Multiple;

        DelegateFunction getResult,logResult;

        consoleDisplay = new DelegateMethod(log.ConsoleDisplay);

        logFileSave = new DelegateMethod(log.LogFileSave);
        getResult = new DelegateFunction(log.getResult);
        logResult = new DelegateFunction(log.logResultEqu);



        Multiple = consoleDisplay + logFileSave;
        Console.WriteLine("Write a Note");


        // calling function
        int num1 = Convert.ToInt32(Console.ReadLine());
        var num2 = Convert.ToInt32(Console.ReadLine());
        getResult(num1, num2);
        logResult(num1, num2);



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
    public void getResult(int  num1,int num2)
    {
        Console.WriteLine($"{(num1+num2) * (num1 -num2)} ");
    }
    public void logResultEqu(int num1,int num2)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "result.txt"), true))
        {
            var result = (num1 + num2) * (num1 - num2);
            sw.WriteLine($"Result: {result}");
        }
    }
}
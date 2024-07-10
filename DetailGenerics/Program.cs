class Program
{
    static void Main(string[] args)
    {
        var result = new Result { Value = 10, IsSuccess = true };
        var display = new display { Note = "Advanced c# Generics", IsSuccess = false };

        var GenericResult = new GenericResult<string> { Value = "Generic String", IsSuccess = false };
        var GenericResult1 = new GenericResult<int> { Value = 5, IsSuccess = false };

        Console.WriteLine(display.Note);
        Console.WriteLine(display.IsSuccess);
        Console.ReadKey();
    }
}

public class GenericResult<T>
{
    public T Value { get; set; }
    public bool IsSuccess { get; set; }
}

public class Result
{
    public int Value { get; set; }
    public bool IsSuccess { get; set; }
}

public class display
{
    public string Note { get; set; }
    public bool IsSuccess { get; set; }
}



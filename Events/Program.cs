// Subscriber Class
class ProgramOne
{
    static void Main(string[] args)
    {
        int randomThreshold = new Random().Next(1, 11);
        Counter c = new Counter(randomThreshold);
        c.ThresholdReached += c_ThresholdReached;

        Console.WriteLine($"press 'a' key to reach total press count of {randomThreshold}");
        while (Console.ReadKey(true).KeyChar == 'a')
        {
            Console.WriteLine($"count added ");
            c.Add(1);
        }
    }

    static void c_ThresholdReached(object sender, EventArgs e)
    {
        Console.WriteLine($"The threshold was reached This is an Evenet Trigger Notification Message");
        // Environment.Exit(0);
    }
}

// Publisher Class
class Counter
{
    private int threshold;
    private int total;

    public Counter(int passedThreshold)
    {
        threshold = passedThreshold;
    }

    public void Add(int x)
    {
        total += x;
        if (total >= threshold)
        {
            ThresholdReached?.Invoke(this, EventArgs.Empty);

        }
    }

    public event EventHandler ThresholdReached;
}
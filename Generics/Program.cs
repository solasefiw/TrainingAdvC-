class Program
{
    static void Main(string[] args)
    {
        Salaries salaries = new Salaries();

        // ArrayList salaryList = salaries.GetSalaries();
        List<float> salaryList = salaries.GetSalaries();

        float salary = salaryList[0];

        // salary = salary + 0;

        Console.WriteLine($"The Selected Item will be: {salary}");

        Console.ReadKey();


    }
}

public class Salaries
{
    List<float> _salaryList = new List<float>();

    public Salaries()
    {

        _salaryList.Add(60000.34f);
        _salaryList.Add(40000.51f);
        _salaryList.Add(20000.23f);

    }


    public List<float> GetSalaries()
    {
        return _salaryList;
    }

}
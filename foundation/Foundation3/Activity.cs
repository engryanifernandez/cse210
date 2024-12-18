/* 
This C# Program Code is made by Hazel Diane Fernandez
for W07 Prove: Final Foundation—Inheritance and Polymorphism
*/

public abstract class Activity
{
    private string _name;
    private string _date;
    protected int _length;

    public Activity(string name, string date, int length)
    {
        _name = name;
        _date = date;
        _length = length;
    }

    public abstract double CalculateSpeed();
    public abstract double CalculateDistance();
    public abstract double CalculatePace();

    public string GetSummary()
    {
        return $"{_date} {_name} ({_length} min): Distance {string.Format("{0:F1}",CalculateDistance())} miles, Speed {string.Format("{0:F1}",CalculateSpeed())} mph, Pace: {string.Format("{0:F1}",CalculatePace())} min per mile";
    }
}
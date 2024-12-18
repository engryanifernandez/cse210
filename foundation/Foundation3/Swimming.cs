/* 
This C# Program Code is made by Hazel Diane Fernandez
for W07 Prove: Final Foundation—Inheritance and Polymorphism
*/

public class Swimming : Activity
{
    private int _laps;
    
    public Swimming(string name, string date, int length, int laps) : base(name, date, length)
    {
        _laps = laps;
    }

    public override double CalculateSpeed()
    {
        return CalculateDistance() / _length * 60;
    }
    public override double CalculateDistance()
    {
        return _laps * 50 / 100 * 0.62;
    }
    public override double CalculatePace()
    {
        return _length / CalculateDistance();
    }
}
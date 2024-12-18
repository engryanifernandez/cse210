/* 
This C# Program Code is made by Hazel Diane Fernandez
for W07 Prove: Final Foundation—Inheritance and Polymorphism
*/

public class Cycling : Activity
{
    private float _speed;
    
    public Cycling(string name, string date, int length, float speed) : base(name, date, length)
    {
        _speed = speed;
    }

    public override double CalculateSpeed()
    {
        return _speed;
    }
    public override double CalculateDistance()
    {
        return _speed * _length / 60;
    }
    public override double CalculatePace()
    {
        return 60 / _speed;
    }
}
/* 
This C# Program Code is made by Hazel Diane Fernandez for W06 Prove: Developer—Eternal Quest
*/

public class NegativeGoal : Goal
{
    private int _penaltyPoints;

    public NegativeGoal(string name, string description, string points, int type) : base(name, description, points, type)
    {
        _penaltyPoints = int.Parse(points); // Store penalty points as an integer
    }

    public override void RecordEvent()
    {
        Console.WriteLine("Warning: This is a negative goal. Completing it deducts points.");
        int currentPoints = int.Parse(GetPoints());
        SetPoints(currentPoints - _penaltyPoints); // Deduct the correct number of points
    }

    public override bool isComplete()
    {
        // Negative goals can be considered complete when their points reach zero
        return int.Parse(GetPoints()) <= 0;
    }

    public override string GetStringRepresentation()
    {
        return $"{_type},{GetName()},{_description},{GetPoints()},{isComplete()}";
    }

    public override string GetDetailsString()
    {
        return $"[Negative Goal] {GetName()} ({_description}) - Points Deduction: {GetPenaltyPoints()}";
    }

    public int GetPenaltyPoints()
    {
        return _penaltyPoints;
    }
}

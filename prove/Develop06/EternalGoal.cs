/* 
This C# Program Code is made by Hazel Diane Fernandez for W06 Prove: Developer—Eternal Quest
*/

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points, int type) : base(name, description, points, type){}

    public override void RecordEvent(){}

    public override bool isComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"{_type},{GetName()},{_description},{GetPoints()}";
    }
}
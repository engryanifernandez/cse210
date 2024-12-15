public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points, int type) : base(name, description, points, type){}

    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool isComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{_type},{GetName()},{_description},{GetPoints()},{_isComplete}";
    }
}
public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int type, int target, int bonus) : base(name, description, points, type)
    {
        _target = target;
        _bonus = bonus;
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }

    public override void RecordEvent()
    {
        _amountCompleted += 1;
        if (_amountCompleted == _target)
        {
            SetPoints(int.Parse(GetPoints()) + _bonus);
        }
    }

    public override bool isComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        } else {
            return false;
        }
    }

    public override string GetStringRepresentation()
    {
        return $"{_type},{GetName()},{_description},{GetPoints()},{isComplete()},{_amountCompleted},{_target},{_bonus}";
    }

    public override string GetDetailsString()
    {
        string completed = isComplete() ? "X" : " "; 
        return $"[{completed}] {GetName()} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }
}
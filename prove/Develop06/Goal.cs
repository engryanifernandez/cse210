/* 
This C# Program Code is made by Hazel Diane Fernandez for W06 Prove: Developer—Eternal Quest
*/

public abstract class Goal{
    private string _shortName;
    protected string _description;
    private string _points;
    protected int _type;

    public Goal(string name, string description, string points, int type)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _type = type;
    }

    public abstract void RecordEvent();

    public abstract bool isComplete();

    public abstract string GetStringRepresentation();

    public string GetName()
    {
        return _shortName;
    }

    public string GetPoints()
    {
        return _points;
    }

    public void SetPoints(int points)
    {
        _points = points.ToString();
    }

    public virtual string GetDetailsString()
    {
        string completed = isComplete() ? "X" : " "; 
        return $"[{completed}] {_shortName} ({_description})";
    }
}
/* 
This C# Program Code is made by Hazel Diane Fernandez
for W07 Prove: Final Foundation—Inheritance and Polymorphism
*/

public class Data
{
    private List<string> _activityNames = new()
    {
        "Running", "Cycling", "Swimming"
    };
    private List<string> _activityDates = new()
    {
        "03 Nov 2022", "05 Nov 2022", "07 Nov 2022"
    };
    private List<int> _activityLengths = new()
    {
        30, 45, 15
    };

    public Data(){}

    public List<string> names {get {return _activityNames;}}
    public List<string> dates {get {return _activityDates;}}
    public List<int> lengths {get {return _activityLengths;}}
}
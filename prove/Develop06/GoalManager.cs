/* 
This C# Program Code is made by Hazel Diane Fernandez for W06 Prove: Developer—Eternal Quest
*/

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level = 1;
    private const int _pointsPerLevel = 200; // Points required for each level up or down.
    private const int _bonusPointsForLevelUp = 50; // Bonus points for leveling up.
    private const int _penaltyPointsForLevelDown = 60; // Penalty points for leveling down.

    public GoalManager() { }

    public void Start()
    {
        bool isRunning = true;

        // Set fixed leveling parameters
        DefineLevelingDetails();

        while (isRunning)
        {
            DisplayPlayerInfo();
            List<string> mainOptions = new List<string>
            {
                "1. Create New Goal",
                "2. List Goals",
                "3. Save Goals",
                "4. Load Goals",
                "5. Record Event",
                "6. Quit"
            };

            Console.WriteLine("Menu Options:");
            foreach (string option in mainOptions)
            {
                Console.WriteLine($"  {option}");
            }

            int menuChoice = GetValidMenuChoice();

            if (menuChoice == 1)
            {
                CreateGoal();
            }
            else if (menuChoice == 2)
            {
                ListGoalDetails();
            }
            else if (menuChoice == 3)
            {
                SaveGoals();
            }
            else if (menuChoice == 4)
            {
                LoadGoals();
            }
            else if (menuChoice == 5)
            {
                RecordEvent();
                CheckLevelUp();
            }
            else if (menuChoice == 6)
            {
                isRunning = false;
            }
        }
    }

    private void DefineLevelingDetails()
    {
        // Fixed settings
        Console.WriteLine("Level up/down system is set:");
        Console.WriteLine($"- Points per level: {_pointsPerLevel}");
        Console.WriteLine($"- Bonus for leveling up: {_bonusPointsForLevelUp}");
        Console.WriteLine($"- Penalty for leveling down: {_penaltyPointsForLevelDown}");
    }

    private void CheckLevelUp()
    {
        Console.WriteLine($"Current Score: {_score}, Current Level: {_level}");
        int targetPointsForNextLevel = _level * _pointsPerLevel;
        int targetPointsForPreviousLevel = (_level - 1) * _pointsPerLevel;

        Console.WriteLine($"Next Level Threshold: {targetPointsForNextLevel}, Previous Level Threshold: {targetPointsForPreviousLevel}");

        if (_score >= targetPointsForNextLevel)
        {
            _level++; // Increment level by 1
            _score += _bonusPointsForLevelUp; // Add bonus points
            Console.WriteLine($"Congratulations! You've leveled up to Level {_level}!");
            Console.WriteLine($"Bonus of {_bonusPointsForLevelUp} points awarded!");
        }
        else if (_score < targetPointsForPreviousLevel && _level > 1)
        {
            _level--; // Decrement level by 1
            _score -= _penaltyPointsForLevelDown; // Deduct penalty points
            Console.WriteLine($"Warning! You've leveled down to Level {_level}!");
            Console.WriteLine($"Penalty of {_penaltyPointsForLevelDown} points deducted!");
        }
    }

    private int GetValidMenuChoice()
    {
        int menuChoice;
        while (true)
        {
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out menuChoice) && menuChoice >= 1 && menuChoice <= 6)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid option (1-6).");
            }
        }
        return menuChoice;
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour current score: {_score}");
        Console.WriteLine($"Your current level: {_level}\n");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        string name;
        string description;
        string score;

        List<string> goalOptions = new List<string>
        {
            "1. Simple Goal",
            "2. Eternal Goal",
            "3. Checklist Goal",
            "4. Negative Goal"
        };

        Console.WriteLine("The types of Goals are:");
        foreach (string option in goalOptions)
        {
            Console.WriteLine($"  {option}");
        }

        int goalChoice = GetValidGoalChoice();

        if (goalChoice == 1)
        {
            Console.Write("What is the name of your goal? ");
            name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            score = Console.ReadLine();
            SimpleGoal newGoal = new SimpleGoal(name, description, score, goalChoice);
            _goals.Add(newGoal);

        }
        else if (goalChoice == 2)
        {
            Console.Write("What is the name of your goal? ");
            name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            score = Console.ReadLine();
            EternalGoal newGoal = new EternalGoal(name, description, score, goalChoice);
            _goals.Add(newGoal);

        }
        else if (goalChoice == 3)
        {
            Console.Write("What is the name of your goal? ");
            name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            score = Console.ReadLine();
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            ChecklistGoal newGoal = new ChecklistGoal(name, description, score, goalChoice, target, bonus);
            _goals.Add(newGoal);

        }
        else if (goalChoice == 4)
        {
            Console.Write("What is the name of your negative goal? ");
            name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            description = Console.ReadLine();
            Console.Write("How many points will you lose if this goal is recorded? ");
            int penaltyPoints = int.Parse(Console.ReadLine());
            NegativeGoal newGoal = new NegativeGoal(name, description, penaltyPoints.ToString(), 4);
            _goals.Add(newGoal);

        }
    }

    private int GetValidGoalChoice()
    {
        int goalChoice;
        while (true)
        {
            Console.Write("Which type of goal would you like to create? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out goalChoice) && goalChoice >= 1 && goalChoice <= 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid goal type (1-4).");
            }
        }
        return goalChoice;
    }


    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");

        int goal = int.Parse(Console.ReadLine());
        int goalPosition = goal - 1;
        Goal selectedGoal = _goals[goalPosition];

        selectedGoal.RecordEvent();

        // If it's a NegativeGoal, subtract the penalty points
        if (selectedGoal is NegativeGoal negativeGoal)
        {
            int penaltyPoints = negativeGoal.GetPenaltyPoints();
            _score -= penaltyPoints;  // Deduct the penalty points from the score
            Console.WriteLine($"Penalty of {penaltyPoints} points deducted for a Negative Goal.");
        }
        else
        {
            // Add score if goal is not negative
            _score += int.Parse(selectedGoal.GetPoints());  
        }

        // Update level immediately after the score is changed
        CheckLevelUp();  // This will adjust level based on the updated score
    }

    public void SaveGoals()
    {
        Console.Write("Enter the file name to save the goals: ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the file name to load the goals: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);

            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                int type = int.Parse(parts[0]);

                if (type == 1) // SimpleGoal
                {
                    _goals.Add(new SimpleGoal(parts[1], parts[2], parts[3], type));
                }
                else if (type == 2) // EternalGoal
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], parts[3], type));
                }
                else if (type == 3) // ChecklistGoal
                {
                    int amountCompleted = int.Parse(parts[5]);
                    int target = int.Parse(parts[6]);
                    int bonus = int.Parse(parts[7]);

                    ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], parts[3], type, target, bonus);
                    goal.SetAmountCompleted(amountCompleted);
                    _goals.Add(goal);
                }
                else if (type == 4) // NegativeGoal
                {
                    _goals.Add(new NegativeGoal(parts[1], parts[2], parts[3], type));
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

}


using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    
public void DisplayScore()
{
    Console.WriteLine($"Your current score is: {_score}");

    string level;

    if (_score >= 500)
    {
        level = "Eternal Legend";
    }
    else if (_score >= 300)
    {
        level = "Goal Champion";
    }
    else if (_score >= 100)
    {
        level = "Goal Seeker";
    }
    else
    {
        level = "Beginner";
    }

    Console.WriteLine($"Your current level is: {level}");
}

    public void ListGoals()
    {
        Console.WriteLine("\nYour goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You haven't created any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        if (_goals.Count == 0)
        {
            return;
        }

        Console.Write("\nWhich goal did you accomplish? Enter its number: ");

        if (int.TryParse(Console.ReadLine(), out int choice)
            && choice >= 1 && choice <= _goals.Count)
        {
            int pointsEarned = _goals[choice - 1].RecordEvent();
            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
            DisplayScore();
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nChoose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Your choice: ");

        string type = Console.ReadLine();

        Console.Write("What is the goal's name? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
        {
            Console.WriteLine("Please enter a valid non-negative number.");
            return;
        }

        switch (type)
        {
            case "1":
                AddGoal(new SimpleGoal(name, description, points));
                break;

            case "2":
                AddGoal(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("How many times must you complete it? ");
                if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                {
                    Console.WriteLine("Please enter a number greater than zero.");
                    return;
                }

                Console.Write("How many bonus points will you earn? ");
                if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
                {
                    Console.WriteLine("Please enter a valid non-negative number.");
                    return;
                }

                AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void SaveGoals()
    {
        Console.Write("Enter a filename to save your goals: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine($"Score|{_score}");

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception)
        {
            Console.WriteLine("Unable to save the file. Please check the filename.");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load your goals: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            List<Goal> loadedGoals = new List<Goal>();
            int loadedScore = 0;

            foreach (string line in File.ReadAllLines(filename))
            {
                string[] parts = line.Split('|');

                switch (parts[0])
                {
                    case "Score":
                        loadedScore = int.Parse(parts[1]);
                        break;

                    case "SimpleGoal":
                        loadedGoals.Add(new SimpleGoal(
                            parts[1], parts[2], int.Parse(parts[3]),
                            bool.Parse(parts[4])));
                        break;

                    case "EternalGoal":
                        loadedGoals.Add(new EternalGoal(
                            parts[1], parts[2], int.Parse(parts[3])));
                        break;

                    case "ChecklistGoal":
                        loadedGoals.Add(new ChecklistGoal(
                            parts[1], parts[2], int.Parse(parts[3]),
                            int.Parse(parts[4]), int.Parse(parts[5]),
                            int.Parse(parts[6])));
                        break;
                }
            }

            _goals = loadedGoals;
            _score = loadedScore;

            Console.WriteLine("Goals loaded successfully!");
            DisplayScore();
        }
        catch (Exception)
        {
            Console.WriteLine("Unable to load the file. Check its format.");
        }
    }
}
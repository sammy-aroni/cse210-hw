using System;

class Program
{
    static void Main(string[] args)
{
    // Creative feature: A leveling system rewards users as they earn points.
    // Users progress from Beginner to Goal Seeker, Goal Champion, and Eternal Legend.
    GoalManager manager = new GoalManager();
    string choice = "";

        while (choice != "7")
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            manager.DisplayScore();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Goal Event");
            Console.WriteLine("6. View Score");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;

                case "2":
                    manager.ListGoals();
                    break;

                case "3":
                    manager.SaveGoals();
                    break;

                case "4":
                    manager.LoadGoals();
                    break;

                case "5":
                    manager.RecordEvent();
                    break;

                case "6":
                    manager.DisplayScore();
                    break;

                case "7":
                    Console.WriteLine("Goodbye! Keep working toward your goals!");
                    break;

                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }
}
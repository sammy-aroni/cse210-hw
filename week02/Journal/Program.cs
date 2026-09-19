using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        // Creativity and exceeding requirements:
        // This program includes more than five prompts and a separate
        // PromptGenerator class to keep prompt management separate
        // from the Journal and Entry classes.

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Program");
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry(date, prompt, response);
                theJournal.AddEntry(newEntry);
            }
            else if (choice == 2)
            {
                theJournal.Display();
            }
            else if (choice == 3)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                theJournal.SaveToFile(filename);
            }
            else if (choice == 4)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                theJournal.LoadFromFile(filename);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
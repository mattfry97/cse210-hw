using System;  //console, datetime, string namespace
using System.Threading;  //Timer class to schedule code run times

// Program class
// Function : Handles user interaction
class Program{
    static void Main(string[] args){
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        while(true){
            Console.Clear();
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Choose an option above: ");

            string choice = Console.ReadLine();

            switch (choice){
                case "1":
                // get prompt
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                journal.AddEntry(prompt,response);
                break;

                case "2":
                // display journal 
                journal.DisplayEntries();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;

                case "3":
                // save journal
                Console.Write("Enter filename to save journal entry: ");
                string saveFilename = Console.ReadLine();
                journal.SaveToFile(saveFilename);
                Console.ReadKey();
                break;

                case "4":
                // load journal
                Console.Write("Enter filename to load journal: ");
                string loadFilename = Console.ReadLine();
                journal.LoadFromFile(loadFilename);
                Console.ReadKey();
                break;

                case "5":
                //exit
                return;

                default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
            }
        }
    }
}
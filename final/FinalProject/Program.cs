using System;
using System.Collections.Generic;
using System.Linq;
class Program{
    static void Main(string[] args){
        Console.WriteLine("Welcome to Fitness Tracker!");
        // Create a user
        User user = new User("Matthew Fry", 30, 180, 75);
            
        // Create a dashboard for the user
        Dashboard dashboard = new Dashboard(user);
            
        bool isRunning = true;
        while (isRunning){
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. View Profile");
            Console.WriteLine("2. Log a Workout");
            Console.WriteLine("3. Create a Goal");
            Console.WriteLine("4. View Progress");
            Console.WriteLine("5. View Dashboard");
            Console.WriteLine("6. Exit");
                
            string choice = Console.ReadLine();
                
            switch (choice){
                case "1":
                    user.DisplayProfile();
                    break;
                case "2":
                    LogWorkout(user);
                    break;
                case "3":
                    CreateGoal(user);
                    break;
                case "4":
                    ViewProgress(user);
                    break;
                case "5":
                    dashboard.Display();
                    break;
                case "6":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
            
        Console.WriteLine("Thank you for using Fitness Tracker!");
    }
        
    static void LogWorkout(User user){
        // Empty implementation
    }
    static void CreateGoal(User user){
        // Empty implementation
    }
        
    static void ViewProgress(User user){
        // Empty implementation
    }
}
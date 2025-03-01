using System;
using System.Collections.Generic;
using System.Threading;

class Program{
    static void Main(string[] args){
        bool quit = false;
        
        while (!quit){
            // Display menu
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            
            switch (choice){
                case "1":
                    Activity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    Activity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    break;
                case "3":
                    Activity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}
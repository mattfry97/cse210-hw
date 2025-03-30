using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;


public class Program
    {
        private static User _currentUser;
        private static readonly string _saveFilePath = "eternalquest.json";
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Eternal Quest!");
            
            // Try to load user data
            if (File.Exists(_saveFilePath))
            {
                if (TryLoadUser())
                {
                    Console.WriteLine($"Welcome back, {_currentUser.Username}!");
                }
                else
                {
                    CreateNewUser();
                }
            }
            else
            {
                CreateNewUser();
            }
            
            bool running = true;
            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine().Trim();
                
                switch (choice)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        DisplayUserInfo();
                        break;
                    case "5":
                        SaveUser();
                        Console.WriteLine("Data saved successfully!");
                        break;
                    case "6":
                        running = false;
                        SaveUser();
                        Console.WriteLine("Thank you for using Eternal Quest. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        
        private static void DisplayMenu()
        {
            Console.WriteLine("\n===== ETERNAL QUEST MENU =====");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. View User Info");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
        }
        
        private static void CreateNewUser()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine().Trim();
            _currentUser = new User(username);
            Console.WriteLine($"Welcome, {username}! Your quest begins now!");
        }
        
        private static void CreateNewGoal()
        {
            Console.WriteLine("\n===== GOAL TYPES =====");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Select a goal type: ");
            
            string typeChoice = Console.ReadLine().Trim();
            
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine().Trim();
            
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine().Trim();
            
            Console.Write("Enter point value: ");
            if (!int.TryParse(Console.ReadLine().Trim(), out int pointValue))
            {
                Console.WriteLine("Invalid point value. Goal creation cancelled.");
                return;
            }
            
            Goal newGoal;
            
            switch (typeChoice)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, pointValue);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, pointValue);
                    break;
                case "3":
                    Console.Write("Enter target completion count: ");
                    if (!int.TryParse(Console.ReadLine().Trim(), out int targetCount))
                    {
                        Console.WriteLine("Invalid target count. Goal creation cancelled.");
                        return;
                    }
                    
                    Console.Write("Enter bonus points for completion: ");
                    if (!int.TryParse(Console.ReadLine().Trim(), out int bonusPoints))
                    {
                        Console.WriteLine("Invalid bonus points. Goal creation cancelled.");
                        return;
                    }
                    
                    newGoal = new ChecklistGoal(name, description, pointValue, targetCount, bonusPoints);
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Goal creation cancelled.");
                    return;
            }
            
            _currentUser.AddGoal(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
        
        private static void ListGoals()
        {
            if (_currentUser.Goals.Count == 0)
            {
                Console.WriteLine("You don't have any goals yet. Create some goals first!");
                return;
            }
            
            Console.WriteLine("\n===== YOUR GOALS =====");
            for (int i = 0; i < _currentUser.Goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_currentUser.Goals[i].GetStringRepresentation()}");
                Console.WriteLine($"   {_currentUser.Goals[i].GetDetailsString()}");
            }
        }
        
        private static void RecordEvent()
        {
            if (_currentUser.Goals.Count == 0)
            {
                Console.WriteLine("You don't have any goals yet. Create some goals first!");
                return;
            }
            
            Console.WriteLine("\n===== RECORD EVENT =====");
            for (int i = 0; i < _currentUser.Goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_currentUser.Goals[i].Name}");
            }
            
            Console.Write("Which goal did you accomplish? (Enter number): ");
            if (int.TryParse(Console.ReadLine().Trim(), out int goalNumber) && goalNumber > 0 && goalNumber <= _currentUser.Goals.Count)
            {
                _currentUser.RecordEvent(goalNumber - 1);
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        
        private static void DisplayUserInfo()
        {
            Console.WriteLine("\n===== USER INFORMATION =====");
            Console.WriteLine($"Username: {_currentUser.Username}");
            Console.WriteLine($"Score: {_currentUser.Score} points");
            
            // Display completed goals count
            int completedGoals = _currentUser.Goals.Count(g => g.IsComplete());
            Console.WriteLine($"Goals completed: {completedGoals}/{_currentUser.Goals.Count}");
        }
        
        private static bool TryLoadUser()
        {
            try
            {
                string jsonData = File.ReadAllText(_saveFilePath);
                Dictionary<string, object> data = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonData);
                
                string username = data["Username"].ToString();
                int score = int.Parse(data["Score"].ToString());
                
                List<Goal> loadedGoals = new List<Goal>();
                var goalsData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(data["Goals"].ToString());
                
                foreach (var goalData in goalsData)
                {
                    string goalType = goalData["Type"].ToString();
                    string name = goalData["Name"].ToString();
                    string description = goalData["Description"].ToString();
                    int pointValue = int.Parse(goalData["PointValue"].ToString());
                    int totalPoints = int.Parse(goalData["TotalPointsEarned"].ToString());
                    
                    Goal goal = null;
                    
                    switch (goalType)
                    {
                        case "SimpleGoal":
                            bool isComplete = bool.Parse(goalData["IsComplete"].ToString());
                            goal = new SimpleGoal(name, description, pointValue, isComplete, totalPoints);
                            break;
                        case "EternalGoal":
                            int timesCompletedEternal = int.Parse(goalData["TimesCompleted"].ToString());
                            goal = new EternalGoal(name, description, pointValue, timesCompletedEternal, totalPoints);
                            break;
                        case "ChecklistGoal":
                            int timesCompletedChecklist = int.Parse(goalData["TimesCompleted"].ToString());
                            int targetCount = int.Parse(goalData["TargetCount"].ToString());
                            int bonusPoints = int.Parse(goalData["BonusPoints"].ToString());
                            goal = new ChecklistGoal(name, description, pointValue, targetCount, bonusPoints, 
                                                  timesCompletedChecklist, totalPoints);
                            break;
                    }
                    
                    if (goal != null)
                    {
                        loadedGoals.Add(goal);
                    }
                }
                
                _currentUser = new User(username, score, loadedGoals);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                return false;
            }
        }
        
        private static void SaveUser()
        {
            try
            {
                var userData = _currentUser.Serialize();
                string jsonData = JsonSerializer.Serialize(userData);
                File.WriteAllText(_saveFilePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }
    }
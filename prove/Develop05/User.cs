public class User
    {
        public string Username { get; private set; }
        public int Score { get; private set; }
        public List<Goal> Goals { get; private set; }
        
        public User(string username)
        {
            Username = username;
            Score = 0;
            Goals = new List<Goal>();
        }
        
        public User(string username, int score, List<Goal> goals)
        {
            Username = username;
            Score = score;
            Goals = goals;
        }
        
        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }
        
        public void RecordEvent(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < Goals.Count)
            {
                int pointsEarned = Goals[goalIndex].RecordEvent();
                if (pointsEarned > 0)
                {
                    AddPoints(pointsEarned);
                    Console.WriteLine($"You earned {pointsEarned} points!");
                }
            }
            else
            {
                Console.WriteLine("Invalid goal index.");
            }
        }
        
        public void AddPoints(int points)
        {
            Score += points;
        }
        
        public Dictionary<string, object> Serialize()
        {
            List<Dictionary<string, object>> serializedGoals = new List<Dictionary<string, object>>();
            foreach (var goal in Goals)
            {
                serializedGoals.Add(goal.Serialize());
            }
            
            return new Dictionary<string, object>
            {
                { "Username", Username },
                { "Score", Score },
                { "Goals", serializedGoals }
            };
        }
    }
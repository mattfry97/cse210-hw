public class EternalGoal : Goal
    {
        private int _timesCompleted;
        
        public EternalGoal(string name, string description, int pointValue) 
            : base(name, description, pointValue)
        {
            _timesCompleted = 0;
        }
        
        // Constructor for loading from file
        public EternalGoal(string name, string description, int pointValue, int timesCompleted, int totalPoints) 
            : base(name, description, pointValue)
        {
            _timesCompleted = timesCompleted;
            TotalPointsEarned = totalPoints;
        }
        
        public override bool IsComplete()
        {
            // Eternal goals are never complete
            return false;
        }
        
        public override int RecordEvent()
        {
            _timesCompleted++;
            TotalPointsEarned += PointValue;
            return PointValue;
        }
        
        public override string GetDetailsString()
        {
            return $"Eternal Goal - {PointValue} points each time - Completed {_timesCompleted} times";
        }
        
        public override string GetStringRepresentation()
        {
            // Modify the base representation to show it's an eternal goal
            return $"[∞] {Name} ({Description}) - Worth {PointValue} points each time";
        }
        
        public override Dictionary<string, object> Serialize()
        {
            var data = base.Serialize();
            data.Add("TimesCompleted", _timesCompleted);
            return data;
        }
    }

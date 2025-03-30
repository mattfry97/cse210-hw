public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _targetCount;
        private int _bonusPoints;
        
        public ChecklistGoal(string name, string description, int pointValue, int targetCount, int bonusPoints) 
            : base(name, description, pointValue)
        {
            _timesCompleted = 0;
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
        }
        
        // Constructor for loading from file
        public ChecklistGoal(string name, string description, int pointValue, int targetCount, 
                            int bonusPoints, int timesCompleted, int totalPoints) 
            : base(name, description, pointValue)
        {
            _timesCompleted = timesCompleted;
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            TotalPointsEarned = totalPoints;
        }
        
        public override bool IsComplete()
        {
            return _timesCompleted >= _targetCount;
        }
        
        public override int RecordEvent()
        {
            if (_timesCompleted < _targetCount)
            {
                _timesCompleted++;
                int pointsEarned = PointValue;
                
                // Award bonus on final completion
                if (_timesCompleted == _targetCount)
                {
                    pointsEarned += _bonusPoints;
                    Console.WriteLine($"Congratulations! You earned a bonus of {_bonusPoints} points!");
                }
                
                TotalPointsEarned += pointsEarned;
                return pointsEarned;
            }
            
            Console.WriteLine("This goal has already been completed the maximum number of times.");
            return 0;
        }
        
        public override string GetDetailsString()
        {
            return $"Checklist Goal - {PointValue} points each time " +
                   $"and {_bonusPoints} bonus points when done {_targetCount} times";
        }
        
        public override string GetStringRepresentation()
        {
            string completionStatus = IsComplete() ? "[X]" : "[ ]";
            return $"{completionStatus} {Name} ({Description}) - " +
                   $"Completed {_timesCompleted}/{_targetCount} times";
        }
        
        public override Dictionary<string, object> Serialize()
        {
            var data = base.Serialize();
            data.Add("TimesCompleted", _timesCompleted);
            data.Add("TargetCount", _targetCount);
            data.Add("BonusPoints", _bonusPoints);
            return data;
        }
    }

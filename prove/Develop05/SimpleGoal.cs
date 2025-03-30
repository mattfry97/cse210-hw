public class SimpleGoal : Goal
    {
        private bool _isComplete;
        
        public SimpleGoal(string name, string description, int pointValue) 
            : base(name, description, pointValue)
        {
            _isComplete = false;
        }
        
        // Constructor for loading from file
        public SimpleGoal(string name, string description, int pointValue, bool isComplete, int totalPoints) 
            : base(name, description, pointValue)
        {
            _isComplete = isComplete;
            TotalPointsEarned = totalPoints;
        }
        
        public override bool IsComplete()
        {
            return _isComplete;
        }
        
        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                TotalPointsEarned += PointValue;
                return PointValue;
            }
            
            Console.WriteLine("This goal has already been completed.");
            return 0;
        }
        
        public override string GetDetailsString()
        {
            return $"Simple Goal - {PointValue} points when completed";
        }
        
        public override Dictionary<string, object> Serialize()
        {
            var data = base.Serialize();
            data.Add("IsComplete", _isComplete);
            return data;
        }
    }
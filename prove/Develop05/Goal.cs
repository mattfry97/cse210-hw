public abstract class Goal
    {
        // Common properties for all goals
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int PointValue { get; protected set; }
        public int TotalPointsEarned { get; protected set; } = 0;
        
        // Constructor
        public Goal(string name, string description, int pointValue)
        {
            Name = name;
            Description = description;
            PointValue = pointValue;
        }
        
        // Abstract methods to be implemented by derived classes
        public abstract bool IsComplete();
        public abstract int RecordEvent();
        public abstract string GetDetailsString();
        
        // Base implementation for displaying goal in list
        public virtual string GetStringRepresentation()
        {
            string completionStatus = IsComplete() ? "[X]" : "[ ]";
            return $"{completionStatus} {Name} ({Description}) - Worth {PointValue} points";
        }
        
        // For serialization
        public virtual Dictionary<string, object> Serialize()
        {
            return new Dictionary<string, object>
            {
                { "Type", GetType().Name },
                { "Name", Name },
                { "Description", Description },
                { "PointValue", PointValue },
                { "TotalPointsEarned", TotalPointsEarned }
            };
        }
    }
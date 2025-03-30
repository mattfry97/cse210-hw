 public abstract class Goal{
    protected string name;
    protected DateTime targetDate;
    protected bool isCompleted;
    
    public Goal(string name, DateTime targetDate){
        this.name = name;
        this.targetDate = targetDate;
        this.isCompleted = false;
    }
        
    public string Name { get { return name; } }
    public DateTime TargetDate { get { return targetDate; } }
    public bool IsCompleted { get { return isCompleted; } }
        
    public abstract double CalculateProgress(User user);
        
    public void MarkAsCompleted(){
        // Empty implementation
    }
}
    

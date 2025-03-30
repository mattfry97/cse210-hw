public class WeightGoal : Goal{
    private double targetWeight;
        
    public WeightGoal(string name, DateTime targetDate, double targetWeight) : base(name, targetDate){
        this.targetWeight = targetWeight;
    }
        
    public double TargetWeight { get { return targetWeight; } }
        
    public override double CalculateProgress(User user){
        return 0;
    }
}
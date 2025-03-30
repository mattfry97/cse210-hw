public class WorkoutFrequencyGoal : Goal{
    private int targetWorkoutsPerWeek;
        
    public WorkoutFrequencyGoal(string name, DateTime targetDate, int targetWorkoutsPerWeek) : base(name, targetDate){
        this.targetWorkoutsPerWeek = targetWorkoutsPerWeek;
    }
        
    public int TargetWorkoutsPerWeek { get { return targetWorkoutsPerWeek; } }
        
    public override double CalculateProgress(User user){
        return 0;
    }
}
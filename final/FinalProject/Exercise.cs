 public abstract class Exercise{
    protected string name;
    protected string muscleGroup;
    protected TimeSpan duration;
        
    public Exercise(string name, string muscleGroup){
        this.name = name;
        this.muscleGroup = muscleGroup;
        this.duration = TimeSpan.Zero;
    }
        
    public string Name { get { return name; } }
    public string MuscleGroup { get { return muscleGroup; } }
    public TimeSpan Duration { get { return duration; } }
        
    public abstract double CalculateCaloriesBurned();
}
    

    
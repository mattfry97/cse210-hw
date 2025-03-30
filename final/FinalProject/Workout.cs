 public class Workout{
    private string name;
    private DateTime completionDate;
    private WorkoutType type;
    private List<Exercise> exercises;
    
    public Workout(string name, WorkoutType type){
        this.name = name;
        this.type = type;
        exercises = new List<Exercise>();
    }
        
    public string Name { get { return name; } }
    public DateTime CompletionDate { get { return completionDate; } }
    public WorkoutType Type { get { return type; } }
        
    public void SetCompletionDate(DateTime date){
        // Empty implementation
    }
        
    public void AddExercise(Exercise exercise){
        // Empty implementation
    }
        
    public List<Exercise> GetExercises(){
        return exercises;
    }
        
    public double CalculateTotalCaloriesBurned(){
        return 0;
    }
        
    public TimeSpan CalculateTotalDuration(){
        return TimeSpan.Zero;
    }
}
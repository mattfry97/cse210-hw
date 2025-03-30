public class User{
    private string name;
    private int age;
    private double height;
    private double weight;
    private List<Workout> workoutHistory;
    private List<Goal> goals;
    private List<Progress> progressHistory;
    
    public User(string name, int age, double height, double weight){
        this.name = name;
        this.age = age;
        this.height = height;
        this.weight = weight;
        workoutHistory = new List<Workout>();
        goals = new List<Goal>();
        progressHistory = new List<Progress>();
        
        // Initialize with a starting progress entry
        progressHistory.Add(new Progress(DateTime.Now, weight, 0));
    }
        
    public string Name { get { return name; } }
    public int Age { get { return age; } }
    public double Height { get { return height; } }
    public double Weight { get { return weight; } }
    
    public void DisplayProfile()   {
        // Empty implementation
    }
        
    public double CalculateBMI(){
        return 0;
    }
        
    public void LogWorkout(Workout workout){
        // Empty implementation
    }
        
    public int CountWorkoutsThisWeek(){
        return 0;
    }
        
    public void AddGoal(Goal goal){
        // Empty implementation
    }
        
    public List<Goal> GetGoals(){
        return goals;
    }
        
    public List<Workout> GetWorkoutHistory(){
        return workoutHistory;
    }
        
    public List<Progress> GetProgressHistory(){
        return progressHistory;
    }
        
    public void UpdateWeight(double newWeight){
        // Empty implementation
    }
}
public enum WorkoutType{
    Strength,
    Cardio,
    Flexibility,
    Mixed
}
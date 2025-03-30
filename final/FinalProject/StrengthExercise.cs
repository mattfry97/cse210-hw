public class StrengthExercise : Exercise{
    private int sets;
    private int reps;
    private double weight;
        
    public StrengthExercise(string name, string muscleGroup, int sets, int reps, double weight) : base(name, muscleGroup){
        this.sets = sets;
        this.reps = reps;
        this.weight = weight;
    }
        
    public int Sets { get { return sets; } }
    public int Reps { get { return reps; } }
    public double Weight { get { return weight; } }
        
    public override double CalculateCaloriesBurned(){
        return 0;
    }
}
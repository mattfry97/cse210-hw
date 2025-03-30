 public class CardioExercise : Exercise{
    private double distance;
        
    public CardioExercise(string name, string muscleGroup, int minutes, double distance) : base(name, muscleGroup){
        this.distance = distance;
    }
        
    public double Distance { get { return distance; } }
        
    public override double CalculateCaloriesBurned(){
        return 0;
    }
}
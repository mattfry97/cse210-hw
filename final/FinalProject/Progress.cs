public class Progress{
    private DateTime date;
    private double weight;
    private int workoutsThisWeek;
        
    public Progress(DateTime date, double weight, int workoutsThisWeek){
        this.date = date;
        this.weight = weight;
        this.workoutsThisWeek = workoutsThisWeek;
    }
        
    public DateTime Date { get { return date; } }
    public double Weight { get { return weight; } }
    public int WorkoutsThisWeek { get { return workoutsThisWeek; } }
}    
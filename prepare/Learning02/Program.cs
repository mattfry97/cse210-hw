using System;

class Program{
    static void Main(string[] args){
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Dell";
        job1._startYear = 2015;
        job1._endYear = 2019;

        Job job2 = new Job();
        job2._jobTitle = "Team Leader";
        job2._company = "Phillips";
        job2._startYear = 2019;
        job2._endYear = 2023;
        job1.Display();
        job2.Display();

        Resume resume = new Resume();
        resume._name = "Joe Fry";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume.Display();
    }
}
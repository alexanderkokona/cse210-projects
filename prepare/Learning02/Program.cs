using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Cybersecurity Analyst";
        job1._company = "Idaho National Labratories (INL)";
        job1._startYear = 2026;
        job1._endYear = 2036;

        Job job2 = new Job();
        job2._jobTitle = "CISO";
        job2._company = "Microsoft";
        job2._startYear = 2036;
        job2._endYear = 2046;

        Resume myResume = new Resume();
        myResume._name = "Alex Kokona";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}
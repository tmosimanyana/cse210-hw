using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation4 World!");
          List<Activity> activities = new List<Activity>();

        // Create activities
        activities.Add(new RunningActivity(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new CyclingActivity(new DateTime(2022, 11, 3), 30, 15));
        activities.Add(new SwimmingActivity(new DateTime(2022, 11, 3), 30, 10));

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

class Activity
{
    protected DateTime date;
    protected int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} {GetType().Name} ({minutes} min)";
    }
}

class RunningActivity : Activity
{
    private double distance;

    public RunningActivity(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / minutes) * 60;
    }

    public override double GetPace()
    {
        return minutes / distance;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $": Distance {distance} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class CyclingActivity : Activity
{
    private double speed;

    public CyclingActivity(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return (speed / 60) * (minutes / 60); // Convert minutes to hours
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $": Distance {GetDistance()} miles, Speed {speed} mph, Pace: {GetPace()} min per mile";
    }
}

class SwimmingActivity : Activity
{
    private int laps;

    public SwimmingActivity(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / (minutes / 60)) * 60; // Convert minutes to hours
    }

    public override double GetPace()
    {
        return minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $": Distance {GetDistance()} km, Speed {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}
    
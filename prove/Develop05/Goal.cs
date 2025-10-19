using System;

namespace EternalQuest
{
    // Base abstract goal class
    public abstract class Goal
    {
        // Encapsulated fields
        private string _title;
        private string _description;
        private int _points;

        // Properties
        public string Title { get => _title; set => _title = value ?? ""; }
        public string Description { get => _description; set => _description = value ?? ""; }
        public int Points { get => _points; protected set => _points = value; }

        // Whether this goal is complete (some goals like Eternal are never complete)
        public abstract bool IsComplete { get; }

        protected Goal(string title, string description, int points)
        {
            Title = title;
            Description = description;
            Points = points;
        }

        // Record an event (user completed the goal once). Returns points awarded.
        public abstract int RecordEvent();

        // Return a UI-friendly string showing state, overridden as needed
        public abstract string GetStatusString();

        // Return a line suitable for saving to disk
        public abstract string Serialize();

        // Factory to deserialize saved lines (simple parser)
        public static Goal Deserialize(string line)
        {
            // Expected formats:
            // Simple|title|desc|points|completed(true/false)
            // Eternal|title|desc|points
            // Checklist|title|desc|points|required|current|bonus
            var parts = line.Split('|');
            if (parts.Length < 1) throw new ArgumentException("Bad save line");

            var type = parts[0];
            switch (type)
            {
                case "Simple":
                    // Simple|title|desc|points|completed
                    if (parts.Length < 5) throw new ArgumentException("Bad Simple format");
                    var sTitle = parts[1];
                    var sDesc = parts[2];
                    var sPoints = int.Parse(parts[3]);
                    var sCompleted = bool.Parse(parts[4]);
                    var sg = new SimpleGoal(sTitle, sDesc, sPoints);
                    if (sCompleted) sg.MarkCompleteFromLoad();
                    return sg;

                case "Eternal":
                    // Eternal|title|desc|points
                    if (parts.Length < 4) throw new ArgumentException("Bad Eternal format");
                    var eTitle = parts[1];
                    var eDesc = parts[2];
                    var ePoints = int.Parse(parts[3]);
                    return new EternalGoal(eTitle, eDesc, ePoints);

                case "Checklist":
                    // Checklist|title|desc|points|required|current|bonus
                    if (parts.Length < 7) throw new ArgumentException("Bad Checklist format");
                    var cTitle = parts[1];
                    var cDesc = parts[2];
                    var cPoints = int.Parse(parts[3]);
                    var required = int.Parse(parts[4]);
                    var current = int.Parse(parts[5]);
                    var bonus = int.Parse(parts[6]);
                    var cg = new ChecklistGoal(cTitle, cDesc, cPoints, required, bonus);
                    cg.ForceSetCurrentFromLoad(current);
                    return cg;

                default:
                    throw new ArgumentException($"Unknown goal type {type}");
            }
        }
    }
}

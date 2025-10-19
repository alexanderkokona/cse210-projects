using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public override bool IsComplete => false; // never complete

        public EternalGoal(string title, string description, int points)
            : base(title, description, points)
        {
        }

        public override int RecordEvent()
        {
            // Every time recorded gives points
            return Points;
        }

        public override string GetStatusString()
        {
            return $"[∞] {Title} -- {Description} (Each time: {Points})";
        }

        public override string Serialize()
        {
            return $"Eternal|{Title}|{Description}|{Points}";
        }
    }
}

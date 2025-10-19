using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public override bool IsComplete => _completed;

        public SimpleGoal(string title, string description, int points)
            : base(title, description, points)
        {
            _completed = false;
        }

        // Mark complete used during load
        internal void MarkCompleteFromLoad() => _completed = true;

        public override int RecordEvent()
        {
            if (_completed)
            {
                // already completed -> 0 points
                return 0;
            }

            _completed = true;
            return Points;
        }

        public override string GetStatusString()
        {
            return $"[{(_completed ? "X" : " ")}] {Title} -- {Description} (Reward: {Points})";
        }

        public override string Serialize()
        {
            return $"Simple|{Title}|{Description}|{Points}|{_completed}";
        }
    }
}

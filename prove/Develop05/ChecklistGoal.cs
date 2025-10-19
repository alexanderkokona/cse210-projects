using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _required;
        private int _current;
        private int _bonus;

        public override bool IsComplete => _current >= _required;

        public ChecklistGoal(string title, string description, int pointsPer, int requiredCount, int bonus)
            : base(title, description, pointsPer)
        {
            _required = Math.Max(1, requiredCount);
            _current = 0;
            _bonus = Math.Max(0, bonus);
        }

        // Allow loading current progress
        internal void ForceSetCurrentFromLoad(int curr)
        {
            _current = Math.Max(0, curr);
        }

        public override int RecordEvent()
        {
            if (IsComplete)
            {
                return 0;
            }

            _current++;
            int awarded = Points;
            if (_current >= _required)
            {
                // Give bonus on completion
                awarded += _bonus;
            }
            return awarded;
        }

        public override string GetStatusString()
        {
            return $"[{(_current >= _required ? "X" : " ")}] {Title} -- {Description} (Completed {_current}/{_required}; Each: {Points}; Bonus on completion: {_bonus})";
        }

        public override string Serialize()
        {
            return $"Checklist|{Title}|{Description}|{Points}|{_required}|{_current}|{_bonus}";
        }
    }
}

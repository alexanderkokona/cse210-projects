using System;
using System.Collections.Generic;
using System.Linq;

namespace EternalQuest
{
    public class Player
    {
        private int _score;
        public int Score { get => _score; private set => _score = Math.Max(0, value); }

        // Leveling: simple thresholds; can expand to formula
        public int Level
        {
            get
            {
                if (Score >= 5000) return 10;
                if (Score >= 3000) return 8;
                if (Score >= 2000) return 6;
                if (Score >= 1000) return 4;
                if (Score >= 500) return 2;
                return 1;
            }
        }

        public Player()
        {
            _score = 0;
        }

        // Add points, return new level if level up happened (0 if no level change)
        public int AddPoints(int points)
        {
            if (points <= 0) return 0;
            int oldLevel = Level;
            Score += points;
            int newLevel = Level;
            return newLevel > oldLevel ? newLevel : 0;
        }

        public void SetScoreFromLoad(int score)
        {
            Score = score;
        }
    }
}

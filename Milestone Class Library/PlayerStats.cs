using System;
using System.Collections.Generic;

namespace Milestone_Class_Library
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string PlayerInitials { get; set; }
        public string DifficultyLevel { get; set; }
        public string TimeElapsed { get; set; }

        // Define the order of difficulty levels
        private static List<string> difficultyLevels = new List<string> { "Super Easy", "Easy", "Medium", "Hard" };

        public PlayerStats(string playerInitials, string difficultyLevel, string timeElapsed)
        {
            this.PlayerInitials = playerInitials;
            this.DifficultyLevel = difficultyLevel;
            this.TimeElapsed = timeElapsed;
        }

        // Implement the CompareTo method for sorting
        public int CompareTo(PlayerStats other)
        {
            if (other == null) return 1;

            // First, compare by difficulty level
            int difficultyComparison = difficultyLevels.IndexOf(this.DifficultyLevel).CompareTo(difficultyLevels.IndexOf(other.DifficultyLevel));

            // If the difficulties are equal, compare by time elapsed
            if (difficultyComparison == 0)
            {
                // The player with a shorter time (faster completion) comes first
                // Parsing strings to TimeSpan for comparison
                TimeSpan thisTime = TimeSpan.Parse(this.TimeElapsed);
                TimeSpan otherTime = TimeSpan.Parse(other.TimeElapsed);
                return thisTime.CompareTo(otherTime);
            }

            return difficultyComparison;
        }
    }
}
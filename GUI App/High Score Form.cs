using Milestone_Class_Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GUI_App
{
    public partial class High_Score_Form : Form
    {
        // Path to the file where we save/load our high scores
        private const string HighScoreFilePath = "highscores.txt";

        // List to store our high scores
        private List<PlayerStats> highScores;

        public High_Score_Form()
        {
            InitializeComponent();

            // Load the high scores from the file
            LoadHighScores();

            // Sort and display the high scores
            DisplayHighScores();
        }

        private void LoadHighScores()
        {
            highScores = new List<PlayerStats>();

            if (File.Exists(HighScoreFilePath))
            {
                string[] lines = File.ReadAllLines(HighScoreFilePath);

                // Read each line from the high score file and create PlayerStats objects
                for (int i = 0; i < lines.Length; i += 4)
                {
                    string initials = lines[i];
                    string difficulty = lines[i + 1];
                    string timeElapsed = lines[i + 2];

                    highScores.Add(new PlayerStats(initials, difficulty, timeElapsed));
                }
            }
        }

        public void AddHighScore(PlayerStats newScore)
        {
            // Add the new score to the list
            highScores.Add(newScore);

            // Sort and display the high scores
            DisplayHighScores();

            // Save the updated high scores to the file
            SaveHighScores();
        }

        private void SaveHighScores()
        {
            List<string> lines = new List<string>();

            // Create lines of text for each high score entry
            foreach (PlayerStats playerStats in highScores)
            {
                lines.Add(playerStats.PlayerInitials);
                lines.Add(playerStats.DifficultyLevel);
                lines.Add(playerStats.TimeElapsed.ToString());
                lines.Add(""); // Add empty line to separate players
            }

            // Write the lines to the high score file
            File.WriteAllLines(HighScoreFilePath, lines);
        }

        private void DisplayHighScores()
        {
            listBox_HighScores.Items.Clear();

            // Sort the high scores by difficulty level and time elapsed
            var sortedScores = highScores
                .OrderByDescending(score => GetDifficultyOrder(score.DifficultyLevel))
                .ThenBy(score => TimeSpan.Parse(score.TimeElapsed))
                .ToList();

            // Group the high scores by difficulty level
            var groupedScores = sortedScores
                .GroupBy(score => score.DifficultyLevel)
                .ToDictionary(group => group.Key, group => group.ToList());

            // Display the top 5 scores for each difficulty level
            foreach (var difficulty in groupedScores.Keys)
            {
                var scoresForDifficulty = groupedScores[difficulty].Take(5);

                // Display the top scores in the list box
                foreach (var score in scoresForDifficulty)
                {
                    listBox_HighScores.Items.Add($"{score.PlayerInitials} - {score.DifficultyLevel} - {score.TimeElapsed}");
                }
            }
        }

        private int GetDifficultyOrder(string difficultyLevel)
        {
            // Map difficulty levels to their corresponding order
            switch (difficultyLevel.ToLowerInvariant())
            {
                case "super easy":
                    return 1;
                case "easy":
                    return 2;
                case "medium":
                    return 3;
                case "hard":
                    return 4;
                default:
                    return 5;
            }
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/83201"/>
    [TestClass]
    public class 상호평가
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[,] { { 100, 90, 98, 88, 65 }, { 50, 45, 99, 85, 77 }, { 47, 88, 95, 80, 67 }, { 61, 57, 100, 80, 65 }, { 24, 90, 94, 75, 65 } }), "FBABD");
            Assert.AreEqual(solution(new int[,] { { 50, 90 }, { 50, 87 } }), "DA");
            Assert.AreEqual(solution(new int[,] { { 70, 49, 90 }, { 68, 50, 38 }, { 73, 31, 100 } }), "CFD");
        }

        public class Professor
        {
            Dictionary<int, List<int>> Scores = new Dictionary<int, List<int>>();

            Dictionary<int, double> AverageScores = new Dictionary<int, double>();

            public void InputScore(int[,] scores)
            {
                for (int column = 0; column < scores.GetLength(1); column++)
                {
                    var scoreSet = new List<int>();

                    for (int row = 0; row < scores.GetLength(0); row++)
                        scoreSet.Add(scores[row, column]);

                    Scores.Add(column, scoreSet);
                }
            }

            public string GetGrades()
            {
                var grades = new StringBuilder();

                CalculateAverageScore();

                foreach (var averageScore in AverageScores)
                    grades.Append(GetGrade(averageScore.Value));

                return grades.ToString();
            }

            private void CalculateAverageScore()
            {
                foreach (var score in Scores)
                {
                    var maxScore = score.Value.Max();
                    var minScore = score.Value.Min();
                    var selfScore = score.Value[score.Key];
                    double avgScore = 0;

                    if ((selfScore == maxScore && score.Value.Count(d => d == maxScore) == 1) || 
                        (selfScore == minScore && score.Value.Count(d => d == minScore) == 1))
                        avgScore = (score.Value.Sum() - selfScore) / (Scores.Count - 1);
                    else
                        avgScore = score.Value.Sum() / Scores.Count;

                    AverageScores.Add(score.Key, avgScore);
                }
            }

            private char GetGrade(double score)
            {
                if (score >= 90)
                    return 'A';
                else if (score >= 80 && score < 90)
                    return 'B';
                else if (score >= 70 && score < 80)
                    return 'C';
                else if (score >= 50 && score < 70)
                    return 'D';
                else
                    return 'F';
            }
        }

        public string solution(int[,] scores)
        {
            var professor = new Professor();

            professor.InputScore(scores);

            return professor.GetGrades();
        }
    }
}

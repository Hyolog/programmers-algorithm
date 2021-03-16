using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref=""/>
    [TestClass]
    public class 모의고사
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 1, 2, 3, 4, 5 }), new int[] { 1 });
            CollectionAssert.AreEqual(solution(new int[] { 1, 3, 2, 4, 2 }), new int[] { 1, 2, 3 });
            CollectionAssert.AreEqual(solution(new int[] {  }), new int[] { 1, 2, 3 });
        }

        public int[] solution(int[] answers)
        {
            var firstPattern = new int[] { 1, 2, 3, 4, 5 };
            var secondPattern = new int[] { 2, 1, 2, 3, 2, 4, 2, 5 };
            var thridPattern = new int[] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };

            var scores = new Dictionary<int, int>();

            scores.Add(1, GetScore(answers, firstPattern));
            scores.Add(2, GetScore(answers, secondPattern));
            scores.Add(3, GetScore(answers, thridPattern));

            var maxScore = scores.Max(d => d.Value);

            return scores.Where(d => d.Value == maxScore).Select(d => d.Key).ToArray();
        }

        public int GetScore(int[] answers, int[] pattern)
        {
            var score = 0;
            var index = 0;

            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == pattern[index])
                    score++;

                index++;

                if (index == pattern.Length)
                    index -= pattern.Length;
            }

            return score;
        }
    }
}

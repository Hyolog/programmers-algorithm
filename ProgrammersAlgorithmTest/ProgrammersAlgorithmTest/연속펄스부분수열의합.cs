using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/161988"/>
    [TestClass]
    public class 연속펄스부분수열의합
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 2, 3, -6, 1, 3, -1, 2, 4 }), 10);
        }

        public long solution(int[] sequence)
        {
            var seq = sequence.ToList();

            List<int> seq1 = Purse(seq, 1);
            List<int> seq2 = Purse(seq, -1);

            long answer = long.MinValue;
            long[] dp1 = new long[seq1.Count];
            long[] dp2 = new long[seq2.Count];

            dp1[0] = seq1[0];
            dp2[0] = seq2[0];

            for (int i = 1; i < seq1.Count; i++)
            {
                dp1[i] = Math.Max(dp1[i - 1] + seq1[i], seq1[i]);
                answer = Math.Max(answer, dp1[i]);
            }

            for (int i = 1; i < seq2.Count; i++)
            {
                dp2[i] = Math.Max(dp2[i - 1] + seq2[i], seq2[i]);
                answer = Math.Max(answer, dp2[i]);
            }

            if (seq.Count == 1)
            {
                answer = Math.Max(seq1[0], seq2[0]);
            }

            return answer;
        }

        private List<int> Purse(List<int> sequence, int start)
        {
            List<int> result = new List<int>();
            int sign = start;

            foreach (var item in sequence)
            {
                result.Add(item * sign);
                sign *= -1;
            }

            return result;
        }
    }
}

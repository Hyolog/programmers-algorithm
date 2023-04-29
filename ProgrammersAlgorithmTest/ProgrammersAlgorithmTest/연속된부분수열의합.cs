using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/178870"/>
    [TestClass]
    public class 연속된부분수열의합
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 2, 2, 2, 2, 2 }, 6), new int[] { 0, 2 });
            CollectionAssert.AreEqual(solution(new int[] { 1, 2, 3, 4, 5 }, 7), new int[] { 2, 3 });
            CollectionAssert.AreEqual(solution(new int[] { 1, 1, 1, 2, 3, 4, 5 }, 5), new int[] { 6, 6 });
        }

        public int[] solution(int[] sequence, int k)
        {
            int length = sequence.Length;
            int[] answer = { -1, -1 };
            int start = 0;
            long sum = 0;
            Dictionary<long, int> map = new Dictionary<long, int>();

            for (int i = 0; i < length; i++) {
                sum += sequence[i];

                if (sum > k) {
                    while (sum > k && start <= i) {
                        sum -= sequence[start];
                        start++;
                    }
                }

                if (sum == k) {
                    if (answer[0] == -1 || i - start < answer[1] - answer[0]) {
                        answer[0] = start;
                        answer[1] = i;
                    }
                }

                if (map.ContainsKey(sum - k)) {
                    int idx = map[sum - k];

                    if (answer[0] == -1 || i - idx < answer[1] - answer[0]) {
                        answer[0] = idx + 1;
                        answer[1] = i;
                    }
                }

                map[sum] = i;
            }

            return answer;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/132265"/>
    [TestClass]
    public class 롤케이크자르기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 1, 2, 1, 3, 1, 4, 1, 2 }), 2);
            Assert.AreEqual(solution(new int[] { 1, 2, 3, 1, 4 }), 0);
        }

        public int solution(int[] topping)
        {
            int answer = 0;
            Dictionary<int, int> m1 = new Dictionary<int, int>();
            Dictionary<int, int> m2 = new Dictionary<int, int>();

            foreach (int i in topping)
            {
                if (m2.ContainsKey(i))
                    m2[i]++;
                else
                    m2.Add(i, 1);
            }

            for (int i = 0; i < topping.Count() - 1; i++)
            {
                if (m1.ContainsKey(topping[i]))
                    m1[topping[i]]++;
                else
                    m1.Add(topping[i], 1);

                m2[topping[i]]--;

                if (m2[topping[i]] == 0)
                    m2.Remove(topping[i]);

                if (m1.Count == m2.Count)
                    answer++;
            }

            return answer;
        }
    }
}


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12929"/>
    [TestClass]
    public class 올바른괄호의갯수
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(1), 1);
            Assert.AreEqual(solution(2), 2);
            Assert.AreEqual(solution(3), 5);
        }

        /// <param name="n">1~14</param>
        /// <returns></returns>
        public int solution(int n)
        {
            // A1..An을 가지고 An+1을 구한다.
            // An+1은 An에서 괄호 한쌍이 더 추가된 케이스이다.
            // 추가된 괄호를 기준으로 n쌍의 괄호들은 추가된 괄호의 안 또는 밖에 존재할 수 있다.
            // An+1 = A0 * An + A1 * An-1 ... + An * Ao 

            return GetAnswer(n);
        }

        private int GetAnswer(int n)
        {
            var answer = 0;

            if (n == 0 || n == 1)
                return 1;

            for (int i = 0; i < n; i++)
                answer += GetAnswer(i) * GetAnswer((n - 1) - i);

            return answer;
        }
    }
}

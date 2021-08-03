using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/68935"/>
    /// TODO : Lv1 치고 어렵다.
    [TestClass]
    public class 삼진법뒤집기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(45), 7);
        }

        public int solution(int n)
        {
            string reverseTernary = "";

            while (n > 0)
            {
                reverseTernary += n % 3;

                if (n / 3 == 0)
                    break;

                n /= 3;
            }

            int result = 0;

            for (var i = 0; i < reverseTernary.Length; i++)
            {
                result += int.Parse(reverseTernary[i].ToString()) * (int)Math.Pow(3, reverseTernary.Length - 1 - i);
            }

            return result;
        }

        // 좋은 풀이 기록
        public int solution2(int n)
        {
            int answer = 0;
            while (n > 0)
            {
                answer *= 3;
                answer += n % 3;
                n /= 3;
            }
            return answer;
        }
    }
}

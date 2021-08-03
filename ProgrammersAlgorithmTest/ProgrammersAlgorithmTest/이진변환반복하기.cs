using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/70129"/>
    [TestClass]
    public class 이진변환반복하기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution("110010101001"), new int[] { 3, 8 });
        }

        public int[] solution(string s)
        {
            var answer = new int[2];

            while (s != "1")
            {
                var length = s.Length;
                var newLength = s.Replace("0", "").Length;

                s = Convert.ToString(newLength, 2);

                answer[0]++;
                answer[1] += length - newLength;
            }

            return answer;
        }
    }
}

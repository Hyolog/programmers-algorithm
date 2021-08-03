using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12904"/>
    /// TODO : 신경쓸 엣지포인트가 제법 있었다.
    [TestClass]
    public class 가장긴팰린드롬
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("abcdcba"), 7);
            Assert.AreEqual(solution("abacde"), 3);

            Assert.AreEqual(solution("a"), 1);
            Assert.AreEqual(solution("aa"), 2);
            Assert.AreEqual(solution("aaa"), 3);
            Assert.AreEqual(solution("aabaabcbaabcdcba"), 9);
            Assert.AreEqual(solution("aaabbbaaa"), 9);
            Assert.AreEqual(solution("abccbad"), 6);
            Assert.AreEqual(solution("abcde"), 1);

            Assert.AreEqual(solution("abacde"), 3);
            Assert.AreEqual(solution("abcabcdcbae"), 7);
            Assert.AreEqual(solution("aaaa"), 4);
            Assert.AreEqual(solution("abcde"), 1);
            Assert.AreEqual(solution("abcbaqwertrewqq"), 9);
            Assert.AreEqual(solution("abcbaqwqabcba"), 13);
            Assert.AreEqual(solution("abba"), 4);
            Assert.AreEqual(solution("abaabaaaaaaa"), 7);
        }

        public int solution(string s)
        {
            if (s.Length == 1)
                return 1;

            var answer = 1;

            for (int i = 0; i < s.Length; i++)
            {
                var preIndex = i - 1;
                var currentIndex = i;
                var nextIndex = i + 1;

                var tempAnswer = GetPalindromeLength(s, preIndex, nextIndex) + 1;

                if (tempAnswer > answer)
                    answer = tempAnswer;

                tempAnswer = GetPalindromeLength(s, currentIndex, nextIndex);

                if (tempAnswer > answer)
                    answer = tempAnswer;
            }

            return answer;
        }

        private int GetPalindromeLength(string s, int leftIndex, int rightIndex)
        {
            var length = 0;

            while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex].Equals(s[rightIndex]))
            {
                length += 2;
                leftIndex--;
                rightIndex++;
            }

            return length;
        }
    }
}

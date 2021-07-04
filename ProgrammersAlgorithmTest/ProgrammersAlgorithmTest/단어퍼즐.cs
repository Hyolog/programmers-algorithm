using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12983?language=csharp"/>
    /// 다시 풀어보기
    [TestClass]
    public class 단어퍼즐
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new string[] { "ba", "na", "n", "a" }, "banana"), 3);
            Assert.AreEqual(solution(new string[] { "app", "ap", "p", "l", "e", "ple", "pp" }, "apple"), 2);
            Assert.AreEqual(solution(new string[] { "ba", "an", "nan", "ban", "n" }, "banana"), -1);
        }

        public static int solution(string[] strs, string t)
        {
            int[] result = new int[t.Length];

            for (var index = 0; index < t.Length; index++)
            {
                result[index] = t.Length + 1;

                foreach (string word in strs)
                {
                    if (word[word.Length - 1] == t[index] && index >= word.Length - 1)
                    {
                        if (word.Equals(t.Substring(index - word.Length + 1, word.Length)))
                        {
                            result[index] = (index - word.Length) < 0 ? 1 : result[index] > result[index - word.Length] + 1 ? result[index - word.Length] + 1 : result[index];
                        }
                    }
                }
            }

            return result[t.Length - 1] <= t.Length ? result[t.Length - 1] : -1;
        }
    }
}

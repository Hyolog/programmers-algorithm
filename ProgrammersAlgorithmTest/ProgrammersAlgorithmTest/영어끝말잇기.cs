//https://programmers.co.kr/learn/courses/30/lessons/12981

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 영어끝말잇기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(3, new string[] { "tank", "kick", "know", "wheel", "land", "dream", "mother", "robot", "tank" }), new int[] { 3, 3 });
            CollectionAssert.AreEqual(solution(2, new string[] { "tank", "kick", "know", "wheel", "land", "dream" }), new int[] { 0, 0 });
            CollectionAssert.AreEqual(solution(2, new string[] { "hello", "one", "even", "never", "now", "world", "draw" }), new int[] { 1, 3 });
        }

        public int[] solution(int n, string[] words)
        {
            var usedWords = new List<string>();
            int turn = 0;

            for (var i = 0; i < words.Length; i++)
            {
                // 몇바퀴째인지 기록
                if (i % n == 0)
                    turn++;

                // 이미 나온 단어이거나, 끝말을 잇지 못했을 경우
                if (usedWords.Contains(words[i]) || (i > 0 && !words[i - 1][words[i - 1].Length - 1].Equals(words[i][0])))
                {
                    return new int[] { i % n + 1, turn };
                }
                else
                {
                    usedWords.Add(words[i]);
                }
            }

            return new int[] { 0, 0 };
        }
    }
}

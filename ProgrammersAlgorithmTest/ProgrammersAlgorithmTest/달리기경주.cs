using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/178871"/>
    [TestClass]
    public class 달리기경주
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new string[] { "mumu", "soe", "poe", "kai", "mine" }, new string[] { "kai", "kai", "mine", "mine" }), new string[] { "mumu", "kai", "mine", "soe", "poe" });
        }

        public string[] solution(string[] players, string[] callings)
        {
            var dic = new Dictionary<string, int>();
            var rank = 0;

            foreach (var player in players)
            {
                dic.Add(player, rank++);
            }

            foreach (var calling in callings)
            {
                var index = dic[calling];
                dic[calling] -= 1;
                dic[players[index - 1]] += 1;

                var temp = players[index - 1];
                players[index - 1] = players[index];
                players[index] = temp;
            }

            return players;
        }
    }
}

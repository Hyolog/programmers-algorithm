using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref=""/>
    [TestClass]
    public class 카드뭉치
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new string[] { "i", "drink", "water" }, new string[] { "want", "to" }, new string[] { "i", "want", "to", "drink", "water" }), "Yes");
            Assert.AreEqual(solution(new string[] { "i", "water", "drink" }, new string[] { "want", "to" }, new string[] { "i", "want", "to", "drink", "water" }), "No");
        }

        public string solution(string[] cards1, string[] cards2, string[] goal)
        {
            var card1Index = 0;
            var card2Index = 0;

            foreach (var item in goal)
            {
                if (card1Index < cards1.Length && cards1[card1Index] == item)
                {
                    card1Index++;
                    continue;
                }
                else if (card2Index < cards2.Length && cards2[card2Index] == item)
                {
                    card2Index++;
                    continue;
                }
                else
                {
                    return "No";
                }
            }

            return "Yes";
        }
    }
}

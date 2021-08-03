using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42584"/>
    [TestClass]
    public class 주식가격
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 1, 2, 3, 2, 3 }), new int[] { 4, 3, 1, 1, 0 });
        }

        public int[] solution(int[] prices)
        {
            var result = new int[prices.Length];

            for (int i = 0; i < prices.Length - 1; i++)
            {
                // 가격이 떨어지지 않는다고 가정
                result[i] = prices.Length - (i + 1);
                
                for (int j = i + 1; j < prices.Length; j++)
                {
                    if (prices[i] > prices[j])
                    {
                        // 만약 떨어지면 업데이트
                        result[i] = j - i;
                        break;
                    }
                }
            }

            result[prices.Length - 1] = 0;

            return result;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/82612"/>
    [TestClass]
    public class 부족한금액계산하기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(3, 20, 4), 10);
            Assert.AreEqual(solution(5, 10, 2), 5);
            Assert.AreEqual(solution(10, 100, 2), 0);
        }

        public long solution(int price, int money, int count)
        {
            long totalPrice = (long)((price + price * count) * (double)count / 2);

            return totalPrice <= money ? 0 : totalPrice - money;
        }
    }
}

//https://programmers.co.kr/learn/courses/30/lessons/12947

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 하샤드수
    {
        [TestMethod]
        public void Test()
        {

        }

        public bool solution(int x)
        {
            var sum = 0;

            foreach (var item in x.ToString())
            {
                sum += int.Parse(item.ToString());
            }

            return x % sum == 0 ? true : false;
        }
    }
}

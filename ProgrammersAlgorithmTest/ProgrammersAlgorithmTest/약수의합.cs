using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12928"/>
    [TestClass]
    public class 약수의합
    {
        [TestMethod]
        public void Test()
        {

        }

        public int solution(int n)
        {
            var result = 0;
            var index = 1;

            while (index <= n)
            {
                if (n % index == 0)
                    result += index;

                index++;
            }

            return result;
        }
    }
}

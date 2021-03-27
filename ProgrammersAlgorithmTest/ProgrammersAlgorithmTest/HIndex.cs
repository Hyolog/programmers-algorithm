using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42747"/>
    [TestClass]
    public class HIndex
    {
        [TestMethod]
        public void Test()
        {

        }

        public int solution(int[] citations)
        {
            var pivot = (int)citations.Average();

            citations.OrderBy(d => d);

            while (citations.Where(d => d >= pivot).Count() < pivot)
            {
                pivot /= 2;
            }

            for (int result = pivot * 2; result >= pivot; result--)
            {
                if (citations.Where(d => d >= result).Count() >= result)
                    return result;
            }

            return 0;
        }
    }
}

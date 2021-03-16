using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12910"/>
    [TestClass]
    public class 나누어떨어지는숫자배열
    {
        public int[] solution(int[] arr, int divisor)
        {
            var result = new List<int>();

            foreach (var item in arr)
            {
                if (item % divisor == 0)
                    result.Add(item);
            }

            return result.Count == 0 ? new int[] { -1 } : result.OrderBy(d => d).ToArray();
        }
    }
}

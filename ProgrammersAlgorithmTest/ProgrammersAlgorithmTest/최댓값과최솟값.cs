//https://programmers.co.kr/learn/courses/30/lessons/12939

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 최댓값과최솟값
    {
        public string solution(string s)
        {
            var tempResult = s.Split(' ').Select(d => long.Parse(d));

            return $"{tempResult.Min()} {tempResult.Max()}";
        }
    }
}

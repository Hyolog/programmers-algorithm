using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12937"/>
    [TestClass]
    public class 짝수와홀수
    {
        public string solution(int num)
        {
            return num % 2 == 0 ? "Even" : "Odd";
        }
    }
}

//https://programmers.co.kr/learn/courses/30/lessons/12922

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 수박수박수박수박수박수
    {
        public string solution(int n)
        {
            var result = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    result.Append("박");
                }
                else
                {
                    result.Append("수");
                }
            }

            return result.ToString();
        }
    }
}

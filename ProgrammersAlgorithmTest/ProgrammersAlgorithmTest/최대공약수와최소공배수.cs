using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12940"/>
    [TestClass]
    public class 최대공약수와최소공배수
    {
        [TestMethod]
        public void Test()
        {

        }

        public int[] solution(int n, int m)
        {
            return new int[] { GetGCD(n, m), GetLCM(n, m) };
        }

        private int GetGCD(int n, int m)
        {
            var tempResult = -1;
            var num1 = n > m ? n : m;
            var num2 = n > m ? m : n;

            while (tempResult != 0)
            {
                tempResult = num1 % num2;
                num1 = num2;
                num2 = tempResult;
            }

            return num1;
        }

        private int GetLCM(int n, int m)
        {
            var tempN = n;
            var tempM = m;

            while (tempN != tempM)
            {
                if (tempN > tempM)
                    tempM += m;
                else
                    tempN += n;
            }

            return tempN;
        }
    }
}

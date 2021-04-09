using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12950"/>
    [TestClass]
    public class 행렬의덧셈
    {
        [TestMethod]
        public void Test()
        {

        }

        public int[,] solution(int[,] arr1, int[,] arr2)
        {
            for (var i = 0; i < arr1.GetLength(1); i++)
            {
                for (var j = 0; j < arr1.GetLength(0); j++)
                {
                    arr1[i, j] += arr2[i, j];
                }
            }

            return arr1;
        }
    }
}

//https://programmers.co.kr/learn/courses/30/lessons/12949

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 행렬의곱셈
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[,] { { 1, 4 }, { 3, 2 }, { 4, 1 } }, new int[,] { { 3, 3 }, { 3, 3 } }), new int[,] { { 15, 15 }, { 15, 15 }, { 15, 15 } });
        }

        public int[,] solution(int[,] arr1, int[,] arr2)
        {
            // (l x m) x (m x n) = l x n
            var result = new int[arr1.GetLength(0), arr2.GetLength(1)];

            // l loop
            for (var l = 0; l < arr1.GetLength(0); l++)
            {
                // m loop
                for (var m = 0; m < arr2.GetLength(0); m++)
                {
                    // n
                    for (var n = 0; n < arr2.GetLength(1); n++)
                    {
                        result[l, n] += arr1[l, m] * arr2[m, n];
                    }
                }
            }

            return result;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/86491"/>
    [TestClass]
    public class 최소직사각형
    {
        [TestMethod]
        public void Test()
        {

        }

        public int solution(int[,] sizes)
        {
            var maxWidth = 0;
            var maxHeight = 0;

            for (int i = 0; i < sizes.GetLength(1); i++)
            {
                if (sizes[i, 0] < sizes[i, 1])
                {
                    maxWidth = Math.Max(maxWidth, sizes[i, 1]);
                    maxHeight = Math.Max(maxHeight, sizes[i, 0]);
                }
                else
                {
                    maxWidth = Math.Max(maxWidth, sizes[i, 0]);
                    maxHeight = Math.Max(maxHeight, sizes[i, 1]);
                }
            }

            return maxWidth * maxHeight;
        }
    }
}

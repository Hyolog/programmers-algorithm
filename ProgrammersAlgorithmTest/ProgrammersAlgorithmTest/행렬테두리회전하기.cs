using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/77485"/>
    [TestClass]
    public class 행렬테두리회전하기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(6, 6, new int[,] { { 2, 2, 5, 4 }, { 3, 3, 6, 6 }, { 5, 1, 6, 3 } } ), new int[] { 8, 10, 25 });
            CollectionAssert.AreEqual(solution(3, 3, new int[,] { { 1, 1, 2, 2 }, { 1, 2, 2, 3 }, { 2, 1, 3, 2 }, { 2, 2, 3, 3 } }), new int[] { 1, 1, 5, 3 });
            CollectionAssert.AreEqual(solution(100, 97, new int[,] { { 1, 1, 100, 97 }}), new int[] { 1 });
        }

        int[,] matrix;

        public int[] solution(int rows, int columns, int[,] queries)
        {
            matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    matrix[i, j] = i * columns + (j + 1);

            var answer = new List<int>();
            
            for (int i = 0; i < queries.GetLength(0); i++)
                answer.Add(RotateAndGetMinValue(queries[i, 0], queries[i, 1], queries[i, 2], queries[i, 3]));

            return answer.ToArray();
        }

        private int RotateAndGetMinValue(int x1, int y1, int x2, int y2)
        {
            var minvalue = int.MaxValue;

            x1 -= 1;
            y1 -= 1;
            x2 -= 1;
            y2 -= 1;

            var tempValue = matrix[x1, y1];

            for (int i = y1; i < y2; i++)
            {
                var temp = matrix[x1, i + 1];
                matrix[x1, i + 1] = tempValue;
                tempValue = temp;

                minvalue = Math.Min(minvalue, tempValue);
            }

            for (int i = x1; i < x2; i++)
            {
                var temp = matrix[i + 1, y2];
                matrix[i + 1, y2] = tempValue;
                tempValue = temp;

                minvalue = Math.Min(minvalue, tempValue);
            }

            for (int i = y2; i > y1; i--)
            {
                var temp = matrix[x2, i - 1];
                matrix[x2, i - 1] = tempValue;
                tempValue = temp;

                minvalue = Math.Min(minvalue, tempValue);
            }

            for (int i = x2; i > x1; i--)
            {
                var temp = matrix[i - 1, y1];
                matrix[i - 1, y1] = tempValue;
                tempValue = temp;

                minvalue = Math.Min(minvalue, tempValue);
            }

            return minvalue;
        }
    }
}

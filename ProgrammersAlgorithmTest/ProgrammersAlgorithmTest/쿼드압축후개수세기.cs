using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/68936"/>
    /// TODO : Lv2 문제 맞음? 체감 3정도
    [TestClass]
    public class 쿼드압축후개수세기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[,] { { 1, 1, 0, 0 }, { 1, 0, 0, 0  }, { 1, 0, 0, 1 }, { 1, 1, 1, 1 } }), new int[2] { 4, 9 });
            CollectionAssert.AreEqual(solution(new int[,] { { 1, 1, 1, 1, 1, 1, 1, 1 }, { 0, 1, 1, 1, 1, 1, 1, 1 },{ 0, 0, 0, 0, 1, 1, 1, 1 },{ 0, 1, 0, 0, 1, 1, 1, 1 },{ 0, 0, 0, 0, 0, 0, 1, 1 },{ 0, 0, 0, 0, 0, 0, 0, 1 },{ 0, 0, 0, 0, 1, 0, 0, 1 },{ 0, 0, 0, 0, 1, 1, 1, 1 } }), new int[2] { 10, 15 });
        }

        public int[] solution(int[,] arr)
        {
            var result = Compress(arr, new Tuple<int, int>(0, 0), arr.GetLength(0));

            return new int[2] { result.Item1, result.Item2 };
        }

        private Tuple<int, int> Compress(int[,] arr, Tuple<int, int> startIndex, int length)
        {
            if (length == 1)
            {
                if (arr[startIndex.Item1, startIndex.Item2] == 0)
                    return new Tuple<int, int>(1, 0);
                else
                    return new Tuple<int, int>(0, 1);
            }

            var sum = 0;

            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    sum += arr[startIndex.Item1 + i, startIndex.Item2 + j];
                }
            }

            if (sum == 0)
            {
                return new Tuple<int, int>(1, 0);
            }
            else if (sum == length * length)
            {
                return new Tuple<int, int>(0, 1);
            }
            else
            {
                length /= 2;

                var a = Compress(arr, new Tuple<int, int>(startIndex.Item1, startIndex.Item2), length);
                var b = Compress(arr, new Tuple<int, int>(startIndex.Item1 + length, startIndex.Item2), length);
                var c = Compress(arr, new Tuple<int, int>(startIndex.Item1, startIndex.Item2 + length), length);
                var d = Compress(arr, new Tuple<int, int>(startIndex.Item1 + length, startIndex.Item2 + length), length);

                return new Tuple<int, int>(a.Item1 + b.Item1 + c.Item1 + d.Item1, a.Item2 + b.Item2 + c.Item2 + d.Item2);
            }
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/1844"/>
    /// TODO : BFS
    [TestClass]
    public class 게임맵최단거리
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[,] { { 1, 0, 1, 1, 1 }, { 1, 0, 1, 0, 1 }, { 1, 0, 1, 1, 1 }, { 1, 1, 1, 0, 1 }, { 0, 0, 0, 0, 1 } }), 11);
            Assert.AreEqual(solution(new int[,] { { 1, 0, 1, 1, 1 }, { 1, 0, 1, 0, 1 }, { 1, 0, 1, 1, 1 }, { 1, 1, 1, 0, 0 }, { 0, 0, 0, 0, 1 } }), -1);

            Assert.AreEqual(solution(new int[,] { { 1 }, { 1 } }), 2);
            Assert.AreEqual(solution(new int[,] { { 1, 1 } }), 2);
            Assert.AreEqual(solution(new int[,] { { 1, 1 }, { 1, 1 } }), 3);
            Assert.AreEqual(solution(new int[,] { { 1, 0 }, { 0, 1 } }), -1);

            Assert.AreEqual(solution(new int[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } }), 7);
            Assert.AreEqual(solution(new int[,] { { 1 }, { 1 }, { 1 }, { 1 }, { 1 }, { 1 }, { 1 }, { 1 }, { 1 }, { 1 } }), 10);
            Assert.AreEqual(solution(new int[,] { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } }), 10);
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Step { get; set; }

            public Point(int x, int y, int step)
            {
                X = x;
                Y = y;
                Step = step;
            }
        }

        /// <param name="maps">n x m(1 <= n, m <= 100)</param>
        public int solution(int[,] maps)
        {
            // 벽(0)으로 둘러쌓인 테두리가 있는 맵 생성
            var width = maps.GetLength(1) + 2;
            var height = maps.GetLength(0) + 2;

            var map = new int[height, width];

            // 길 표시
            for (int y = 0; y < maps.GetLength(0); y++)
            {
                for (int x = 0; x < maps.GetLength(1); x++)
                {
                    if (maps[y, x] == 1)
                    {
                        map[y + 1, x + 1] = 1;
                    }
                }
            }

            // 목표 지점 설정
            var goalX = maps.GetLength(1);
            var goalY = maps.GetLength(0);

            map[1, 1] = 0;
            var minStep = int.MaxValue;

            var steps = new Queue();
            var startPoint = new Point(1, 1, 1);
            steps.Enqueue(startPoint);

            while (steps.Count != 0)
            {
                var point = steps.Dequeue() as Point;

                if (point.X.Equals(goalX) && point.Y.Equals(goalY))
                    minStep = point.Step;

                if (map[point.Y, point.X + 1] == 1)
                {
                    steps.Enqueue(new Point(point.X + 1, point.Y, point.Step + 1));
                    map[point.Y, point.X + 1] = 0;
                }
                if (map[point.Y + 1, point.X] == 1)
                {
                    steps.Enqueue(new Point(point.X, point.Y + 1, point.Step + 1));
                    map[point.Y + 1, point.X] = 0;
                }
                if (map[point.Y, point.X - 1] == 1)
                {
                    steps.Enqueue(new Point(point.X - 1, point.Y, point.Step + 1));
                    map[point.Y, point.X - 1] = 0;
                }
                if (map[point.Y - 1, point.X] == 1)
                {
                    steps.Enqueue(new Point(point.X, point.Y - 1, point.Step + 1));
                    map[point.Y - 1, point.X] = 0;
                }
            }

            if (minStep.Equals(int.MaxValue))
                return -1;
            else
                return minStep;
        }
    }
}

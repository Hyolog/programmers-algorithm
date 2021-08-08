using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/1844"/>
    /// DONE : BFS
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

        // 문제 정의상 아래로 내려가는 것이 y+
        public int solution(int[,] maps)
        {
            var mapXLength = maps.GetLength(1);
            var mapYLength = maps.GetLength(0);

            // 테두리를 고려한 맵 (0이 벽이므로 기본적으로 모두 벽 상태)
            var mapWithBorder = new int[mapYLength + 2, mapXLength + 2];

            // 벽이 없는 자리 세팅
            for (int x = 0; x < mapXLength; x++)
            {
                for (int y = 0; y < mapYLength; y++)
                {
                    mapWithBorder[y + 1, x + 1] = maps[y, x];
                }
            }

            var startPoint = new Point(1, 1, 1);
            var goalPoint = new Point(mapXLength, mapYLength);
            var steps = new Queue();
            var minStep = -1;
            
            steps.Enqueue(startPoint);
            
            while (steps.Count != 0)
            {
                var currentPoint = steps.Dequeue() as Point;

                if (currentPoint.Equals(goalPoint))
                    minStep = currentPoint.Step;

                // 갈수있는 길이면 steps에 넣고 방문표시
                var upPoint = currentPoint.MoveUp();
                
                if (mapWithBorder[upPoint.Y, upPoint.X] == 1)
                {
                    steps.Enqueue(upPoint);
                    mapWithBorder[upPoint.Y, upPoint.X] = 0;
                }

                var downPoint = currentPoint.MoveDown();

                if (mapWithBorder[downPoint.Y, downPoint.X] == 1)
                {
                    steps.Enqueue(downPoint);
                    mapWithBorder[downPoint.Y, downPoint.X] = 0;
                }

                var leftPoint = currentPoint.MoveLeft();

                if (mapWithBorder[leftPoint.Y, leftPoint.X] == 1)
                {
                    steps.Enqueue(leftPoint);
                    mapWithBorder[leftPoint.Y, leftPoint.X] = 0;
                }

                var rightPoint = currentPoint.MoveRight();

                if (mapWithBorder[rightPoint.Y, rightPoint.X] == 1)
                {
                    steps.Enqueue(rightPoint);
                    mapWithBorder[rightPoint.Y, rightPoint.X] = 0;
                }
            }

            return minStep;
        }

        public class Point
        {
            public Point(int x, int y, int step = -1)
            {
                X = x;
                Y = y;
                Step = step;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Step { get; set; }

            public Point MoveUp()
            {
                return new Point(X, Y - 1, Step + 1);
            }

            public Point MoveDown()
            {
                return new Point(X, Y + 1, Step + 1);
            }

            public Point MoveLeft()
            {
                return new Point(X + 1, Y, Step + 1);
            }

            public Point MoveRight()
            {
                return new Point(X - 1, Y, Step + 1);
            }

            public override bool Equals(object obj)
            {
                if (obj is Point)
                {
                    var point = obj as Point;

                    return point.X.Equals(X) && point.Y.Equals(Y);
                }

                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/172928"/>
    [TestClass]
    public class 공원산책
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new string[3] { "SOO", "OOO", "OOO" }, new string[3] { "E 2", "S 2", "W 1" }), new int[2] { 2, 1 });
            CollectionAssert.AreEqual(solution(new string[3] { "SOO", "OXX", "OOO" }, new string[3] { "E 2", "S 2", "W 1" }), new int[2] { 0, 1 });
            CollectionAssert.AreEqual(solution(new string[4] { "OSO", "OOO", "OXO", "OOO" }, new string[3] { "E 2", "S 3", "W 1" }), new int[2] { 0, 0 });
        }

        public int[] solution(string[] park, string[] routes)
        {
            int x = 0;
            int y = 0;

            var width = park[0].Length;
            var height = park.Length;

            char[,] map = new char[height, width];

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    map[h, w] = park[h][w];

                    if (park[h][w] == 'S')
                    {
                        x = w;
                        y = h;
                    }
                }
            }

            foreach (var route in routes)
            {
                var splitedRoute = route.Split(' ');
                var direction = splitedRoute[0];
                var value = int.Parse(splitedRoute[1]);

                int tempX = x;
                int tempY = y;
                bool pass = true;

                for (int i = 0; i < value; i++)
                {
                    switch (direction)
                    {
                        case "N": tempY--; break;
                        case "S": tempY++; break;
                        case "W": tempX--; break;
                        case "E": tempX++; break;
                    }

                    if (tempX < 0 || tempX >= width || tempY < 0 || tempY >= height)
                    {
                        pass = false;
                        break;
                    }
                    else
                    {
                        if (map[tempY, tempX] == 'X')
                        {
                            pass = false;
                            break;
                        }
                    }
                }

                if (pass)
                {
                    x = tempX;
                    y = tempY;
                }
            }

            return new int[2] { y, x };
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/161990"/>
    [TestClass]
    public class 바탕화면정리
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new string[] { ".#...", "..#..", "...#." }), new int[] { 0, 1, 3, 4 });
            CollectionAssert.AreEqual(solution(new string[] { "..........", ".....#....", "......##..", "...##.....", "....#....." }), new int[] { 1, 3, 5, 8 });
            CollectionAssert.AreEqual(solution(new string[] { ".##...##.", "#..#.#..#", "#...#...#", ".#.....#.", "..#...#..", "...#.#...", "....#...." }), new int[] { 0, 0, 7, 9 });
            CollectionAssert.AreEqual(solution(new string[] { "..", "#." }), new int[] { 1, 0, 2, 1 });
            CollectionAssert.AreEqual(solution(new string[] { "....", ".#..", "....", "...." }), new int[] { 1, 1, 2, 2 });
        }
        public int[] solution(string[] wallpaper)
        {
            int lux = -1;
            int luy = -1;
            int rdx = -1;
            int rdy = -1;

            for (var y = 0; y < wallpaper.Length; y++) 
            {
                var row = wallpaper[y];

                for (int x = 0; x < row.Length; x++)
                {
                    if (row[x] == '#')
                    {
                        if (lux == -1 || x < lux)
                        {
                            lux = x;
                        }
                        if (luy == -1 || y < luy)
                        {
                            luy = y;
                        }
                        if (rdx == -1 || x > rdx)
                        {
                            rdx = x;
                        }
                        if (rdy == -1 || y > rdy)
                        {
                            rdy = y;
                        }
                    }
                }
            }

            return new int[] { luy, lux, rdy + 1, rdx + 1 };
        }
    }
}

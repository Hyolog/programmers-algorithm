using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/155651"/>
    [TestClass]
    public class 호텔대실
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new string[,] { { "15:00", "17:00" }, { "16:40", "18:20" }, { "14:20", "15:20" }, { "14:10", "19:20" }, { "18:20", "21:20" } }), 3);
            Assert.AreEqual(solution(new string[,] { { "09:10", "10:10" }, { "10:20", "12:20" } }), 1);
            Assert.AreEqual(solution(new string[,] { { "10:20", "12:30" }, { "10:20", "12:30" }, { "10:20", "12:30" } }), 3);
        }

        public int solution(string[,] book_time)
        {
            var length = 24 * 60 + 10;
            int answer = 0;

            var bookedRoomCount = new int[length];
            for (int i = 0; i < book_time.GetLength(0); i++)
            {
                var start_hour = book_time[i, 0].Split(":");
                var start_minute = int.Parse(start_hour[0]) * 60 + int.Parse(start_hour[1]);
                var end_hour = book_time[i, 1].Split(":");
                var end_minute = int.Parse(end_hour[0]) * 60 + int.Parse(end_hour[1]);

                bookedRoomCount[start_minute] += 1;
                bookedRoomCount[end_minute + 10] += -1;
            }

            for (int i = 1; i < length; i++)
            {
                bookedRoomCount[i] += bookedRoomCount[i - 1];
                answer = Math.Max(answer, bookedRoomCount[i]);
            }

            return answer;
        }
    }
}

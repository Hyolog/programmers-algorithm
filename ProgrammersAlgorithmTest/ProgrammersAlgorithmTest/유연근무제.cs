using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/389478"/>
    [TestClass]
    public class 유연근무제
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 700, 800, 1100 }, new int[,] { { 710, 2359, 1050, 700, 650, 631, 659 }, { 800, 801, 805, 800, 759, 810, 809 }, { 1105, 1001, 1002, 600, 1059, 1001, 1100 } }, 5), 3);
            Assert.AreEqual(solution(new int[] { 730, 855, 700, 720 }, new int[,] { { 710, 700, 650, 735, 700, 931, 912 }, { 908, 901, 805, 815, 800, 831, 835 }, { 705, 701, 702, 705, 710, 710, 711 }, { 707, 731, 859, 913, 934, 931, 905 } }, 1), 2);

        }

        public int solution(int[] schedules, int[,] timelogs, int startday)
        {
            // schedules -> 출근 희망 시각
            // timelogs -> 직원들 출근 기록
            // startday -> 시작 날짜 (주말 무시)
            int answer = 0;

            for (int i = 0; i < schedules.Length; i++)
            {
                bool good = true;
                int schedule = schedules[i];
                int allowed = GetAllowedLatestTime(schedule);

                for (int j = 0; j < 7; j++)
                {
                    int weekday = (startday + j) % 7;
                    if (weekday == 0 || weekday == 6) continue; // 일, 토 제외

                    if (timelogs[i, j] > allowed)
                    {
                        good = false;
                        break;
                    }
                }

                if (good) answer++;
            }

            return answer;
        }

        int GetAllowedLatestTime(int scheduleTime)
        {
            int hour = scheduleTime / 100;
            int minute = scheduleTime % 100;

            minute += 10;
            if (minute >= 60)
            {
                hour += 1;
                minute -= 60;
            }

            return hour * 100 + minute;
        }
    }
}

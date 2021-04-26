using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12901"/>
    [TestClass]
    public class 년2016
    {
        [TestMethod]
        public void Test()
        {

        }

        public string solution(int a, int b)
        {
            var date = new DateTime(2016, a, b);

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday: return "SUN";
                case DayOfWeek.Monday: return "MON";
                case DayOfWeek.Tuesday: return "TUE";
                case DayOfWeek.Wednesday: return "WED";
                case DayOfWeek.Thursday: return "THU";
                case DayOfWeek.Friday: return "FRI";
                case DayOfWeek.Saturday: return "SAT";
            }

            throw new Exception();
        }
    }
}

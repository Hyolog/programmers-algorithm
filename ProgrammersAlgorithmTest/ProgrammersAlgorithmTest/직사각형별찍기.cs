using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12969"/>
    [TestClass]
    public class 직사각형별찍기
    {
        [TestMethod]
        public void Test()
        {

        }

        public static void Main()
        {
            String[] s;

            Console.Clear();
            s = Console.ReadLine().Split(' ');

            int a = Int32.Parse(s[0]);
            int b = Int32.Parse(s[1]);

            Console.WriteLine("{0}", a + b);
        }
    }
}

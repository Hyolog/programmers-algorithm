//https://programmers.co.kr/learn/courses/30/lessons/12911

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 다음큰숫자
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(78), 83);
            Assert.AreEqual(solution(15), 23);
        }

        private int CountOf1(int num)
        {
            var countOf1 = 0;
            var binary = Convert.ToString(num, 2);

            foreach (var item in binary)
            {
                if (item == '1')
                    countOf1++;
            }

            return countOf1;

            //why time out?
            //return Convert.ToString(num, 2).Where(d => d == '1').Count();
        }

        public int solution(int n)
        {
            var countOf1 = CountOf1(n);
            var nextNum = n + 1;

            while (true)
            {
                var nextCountOf1 = CountOf1(nextNum);

                if (nextCountOf1 == countOf1)
                    return nextNum;

                nextNum++;
            }

            //var binary = Convert.ToString(n, 2);
            //var index = 0;

            //for (int i = 1; i <= binary.Length; i++)
            //{
            //    index = binary.Length - i;

            //    // 우측을 시작점으로 처음으로 나오는 '1'을 찾는다.
            //    if (binary[index] == '1')
            //    {
            //        // 이때의 index가 0 이다 = [100...]꼴이다
            //        if (index == 0)
            //        {
            //            // 뒤에 0하나 추가해주고 리턴
            //            binary += "0";
            //            return Convert.ToInt32(binary, 2); ;
            //        }

            //        // '1'왼쪽이 '0'이라면
            //        if (binary[index - 1] == '0')
            //        {
            //            // '1'을 왼쪽으로 한칸 옮겨주고 리턴
            //            binary = binary.Remove(index - 1, 1).Insert(index - 1, "1");
            //            binary = binary.Remove(index, 1).Insert(index, "0");
            //            return Convert.ToInt32(binary, 2);
            //        }
            //        // '1'왼쪽이 '0'이 아니라면
            //        else
            //        {
            //            // 하지만 '1'의 왼쪽이 마지막 자리 였다면 [11000...]꼴이다.
            //            if (index - 1 == 0)
            //            {
            //                binary = binary.Remove(index, 1).Insert(index, "0");
            //                binary += "1";
            //                return Convert.ToInt32(binary, 2);
            //            }

            //            // 그게 아니라면 계속 왼쪽으로 이동하며 '0'을 찾는다.
            //            for (int j = 1; j <= binary.Length - i; j++)
            //            {
            //                var tempIndex = index - j;

            //                // '0'을 찾았으면
            //                if (binary[tempIndex] == '0')
            //                {
            //                    binary = binary.Remove(tempIndex, 1).Insert(tempIndex, "1");
            //                    binary = binary.Remove(tempIndex + 1, 1).Insert(tempIndex + 1, "0");

            //                    // 그 이하 문자열 잘라서 뒤집기
            //                    var tempString = binary.Substring(tempIndex + 2);

            //                    binary = binary.Remove(tempIndex + 2, binary.Length - (tempIndex + 2));

            //                    binary += new string(tempString.ToCharArray().Reverse().ToArray());

            //                    return Convert.ToInt32(binary, 2);
            //                }
            //            }
            //        }
            //    }
            //}

            //return Convert.ToInt32(binary, 2);
        }
    }
}

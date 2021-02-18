//https://programmers.co.kr/learn/courses/30/lessons/49995

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 쿠키구입
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 1, 1, 2, 3 }), 3);
            Assert.AreEqual(solution(new int[] { 1, 2, 4, 5 }), 0);
            Assert.AreEqual(solution(new int[] { 9, 5, 6, 8, 3, 5, 2, 1 }), 14);
        }

        /// <param name="cookie">1~2000</param> N^2 = 4,000,000, N^3 = 8,000,000,000 ~= 8초
        /// 선택할 값은 3개(l, m, r)
        // 모든케이스 따지면 N^3 수렴해서 효율성에서 막힐 것 같음 
        // IsValid() 함수 만들고
        // Valid여부를 적절히 섞어서 N^2 ~ N^2LogN 으로 끊어본다.

        // O(N^2)
        public int solution(int[] cookie)
        {
            var maxCount = 0;

            for (var i = 0; i < cookie.Count() - 1; i++)
            {
                var left = i;
                var right = i + 1;
                var leftSum = cookie[i];
                var rightSum = cookie[i+1];
                
                while (true)
                {
                    if (leftSum == rightSum && maxCount < leftSum)
                    {
                        maxCount = leftSum;
                    }
                    else if (leftSum > rightSum)
                    {
                        if (right == (cookie.Count() - 1))
                            break;

                        right++;
                        rightSum += cookie[right];
                    }
                    else
                    {
                        if (left == 0)
                            break;

                        left--;
                        leftSum += cookie[left];
                    }
                }
            }

            return maxCount;
        }

        // O(N^3)
        public int solution2(int[] cookie)
        {
            int cookies = 0;
            var length = cookie.Count() - 1;

            // N
            for (var l = 0; l < length; l++)
            {
                var left = 0;
                
                //N / 2
                for (var m = l; m < length; m++)
                {
                    // l ~ m 합
                    left += cookie[m];

                    var right = 0;
                    var index = m + 1;

                    // m + 1 ~ r 합
                    while (true)
                    {
                        right += cookie[index];

                        if (left == right && cookies < left)
                        {
                            cookies = left;
                            break;
                        }
                        else if (left <= right)
                            break;
                        else if (index == length)
                            break;

                        index++;
                    }
                }
            }

            return cookies;
        }
    }
}


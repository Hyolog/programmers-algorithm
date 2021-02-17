//https://programmers.co.kr/learn/courses/30/lessons/12980

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 점프와순간이동
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(5), 2);
            Assert.AreEqual(solution(6), 2);
            Assert.AreEqual(solution(5000),5);
        }

        //pseudoCode
        //최대한 순간이동을 많이 이용하는것 + 거꾸로 이동하는것이 포인트
        //순간이동은 n이 짝수일때 사용했다고 가정할 수 있다 (2로 나눌 수 있으니)
        //즉 짝수면 순간이동을 했다고 가정, 짝수가 아니면 짝수를 만들어주는것을 반복
        //n이 짝수면 /2 (순간이동)
        //n이 홀수면 -1 (점프)
        
        // n : 1~10억 = O(N)안에 풀어야 1초컷
        public int solution(int n)
        {
            var count = 0;

            while (true)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n -= 1;
                    count++;
                }

                if (n < 1)
                    return count;
            }
        }
    }
}

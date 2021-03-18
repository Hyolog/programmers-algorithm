using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12909"/>
    /// 보자마자 Stack 생각했는데 편견일수도..
    /// Stack 안쓰고 stackCount로 체크만 + 빨리 끝낼 수 있는 조건 추가
    [TestClass]
    public class 올바른괄호
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("()()"), true);
            Assert.AreEqual(solution("(())()"), true);
            Assert.AreEqual(solution(")()("), false);
            Assert.AreEqual(solution("(()("), false);
        }

        public bool solution(string s)
        {
            var stackCount = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (stackCount == 0)
                {
                    if (s[i].Equals('('))
                        stackCount++;
                    else
                        return false;
                }
                else
                {
                    if (s[i].Equals(')'))
                        stackCount--;
                    else
                        stackCount++;
                }

                if (stackCount > s.Length - i)
                    return false;
            }

            return stackCount == 0;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 스킬트리
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("CBD", new string[] { "BACDE", "CBADF", "AECB", "BDA" }), 2);
            Assert.AreEqual(solution("CBD", new string[] { "CAD" }), 0);
            Assert.AreEqual(solution("CBD", new string[] { "CAB" }), 1);
            Assert.AreEqual(solution("CBD", new string[] { "AEF", "ZJW" }), 2);
            Assert.AreEqual(solution("ABC", new string[] { "AGQ" }), 1);
            Assert.AreEqual(solution("ABC", new string[] { "OPQ" }), 1);
        }

        public int solution(string skill, string[] skill_trees)
        {
            int answer = 0;

            foreach (var skillTree in skill_trees)
            {
                var skillIndex = 0;

                var lastItem = skillTree.Last();
                foreach (var item in skillTree)
                {
                    // 해당스킬이 선행스킬 리스트에 포함되어있으면
                    if (skill.Contains(item))
                    {
                        // 선행스킬이 없다면 pass
                        if (skill[skillIndex].Equals(item))
                        {
                            skillIndex++;
                        }
                        // 선행스킬이 남아있다면 잘못된 스킬트리
                        else
                        {
                            break;
                        }
                    }

                    // if and of index
                    if (item.Equals(lastItem))
                    {
                        answer++;
                    }
                }
            }

            return answer;
        }
    }
}

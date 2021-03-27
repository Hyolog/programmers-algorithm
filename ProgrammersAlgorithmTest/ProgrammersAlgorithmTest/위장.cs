using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42578"/>
    [TestClass]
    public class 위장
    {
        [TestMethod]
        public void Test()
        {

        }

        public int solution(string[,] clothes)
        {
            int answer = 1;

            // 각 타입별로 담을 딕셔너리
            Dictionary<string, List<string>> clothes_dic = new Dictionary<string, List<string>>();

            // 타입별로 딕셔너리에 저장
            for (int i = 0; i < clothes.GetLength(0); i++)
            {
                if (clothes_dic.ContainsKey(clothes[i, 1]) == false)
                {
                    clothes_dic[clothes[i, 1]] = new List<string>();
                }

                clothes_dic[clothes[i, 1]].Add(clothes[i, 0]);
            }

            // 딕셔너리에 저장된 데이터 갯수를 이용하여 계산
            foreach (KeyValuePair<string, List<string>> cloth in clothes_dic)
            {
                answer *= cloth.Value.Count() + 1;
            }

            answer--;

            return answer;
        }
    }
}

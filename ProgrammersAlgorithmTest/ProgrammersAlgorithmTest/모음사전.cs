using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/84512"/>
    /// TODO : DFS로 풀어보기
    [TestClass]
    public class 모음사전
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("AAAAE"), 6);
            Assert.AreEqual(solution("AAAE"), 10);
            Assert.AreEqual(solution("EIO"), 1189);
            Assert.AreEqual(solution("I"), 1563);
        }

        public int solution(string word)
        {
            char[] tempWord = new char[5] { 'A', ' ', ' ', ' ', ' ' };
            var index = 1;

            while (word != new string(tempWord).Trim())
            {
                tempWord = GetNextWord(tempWord);
                index++;
            }

            return index;
        }

        private char[] GetNextWord(char[] word)
        {
            var wordLength = word.Count(d => d != ' ');

            if (wordLength == 5)
            {
                var maxIndex = wordLength - 1;

                while (word[maxIndex].Equals('U'))
                {
                    word[maxIndex] = ' ';
                    maxIndex--;
                }

                word[maxIndex] = GetNextAlphabet(word[maxIndex]);
            }
            else
                word[wordLength] = 'A';

            return word;
        }

        private char GetNextAlphabet(char alphabet)
        {
            switch (alphabet)
            {
                case 'A': return 'E';
                case 'E': return 'I';
                case 'I': return 'O';
                case 'O': return 'U';
                default: throw new Exception("Invalid parameter");
            }
        }
    }
}

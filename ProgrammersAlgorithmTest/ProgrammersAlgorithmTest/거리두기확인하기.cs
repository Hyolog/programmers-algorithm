using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/81302"/>
    [TestClass]
    public class 거리두기확인하기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new string[,] { { "POOOP", "OXXOX", "OPXPX", "OOXOX", "POXXP" }, { "POOPX", "OXPXP", "PXXXO", "OXXXO", "OOOPP" }, { "PXOPX", "OXOXP", "OXPOX", "OXXOP", "PXPOX" }, { "OOOXX", "XOOOX", "OOOXX", "OXOOX", "OOOOO" }, { "PXPXP", "XPXPX", "PXPXP", "XPXPX", "PXPXP" } }), new int[] { 1, 0, 1, 1, 1 });
        }

        public class Room
        {
            public char[,] SettingInfo { get; set; } = new char[5, 5];

            public bool IsSafe()
            {
                for (int rowIndex = 0; rowIndex < 5; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                    {
                        if (SettingInfo[rowIndex, columnIndex].Equals('P'))
                        {
                            if (!IsSafeManhattan1(columnIndex, rowIndex))
                                return false;
                            if (!IsSafeManhattan2(columnIndex, rowIndex))
                                return false;
                        }
                    }
                }

                return true;
            }

            private bool IsSafeManhattan1(int x, int y)
            {
                if (y - 1 >= 0 && SettingInfo[y - 1, x].Equals('P'))
                    return false;
                if (x + 1 < 5 && SettingInfo[y, x + 1].Equals('P'))
                    return false;
                if (y + 1 < 5 && SettingInfo[y + 1, x].Equals('P'))
                    return false;
                if (x - 1 >= 0 && SettingInfo[y, x - 1].Equals('P'))
                    return false;

                return true;
            }

            private bool IsSafeManhattan2(int x, int y)
            {
                if (y - 2 >= 0 && SettingInfo[y - 2, x].Equals('P') && SettingInfo[y - 1, x].Equals('O'))
                    return false;
                if (x + 2 < 5 && SettingInfo[y, x + 2].Equals('P') && SettingInfo[y, x + 1].Equals('O'))
                    return false;
                if (y + 2 < 5 && SettingInfo[y + 2, x].Equals('P') && SettingInfo[y + 1, x].Equals('O'))
                    return false;
                if (x - 2 >= 0 && SettingInfo[y, x - 2].Equals('P') && SettingInfo[y, x - 1].Equals('O'))
                    return false;

                if (x - 1 >= 0 && y - 1 >= 0 && SettingInfo[y - 1, x - 1].Equals('P') && (SettingInfo[y - 1, x].Equals('O') || SettingInfo[y, x - 1].Equals('O')))
                    return false;
                if (x + 1 < 5 && y - 1 >= 0 && SettingInfo[y - 1, x + 1].Equals('P') && (SettingInfo[y - 1, x].Equals('O') || SettingInfo[y, x + 1].Equals('O')))
                    return false;
                if (x + 1 < 5 && y + 1 < 5 && SettingInfo[y + 1, x + 1].Equals('P') && (SettingInfo[y + 1, x].Equals('O') || SettingInfo[y, x + 1].Equals('O')))
                    return false;
                if (x - 1 >= 0 && y + 1 < 5 && SettingInfo[y + 1, x - 1].Equals('P') && (SettingInfo[y + 1, x].Equals('O') || SettingInfo[y, x - 1].Equals('O')))
                    return false;

                return true;
            }
        }

        public int[] solution(string[,] places)
        {
            var rooms = new List<Room>();

            for (int roomNumber = 0; roomNumber < places.GetLength(0); roomNumber++)
            {
                var room = new Room();

                for (int roomRowIndex = 0; roomRowIndex < places.GetLength(1); roomRowIndex++)
                {
                    var roomRow = places[roomNumber, roomRowIndex];

                    for (int roomColumnIndex = 0; roomColumnIndex < roomRow.Length; roomColumnIndex++)
                    {
                        room.SettingInfo[roomRowIndex, roomColumnIndex] = roomRow[roomColumnIndex];
                    }
                }

                rooms.Add(room);
            }

            var result = new int[rooms.Count];

            for (int i = 0; i < rooms.Count; i++)
            {
                result[i] = rooms[i].IsSafe() ? 1 : 0;
            }

            return result;
        }
    }
}

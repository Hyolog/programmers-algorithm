using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 베스트앨범
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new string[] { "classic", "pop", "classic", "classic", "pop" }, new int[] { 500, 600, 150, 800, 2500 }), new int[] { 4, 1, 3, 0 });
        }

        public class GenreInfo
        {
            public int TotalPlay { get; set; }
            public List<KeyValuePair<int, int>> MusicAndPlayInfo { get; set; }
        }

        public int[] solution(string[] genres, int[] plays)
        {
            var album = new List<int>();

            var genreInfo = new Dictionary<string, GenreInfo>();

            for (int i = 0; i < genres.Length; i++)
            {
                if (genreInfo.ContainsKey(genres[i]))
                {
                    genreInfo[genres[i]].TotalPlay += plays[i];
                    genreInfo[genres[i]].MusicAndPlayInfo.Add(new KeyValuePair<int, int>(i, plays[i]));
                }
                else
                {
                    var tempGenreInfo = new GenreInfo() 
                    { 
                        TotalPlay = plays[i], 
                        MusicAndPlayInfo = new List<KeyValuePair<int, int>>()
                    };

                    tempGenreInfo.MusicAndPlayInfo.Add(new KeyValuePair<int, int>(i, plays[i]));

                    genreInfo.Add(genres[i], tempGenreInfo);
                }
            }

            foreach (var item in genreInfo.OrderByDescending(d => d.Value.TotalPlay))
            {
                var musicList = item.Value.MusicAndPlayInfo.OrderByDescending(d => d.Value).ToList();

                album.Add(musicList[0].Key);

                if (musicList.Count > 1)
                {
                    album.Add(musicList[1].Key);
                }
            }

            return album.ToArray();
        }
    }
}

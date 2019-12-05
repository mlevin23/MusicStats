using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    public class MusicStats
    {
        public String Name;
        public String Artist;
        public String Album;
        public String Genre;
        public int Size;
        public int Time;
        public int Year;
        public int Plays;

        public MusicStats(String name, String artist, String album, String genre, int size, int time, int year, int plays)
        {
            Name = name;
            Artist = artist;
            Album = album;
            Genre = genre;
            Size = size;
            Time = time;
            Year = year;
            Plays = plays;
        }
    }
}

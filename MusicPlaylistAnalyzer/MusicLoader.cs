using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    public static class MusicLoader
    {
        private static int NumItemsInRow = 8;

        public static List<MusicStats> Load(string DataFilePath)
        {
            List<MusicStats> musicStatsList = new List<MusicStats>();

            try
            {
                using (var reader = new StreamReader(DataFilePath))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;

                        var values = line.Split('\t');

                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try
                        {
                            String name = values[0];
                            String artist = values[1];
                            String album = values[2];
                            String genre = values[3];
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);
                            MusicStats musicStats = new MusicStats(name, artist, album, genre, size, time, year, plays);
                            musicStatsList.Add(musicStats);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to open {DataFilePath} ({e.Message}).");
            }

            return musicStatsList;
        }
    }
}

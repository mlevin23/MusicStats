using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("CrimeAnalyzer <crime_csv_file_path> <report_file_path>");
                Environment.Exit(1);
            }

            string DataFilePath = args[0];
            string reportFilePath = args[1];

            List<MusicStats> musicStatsList = null;
            try
            {
                musicStatsList = MusicLoader.Load(DataFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = MusicStatsReport.GenerateText(musicStatsList);

            try
            {
                System.IO.File.WriteAllText(reportFilePath, report);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
        }
    }
}

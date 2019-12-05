using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{

    class MusicStatsReport
    {
        public static string GenerateText(List<MusicStats> musicStatsList)
        {
            string report = "Music Playlist Analyzer\n";

            if (musicStatsList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            var startYear = (from musicStats in musicStatsList select musicStats.Year).Min();
            var endYear = (from musicStats in musicStatsList select musicStats.Year).Max();

            report += "Songs with greater than 200 plays: ";
            var years = from musicStats in musicStatsList where musicStats.Plays > 200 select musicStats.Name;
            if (years.Count() > 0)
            {
                foreach (var year in years)
                {
                    report += year + ",";

                }
                report.TrimEnd(',');
                report += "\n";
            }
            else
            {
                report += "not available\n";
            }

            report += "Number of Alternative songs: ";
            var alt = from musicStats in musicStatsList where musicStats.Genre == "Alternative" select musicStats;
            if (alt.Count() > 0)
            {
                report += alt.Count();
                report.TrimEnd(',');
                report += "\n";
            }
            else
            {
                report += "not available\n";
            }

            report += "Number of Hip-Hop/Rap songs: ";
            var hop = from musicStats in musicStatsList where musicStats.Genre == "Hip-Hop/Rap" select musicStats;
            if (hop.Count() > 0)
            {
                report += hop.Count();
                report.TrimEnd(',');
                report += "\n";
            }
            else
            {
                report += "not available\n";
            }

            report += "Songs from Welcome to the FishBowl: ";
            var fishbowl = from musicStats in musicStatsList where musicStats.Album == "Welcome to the Fishbowl" select musicStats.Name;
            if (fishbowl.Count() > 0)
            {
                foreach (var ol in fishbowl)
                {
                    report += ol + ",";

                }
                report.TrimEnd(',');
                report += "\n";
            }
            else
            {
                report += "not available\n";
            }

            report += "Songs from before 1970: ";
            var old = from musicStats in musicStatsList where musicStats.Year < 1970 select musicStats.Name;
            if (old.Count() > 0)
            {
                foreach (var ol in old)
                {
                    report += ol + ",";

                }
                report.TrimEnd(',');
                report += "\n";
            }
            else
            {
                report += "not available\n";
            }

            report += "Song names longer than 85 characters: ";
            var longName = from musicStats in musicStatsList where musicStats.Name.Length > 85 select musicStats.Name;
            if (longName.Count() > 0)
            {
                foreach (var year in longName)
                {
                    report += year + ",";

                }
                report.TrimEnd(',');
                report += "\n";
            }
            else
            {
                report += "not available\n";
            }

            report += "Longest Song: ";
            var longest = (from musicStats in musicStatsList select musicStats.Size).Max();
            var longestName = from musicStats in musicStatsList where musicStats.Size == longest select musicStats.Name;
            if (longName.Count() > 0)
            {
                foreach (var name in longestName)
                {
                    report += name + ",";

                }
                report.TrimEnd(',');
                report += "\n";
            }

            return report;

        }
    }
}

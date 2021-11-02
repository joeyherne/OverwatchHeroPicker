using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace OverwatchCounters
{
    class CSV
    {
        private string content;
        private string[] lines;
        private string[] numbersToBeParsed;
        private const int numberOfHeroes = Form1.numberOfHeroes;
        public double[,] values = new double[numberOfHeroes + 1, numberOfHeroes];
        public double[,] synergy = new double[numberOfHeroes, numberOfHeroes];

        // To Do: Replace all ,, with ,0, in the case of blank cells.

        public CSV()
        {
            content = new
                WebClient().DownloadString("https://docs.google.com/spreadsheets/d/e/2PACX-1vRZII9iTzynK9MhBWvJfkMhO9ip-FRXr1dTbeVMFv2oj10zhf8EZR0nY5d6EhvwAsyJG1eYzSXE36FR/pub?gid=2091818657&single=true&output=csv");
            lines = content.Split('\n').Skip(1).ToArray();
            foreach (string line in lines)
            {
                for (int i = 0; i <= numberOfHeroes; i++)
                {
                    numbersToBeParsed = lines[i].Split(',').Skip(1).ToArray();
                    for (int j = 0; j < numberOfHeroes; j++) values[i, j] = Double.Parse(numbersToBeParsed[j]);
                }
            }

            content = new WebClient().DownloadString("https://docs.google.com/spreadsheets/d/e/2PACX-1vRZII9iTzynK9MhBWvJfkMhO9ip-FRXr1dTbeVMFv2oj10zhf8EZR0nY5d6EhvwAsyJG1eYzSXE36FR/pub?gid=1206320407&single=true&output=csv");
            lines = content.Split('\n').Skip(1).ToArray();
            foreach (string line in lines)
            {
                for (int i=0; i<numberOfHeroes;i++)
                {
                    numbersToBeParsed = lines[i].Split(',').Skip(1).ToArray();
                    for (int j = 0; j < numberOfHeroes; j++) synergy[i, j] = Double.Parse(numbersToBeParsed[j]);
                }
            }

        }
    }
}

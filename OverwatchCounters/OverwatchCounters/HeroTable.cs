using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OverwatchCounters
{
    class HeroTable
    {
        public DataTable Heroes;
        public HeroTable()
        {
            Heroes = new DataTable("Heroes");
            Heroes.Columns.Add("Name");
            Heroes.Columns.Add("Value", typeof(double));
            Heroes.Columns.Add("ID", typeof(int));
            Heroes.Columns.Add("Role", typeof(int));
            Heroes.Rows.Add("Ana", 0, 0, 2);
            Heroes.Rows.Add("Ashe", 0, 1, 1);
            Heroes.Rows.Add("Baptiste", 0, 2, 2);
            Heroes.Rows.Add("Bastion", 0, 3, 1);
            Heroes.Rows.Add("Brigitte", 0, 4, 2);
            Heroes.Rows.Add("Dva", 0, 5, 0);
            Heroes.Rows.Add("Doomfist", 0, 6, 1);
            Heroes.Rows.Add("Echo", 0, 7, 1);
            Heroes.Rows.Add("Genji", 0, 8, 1);
            Heroes.Rows.Add("Hanzo", 0, 9, 1);
            Heroes.Rows.Add("Junkrat", 0, 10, 1);
            Heroes.Rows.Add("Lucio", 0, 11, 2);
            Heroes.Rows.Add("Cassidy", 0, 12, 1);
            Heroes.Rows.Add("Mei", 0, 13, 1);
            Heroes.Rows.Add("Mercy", 0, 14, 2);
            Heroes.Rows.Add("Moira", 0, 15, 2);
            Heroes.Rows.Add("Orisa", 0, 16, 0);
            Heroes.Rows.Add("Pharah", 0, 17, 1);
            Heroes.Rows.Add("Reaper", 0, 18, 1);
            Heroes.Rows.Add("Reinhardt", 0, 19, 0);
            Heroes.Rows.Add("Roadhog", 0, 20, 0);
            Heroes.Rows.Add("Sigma", 0, 21, 0);
            Heroes.Rows.Add("Soldier", 0, 22, 1);
            Heroes.Rows.Add("Sombra", 0, 23, 1);
            Heroes.Rows.Add("Symmetra", 0, 24, 1);
            Heroes.Rows.Add("Torbjorn", 0, 25, 1);
            Heroes.Rows.Add("Tracer", 0, 26, 1);
            Heroes.Rows.Add("Widowmaker", 0, 27, 1);
            Heroes.Rows.Add("Winston", 0, 28, 0);
            Heroes.Rows.Add("Ball", 0, 29, 0);
            Heroes.Rows.Add("Zarya", 0, 30, 0);
            Heroes.Rows.Add("Zenyatta", 0, 31, 2);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OverwatchCounters
{
    public partial class Form1 : Form
    {
        double[,] values;
        double[,] synergy;
        DataTable table;
        public const int numberOfHeroes = 32;

        public Form1()
        {
            InitializeComponent();
           
            OnLoad();
        }

        private void OnLoad()
        {
            // Load the matchup table from the Google Sheets doc.
            CSV csv = new CSV();
            values = csv.values;
            synergy = csv.synergy;


        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            anaButton.Checked = false;
            asheButton.Checked = false;
            baptisteButton.Checked = false;
            bastionButton.Checked = false;
            brigitteButton.Checked = false;
            dvaButton.Checked = false;
            doomfistButton.Checked = false;
            echoButton.Checked = false;
            genjiButton.Checked = false;
            hanzoButton.Checked = false;
            junkratButton.Checked = false;
            lucioButton.Checked = false;
            mccreeButton.Checked = false;
            meiButton.Checked = false;
            mercyButton.Checked = false;
            moiraButton.Checked = false;
            orisaButton.Checked = false;
            pharahButton.Checked = false;
            reaperButton.Checked = false;
            reinhardtButton.Checked = false;
            roadhogButton.Checked = false;
            sigmaButton.Checked = false;
            soldierButton.Checked = false;
            sombraButton.Checked = false;
            symmetraButton.Checked = false;
            torbjornButton.Checked = false;
            tracerButton.Checked = false;
            widowmakerButton.Checked = false;
            winstonButton.Checked = false;
            ballButton.Checked = false;
            zaryaButton.Checked = false;
            zenyattaButton.Checked = false;
            
        }

        private void clearAllies_Click(object sender, EventArgs e)
        {
            anaAlly.Checked = false;
            asheAlly.Checked = false;
            baptisteAlly.Checked = false;
            bastionAlly.Checked = false;
            brigitteAlly.Checked = false;
            dvaAlly.Checked = false;
            doomfistAlly.Checked = false;
            echoAlly.Checked = false;
            genjiAlly.Checked = false;
            hanzoAlly.Checked = false;
            junkratAlly.Checked = false;
            lucioAlly.Checked = false;
            mccreeAlly.Checked = false;
            meiAlly.Checked = false;
            mercyAlly.Checked = false;
            moiraAlly.Checked = false;
            orisaAlly.Checked = false;
            pharahAlly.Checked = false;
            reaperAlly.Checked = false;
            reinhardtAlly.Checked = false;
            roadhogAlly.Checked = false;
            sigmaAlly.Checked = false;
            soldierAlly.Checked = false;
            sombraAlly.Checked = false;
            symmetraAlly.Checked = false;
            torbjornAlly.Checked = false;
            tracerAlly.Checked = false;
            widowmakerAlly.Checked = false;
            winstonAlly.Checked = false;
            ballAlly.Checked = false;
            zaryaAlly.Checked = false;
            zenyattaAlly.Checked = false;
        }

        // This function ensures that heroes with overlapping counters or checks aren't prioritised over heroes that check an uncountered threat. 
        private double toZero(double initial, double adjust)
        {
            if (Math.Abs(adjust) > Math.Abs(initial)) return 0;
            return initial - (Math.Sign(initial) * adjust);
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            // Table columns: 0. Name; 1. Value; 2. ID; 3. Role (0. Tank, 1. DPS, 2. Healer); 
            table = new HeroTable().Heroes;

            // Each hero's viability versus the enemy team composition.
            double[] matchups = new double[numberOfHeroes];

            // A copy of the spreadsheet data that can be altered for this team comparison.
            double[,] copy = new double[numberOfHeroes + 1, numberOfHeroes];
            Array.Copy(values, copy, (numberOfHeroes + 1) * numberOfHeroes);

            // If an ally is strong or weak against an enemy and a hero shares that strength or weakness, the hero's contribution is reduced or increased accordingly.
            if (anaAlly.Checked)
            {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i, 0]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[0, i];
            }
            if (asheAlly.Checked)
            {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i, 1]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[1, i];
            }
            if (baptisteAlly.Checked)
            {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i, 2]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[2, i];
            }
            if (bastionAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i, 3]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[3, i];
            }
            if (brigitteAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i, 4]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[4, i];
            }
            if (dvaAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i, 5]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[5, i];
            }
            if (doomfistAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i, 6]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[6, i];
            }
            if (echoAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i, 7]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[7, i];
            }
            if (genjiAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i, 8]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[8, i];
            }
            if (hanzoAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,9]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[9, i];
            }
            if (junkratAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,10]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[10, i];
            }
            if (lucioAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,11]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[11, i];
            }
            if (mccreeAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,12]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[12, i];
            }
            if (meiAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,13]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[13, i];
            }
            if (mercyAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,14]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[14, i];
            }
            if (moiraAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,15]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[15, i];
            }
            if (orisaAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,16]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[16, i];
            }
            if (pharahAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,17]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[17, i];
            }
            if (reaperAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,18]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[18, i];
            }
            if (reinhardtAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,19]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[19, i];
            }
            if (roadhogAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,20]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[20, i];
            }
            if (sigmaAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,21]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[21, i];
            }
            if (soldierAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,22]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[22, i];
            }
            if (sombraAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,23]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[23, i];
            }
            if (symmetraAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,24]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[24, i];
            }
            if (torbjornAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,25]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[25, i];
            }
            if (tracerAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,26]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[26, i];
            }
            if (widowmakerAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,27]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[27, i];
            }
            if (winstonAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,28]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[28, i];
            }
            if (ballAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,29]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[29, i];
            }
            if (zaryaAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,30]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[30, i];
            }
            if (zenyattaAlly.Checked) {
                for (int i = 0; i < numberOfHeroes; i++) for (int j = 0; j < numberOfHeroes; j++) copy[i, j] = toZero(copy[i, j], copy[i,31]);
                for (int i = 0; i < numberOfHeroes; i++) matchups[i] += synergy[31, i];
            }

            // The averages of the tank, dps and healer matchups is averaged for each hero and added as a decimal value (retrieved from the last line in the spreadsheet)
            // in order to rank the heroes if the enemy team is unknown.
            for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[numberOfHeroes, i];

            // Assign values based on the enemy team composition.
            if (anaButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[0, i];
            if (asheButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[1, i];
            if (baptisteButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[2, i];
            if (bastionButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[3, i];
            if (brigitteButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[4, i];
            if (dvaButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[5, i];
            if (doomfistButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[6, i];
            if (echoButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[7, i];
            if (genjiButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[8, i];
            if (hanzoButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[9, i];
            if (junkratButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[10, i];
            if (lucioButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[11, i];
            if (mccreeButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[12, i];
            if (meiButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[13, i];
            if (mercyButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[14, i];
            if (moiraButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[15, i];
            if (orisaButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[16, i];
            if (pharahButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[17, i];
            if (reaperButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[18, i];
            if (reinhardtButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[19, i];
            if (roadhogButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[20, i];
            if (sigmaButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[21, i];
            if (soldierButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[22, i];
            if (sombraButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[23, i];
            if (symmetraButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[24, i];
            if (torbjornButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[25, i];
            if (tracerButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[26, i];
            if (widowmakerButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[27, i];
            if (winstonButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[28, i];
            if (ballButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[29, i];
            if (zaryaButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[30, i];
            if (zenyattaButton.Checked) for (int i = 0; i < numberOfHeroes; i++) matchups[i] += copy[31, i];


            DataView view;

            bool best = true;
            bool dpsPicked = false;
            bool tankPicked = false;
            bool healerPicked = false;
            int bestHero;
            int heroesPicked = 0;

            for (int i = 0; i < numberOfHeroes; i++)
            {
                for (int k = 0; k < numberOfHeroes; k++) table.Rows[k][1] = matchups[k];
                view = new DataView(table);
                view.Sort = "Value DESC";

                string counters = "";
                string threats = "";

                if (best && ((!tankPicked && view[0][3].ToString() == "0") || (!dpsPicked && view[0][3].ToString() == "1") || (!healerPicked && view[0][3].ToString() == "2")))
                {                    
                    bestHero = (int)view[0][2];
                    if (anaButton.Checked)
                    {
                        if (values[0, bestHero] > 0) counters += "Ana "; else if (values[0, bestHero] < 0) threats += "Ana ";
                    }
                    if (asheButton.Checked)
                    {
                        if (values[1, bestHero] > 0) counters += "Ashe "; else if (values[1, bestHero] < 0) threats += "Ashe ";
                    }
                    if (baptisteButton.Checked)
                    {
                        if (values[2, bestHero] > 0) counters += "Baptiste "; else if (values[2, bestHero] < 0) threats += "Baptiste ";
                    }
                    if (bastionButton.Checked)
                    {
                        if (values[3, bestHero] > 0) counters += "Bastion "; else if (values[3, bestHero] < 0) threats += "Bastion ";
                    }
                    if (brigitteButton.Checked)
                    {
                        if (values[4, bestHero] > 0) counters += "Brigitte "; else if (values[4, bestHero] < 0) threats += "Brigitte ";
                    }
                    if (dvaButton.Checked)
                    {
                        if (values[5, bestHero] > 0) counters += "Dva "; else if (values[5, bestHero] < 0) threats += "Dva ";
                    }
                    if (doomfistButton.Checked)
                    {
                        if (values[6, bestHero] > 0) counters += "Doomfist "; else if (values[6, bestHero] < 0) threats += "Doomfist ";
                    }
                    if (echoButton.Checked)
                    {
                        if (values[7, bestHero] > 0) counters += "Echo "; else if (values[7, bestHero] < 0) threats += "Echo ";
                    }
                    if (genjiButton.Checked)
                    {
                        if (values[8, bestHero] > 0) counters += "Genji "; else if (values[8, bestHero] < 0) threats += "Genji ";
                    }
                    if (hanzoButton.Checked)
                    {
                        if (values[9, bestHero] > 0) counters += "Hanzo "; else if (values[9, bestHero] < 0) threats += "Hanzo ";
                    }
                    if (junkratButton.Checked)
                    {
                        if (values[10, bestHero] > 0) counters += "Junkrat "; else if (values[10, bestHero] < 0) threats += "Junkrat ";
                    }
                    if (lucioButton.Checked)
                    {
                        if (values[11, bestHero] > 0) counters += "Lucio "; else if (values[11, bestHero] < 0) threats += "Lucio ";
                    }
                    if (mccreeButton.Checked)
                    {
                        if (values[12, bestHero] > 0) counters += "Cassidy "; else if (values[12, bestHero] < 0) threats += "Cassidy ";
                    }
                    if (meiButton.Checked)
                    {
                        if (values[13, bestHero] > 0) counters += "Mei "; else if (values[13, bestHero] < 0) threats += "Mei ";
                    }
                    if (mercyButton.Checked)
                    {
                        if (values[14, bestHero] > 0) counters += "Mercy "; else if (values[14, bestHero] < 0) threats += "Mercy ";
                    }
                    if (moiraButton.Checked)
                    {
                        if (values[15, bestHero] > 0) counters += "Moira "; else if (values[15, bestHero] < 0) threats += "Moira ";
                    }
                    if (orisaButton.Checked)
                    {
                        if (values[16, bestHero] > 0) counters += "Orisa "; else if (values[16, bestHero] < 0) threats += "Orisa ";
                    }
                    if (pharahButton.Checked)
                    {
                        if (values[17, bestHero] > 0) counters += "Pharah "; else if (values[17, bestHero] < 0) threats += "Pharah ";
                    }
                    if (reaperButton.Checked)
                    {
                        if (values[18, bestHero] > 0) counters += "Reaper "; else if (values[18, bestHero] < 0) threats += "Reaper ";
                    }
                    if (reinhardtButton.Checked)
                    {
                        if (values[19, bestHero] > 0) counters += "Reinhardt "; else if (values[19, bestHero] < 0) threats += "Reinhardt ";
                    }
                    if (roadhogButton.Checked)
                    {
                        if (values[20, bestHero] > 0) counters += "Roadhog "; else if (values[20, bestHero] < 0) threats += "Roadhog ";
                    }
                    if (sigmaButton.Checked)
                    {
                        if (values[21, bestHero] > 0) counters += "Sigma "; else if (values[21, bestHero] < 0) threats += "Sigma ";
                    }
                    if (soldierButton.Checked)
                    {
                        if (values[22, bestHero] > 0) counters += "Soldier "; else if (values[22, bestHero] < 0) threats += "Soldier ";
                    }

                    if (sombraButton.Checked)
                    {
                        if (values[23, bestHero] > 0) counters += "Sombra "; else if (values[23, bestHero] < 0) threats += "Sombra ";
                    }
                    if (symmetraButton.Checked)
                    {
                        if (values[24, bestHero] > 0) counters += "Symmetra "; else if (values[24, bestHero] < 0) threats += "Symmetra ";
                    }
                    if (torbjornButton.Checked)
                    {
                        if (values[25, bestHero] > 0) counters += "Torbjorn "; else if (values[25, bestHero] < 0) threats += "Torbjorn ";
                    }
                    if (tracerButton.Checked)
                    {
                        if (values[26, bestHero] > 0) counters += "Tracer "; else if (values[26, bestHero] < 0) threats += "Tracer ";
                    }
                    if (widowmakerButton.Checked)
                    {
                        if (values[27, bestHero] > 0) counters += "Widowmaker "; else if (values[27, bestHero] < 0) threats += "Widowmaker ";
                    }
                    if (winstonButton.Checked)
                    {
                        if (values[28, bestHero] > 0) counters += "Winston "; else if (values[28, bestHero] < 0) threats += "Winston ";
                    }
                    if (ballButton.Checked)
                    {
                        if (values[29, bestHero] > 0) counters += "Ball "; else if (values[29, bestHero] < 0) threats += "Ball ";
                    }
                    if (zaryaButton.Checked)
                    {
                        if (values[30, bestHero] > 0) counters += "Zarya "; else if (values[30, bestHero] < 0) threats += "Zarya ";
                    }
                    if (zenyattaButton.Checked)
                    {
                        if (values[31, bestHero] > 0) counters += "Zenyatta "; else if (values[31, bestHero] < 0) threats += "Zenyatta ";
                    }

                    if (heroesPicked <= 3)
                    {
                        heroesPicked++;
                        if (heroesPicked == 1)
                        {
                            topPickLabel.Text = view[0][0].ToString();
                            if (counters == "") topCountersLabel.Text = ""; else topCountersLabel.Text = "Focus: " + counters;
                            if (threats == "") topThreatsLabel.Text = ""; else topThreatsLabel.Text = "Caution: " + threats;
                        }
                        if (heroesPicked == 2)
                        {
                            secondPickLabel.Text = view[0][0].ToString();
                            if (counters == "") secondCountersLabel.Text = ""; else secondCountersLabel.Text = "Focus: " + counters;
                            if (threats == "") secondThreatsLabel.Text = ""; else secondThreatsLabel.Text = "Caution: " + threats;
                        }
                        if (heroesPicked == 3)
                        {
                            thirdPickLabel.Text = view[0][0].ToString();
                            if (counters == "") thirdCountersLabel.Text = ""; else thirdCountersLabel.Text = "Focus: " + counters;
                            if (threats == "") thirdThreatsLabel.Text = ""; else thirdThreatsLabel.Text = "Caution: " + threats;
                        }
                    }

                    if (view[0][3].ToString() == "0") tankPicked = true;
                    if (view[0][3].ToString() == "1") dpsPicked = true;
                    if (view[0][3].ToString() == "2") healerPicked = true;
                    if (tankPicked && dpsPicked && healerPicked) best = false;
                } 

                // Get the hero ID and remove the hero from the list.
                int hero = Int32.Parse(view[0][2].ToString());
                matchups[hero] -= 1000;
            }
        }

        private void anaButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void asheButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void baptisteButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bastionButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void brigitteButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dvaButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void doomfistButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void echoButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void genjiButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void hanzoButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void junkratButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lucioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mccreeButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void meiButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mercyButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void moiraButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void orisaButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pharahButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void reaperButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void reinhardtButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void roadhogButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sigmaButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void soldierButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sombraButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void symmetraButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void torbjornButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tracerButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void widowmakerButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void winstonButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ballButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void zaryaButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void zenyattaButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void colorfulLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

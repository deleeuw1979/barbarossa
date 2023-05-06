using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
//using System.Runtime.InteropServices;

namespace Barbarossa
{
    //PlayerAids
    //No Context Menus

    public partial class Game : Form
    {
     //   [DllImport("gdi32.dll")]
        //public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public const int HORZSIZE = 4;
        public const int VERTSIZE = 6;
        public const double MM_TO_INCH_CONVERSION_FACTOR = 25.4;

        public List<Unit> eliminated = new List<Unit>();
        public List<Unit> engaged = new List<Unit>();
        public List<Unit> moving = new List<Unit>();
        public List<City> replacementCities = new List<City>();
        public Random ran = new Random();
        public Unit currentUnit = new Unit();
        public Map overviewMap;
        public bool overview=false;
        public bool moscowCaptured = false;
        public bool leningradCaptured = false;
        public bool bucharestiCaptured = false;
        public bool helsinkiCaptured = false;
        public bool startCities = false;
        public bool startUnits = false;
        public bool startTracks = false;
        public bool startGlobal = false;
        public bool showGerman = false;
        public bool doTrace = false;
        public bool doPlannedMove = false;
        public bool showReinforcements = false;
        public string currentNewUnits = "";

        //public string[] currReinforcementsGerman=new string[]{};
        public List<string> currReinforcementsGerman = new List<string>();

        public int currReinforcementsGermanNumber = 0;
        
        //public string[] currReinforcementsRussian = new string[] { };
        public List<string> currReinforcementsRussian = new List<string>();

        public int currReinforcementsRussianNumber = 0;

        public List<string> currReplacementsGerman = new List<string>();
        public List<string> currReplacementsRussian = new List<string>();
        
        public int z = 1;

        //Fullscreen
        public double ratioX = .27;
        public double ratioY = .29;
                
        public string engagedUnitList = "";
        public string otherUnitList = "";
        public string plannedMoveList = "";
        public string engagedList = "";
        public string movingList = "";
        public string eliminatedList = "";
        public int unitSize = 18;
        public double physicalX = 1;
        public double physicalY = 1;
        public double physicalDelta = 1;
        public int total = 0;
        
        public CheckBox chk;
        public Form prompt;
        public Panel panel; 
        public RichTextBox startingConditions;
        public Boolean startGame;
        public Button newGame;
        public Button savedGame;
        public Button closeInfo;
        public Reinforcements nextMonthReinforcements;

        public String startSideName=String.Empty;
        public String startDateText = String.Empty;
        public String savedConditions = "";
        public Boolean showAllUnits = true;
        public Detail mapDetail = new Detail();
        public Panel mapPanel = new Panel();

            //= new Detail();

        /*
            var hDC = Graphics.FromHwnd(this.Handle).GetHdc();
            int horizontalSizeInMilliMeters = GetDeviceCaps(hDC, HORZSIZE);
            double horizontalSizeInInches = horizontalSizeInMilliMeters / MM_TO_INCH_CONVERSION_FACTOR;
            int verticalSizeInMilliMeters = GetDeviceCaps(hDC, VERTSIZE);
            double verticalSizeInInches = verticalSizeInMilliMeters / MM_TO_INCH_CONVERSION_FACTOR;
            
            //physicalX=horizontalSizeInInches/1920;
            //physicalY = verticalSizeInInches / 1080;
            physicalX = horizontalSizeInInches / 26.6;
            physicalY = verticalSizeInInches / 15;
            physicalDelta = Math.Sqrt((physicalX * physicalX) + (physicalY * physicalY));

            if (physicalDelta > 1)
                physicalDelta = 1;

        unitSize = Convert.ToInt32(unitSize * physicalDelta);         
        //double currHor=Convert.ToDouble(round.GetDeviceCaps(Graphics.FromHwnd(this.Handle).GetHdc(), VERTSIZE));
        //MessageBox.Show((currHor/25.4).ToString());
        */


        public Game()
        {            
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            this.BackColor = Color.Transparent;
           
            showStatus();
            gameLoad();
        }
        
        private void showStatus()
        {
            prompt = new Form();
            prompt.Width = 170;
            
            //prompt.Height = 190;
            prompt.Height = 95;

            prompt.Text = "Start Game";
            prompt.BackColor = Color.FromArgb(255, 150, 150, 150);
            prompt.FormBorderStyle = FormBorderStyle.None;
            panel = new Panel();
            panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel.Width = 170;
            
            //panel.Height = 190;
            panel.Height = 95;

            chk = new CheckBox();
            chk.Text = "Show Rules?";
            chk.Font=new Font("Times New Roman", 10);
            chk.Left = 5;
            newGame = new Button() { Text = "New " };
            newGame.Height = 25;
            //newGame.Click += (sender, e) => { startGame = true;};
            newGame.Left = 7;
            newGame.Top = 30;
            newGame.Font = new Font("Times New Roman", 10);
            newGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            newGame.ForeColor = Color.White;
            newGame.Click += (sender, e) => { startGame = true; doCheck(); };
            savedGame = new Button() { Text = "Saved" };
            savedGame.Font = new Font("Times New Roman", 10);
            savedGame.Height = 25;
            savedGame.Top = 30;
            savedGame.Left = 85;
            savedGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            savedGame.ForeColor = Color.White;
            savedGame.Click += (sender, e) => { startGame = false; doCheck(); };
            //savedGame.Click += (sender, e) => { startGame = false; };
            startingConditions = new RichTextBox();
            startingConditions.Left = 5;
            startingConditions.Top = 60;
            startingConditions.Width = 155;
            startingConditions.Height = 110;
            closeInfo = new Button() { Text = "Continue" };
            closeInfo.Size = new Size(70, 25);
            closeInfo.Font = new Font("Times New Roman", 10);
            closeInfo.Left = 45;
            closeInfo.Top = 65;
            closeInfo.Enabled = false;
            closeInfo.Click += (sender, e) => { prompt.Close(); };
            closeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            closeInfo.FlatAppearance.BorderColor = Color.FromArgb(255, 150, 150, 150);
            panel.Controls.Add(chk);
            panel.Controls.Add(newGame);
            panel.Controls.Add(savedGame);
            //panel.Controls.Add(startingConditions);
            panel.Controls.Add(closeInfo);
            //closeInfo.Location = new System.Drawing.Point(1798, -4);
            //closeInfo.Visible = false;
            prompt.Controls.Add(panel);
            //this.ControlBox = false;
            prompt.ControlBox = false;
            prompt.Icon = global::Barbarossa.Properties.Resources.german1;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.ShowDialog();
            prompt.Text = "Current Conditions";
            startingConditions.Font = new Font("Times New Roman", 10);
            startingConditions.Top = 10;
            panel.Height = prompt.Height = 160;
            closeInfo.Top = 130;
        }


        public void doCheck()
        {
            if (chk.Checked == true)
                showRules();

            //chk.Visible = false;
            //chk.Enabled = false;
            //newGame.Visible = false;
            //newGame.Enabled = false;
            //savedGame.Visible = false;
            //savedGame.Enabled = false;
            if (startGame)
                savedGame.ForeColor = Color.Black;
            else
                newGame.ForeColor = Color.Black;

            closeInfo.Enabled = true;
            //startConditions();

            // What about saved games
        }

        public void startConditions()
        {
            if (!startGame)
            {                
                startingConditions.Text = savedConditions;
            }
            else
            {
                startDateText = "Week " + round.turn[0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][0][0].ToString() + " " + Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][0].ToString() ;

                //Test
                //startDateText += round.turn[4];

                //startDateText = "Week " + round.turn[0].ToString() + "\n";

                /*
                if (round.turn[4] == 24)
                    startDateText += "Mid June";
                else if (round.turn[4] == 26)
                    startDateText += "Early July";
                else if (round.turn[4] == 25)
                    startDateText += "Late June";
                */

                startSideName = "German";

                if (round.turn[2] == 1)
                    startSideName = "Russian";

                startingConditions.Text = startSideName + "\nWeather: \n" ;
                startingConditions.Text += "\tNorth: "+round.currentWeather[0]+"\n";
                startingConditions.Text += "\tCenter: " + round.currentWeather[1] + "\n";
                startingConditions.Text += "\tSouth: " + round.currentWeather[2];

                startingConditions.Text +=  "\n" + startDateText;

            }
            //MessageBox.Show(startSide + "\n" + startDate + "\nWeather: " + round.currentWeather);
            
            /*
            round.turn[param] = Convert.ToInt32(section);
            if (lineNumber == 1)
                round.currentCalendar[param] = Convert.ToInt32(section);
            if (lineNumber == 2)
                round.currentWeather = Convert.ToString(section);
            if (lineNumber == 3)
                round.currentGround = Convert.ToString(section);
             */
        }

        public void gameLoad()
        {
            Map.SendToBack();

            //if(MessageBox.Show("Start new game?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            mapPanel.Width = mapPanel.Height = 400;
            mapPanel.Left = 1800;
            mapPanel.Top = 10;

                //Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][1] = round.turn[0].ToString(); 
                round.turn[1] = round.turn[4];

                //MessageBox.Show(round.turn[0].ToString());
                for(int c = 0; c < Data.cityCoords.Length; c++)
                {
                    City city = new City();
                    city.Height = city.Width = Convert.ToInt32(Convert.ToDouble(unitSize)*.66);
                    city.Height = Convert.ToInt32(city.Height * physicalDelta);
                    city.Width = Convert.ToInt32(city.Width * physicalDelta);

                    city.side = Data.cityCoords[c][3];
                    city.originalSide = Data.cityCoords[c][3];
                    city.points = Data.cityCoords[c][2];

                    //TEST
                  // city.BackColor = System.Drawing.Color.Aquamarine;
                    
                    city.Name = "City" + c.ToString();

                    if(Data.cityCoords[c][4] == 1)
                        city.Name = "Leningrad";

                    if(Data.cityCoords[c][4] == 2)
                        city.Name = "Moscow";

                    if(Data.cityCoords[c][4] == 10)
                        city.Name = "Helsinki";

                    if(Data.cityCoords[c][4] == 20)
                        city.Name = "Bucharesti";

                    city.number = c;
                    city.type = Data.cityCoords[c][2];
                    city.supply = (new Random().Next(1, 50 * Data.cityCoords[c][2])) * 10;
                    city.Left = Convert.ToInt32(Data.cityCoords[c][0]);
                    city.Top = Convert.ToInt32(Data.cityCoords[c][1]);                    
                    //city.Left = Convert.ToInt32(Convert.ToDouble(city.Left)/1.015);
                    city.Top = Convert.ToInt32(Convert.ToDouble(city.Top) * 1.015);

                    //Fullscreen
                    city.Left = Convert.ToInt32(Convert.ToDouble(city.Left) / 2.05);
                    city.Top = Convert.ToInt32(Convert.ToDouble(city.Top) / 2.65);

                    //Physical Screen
                    city.Left=Convert.ToInt32(city.Left*physicalDelta);
                    city.Top = Convert.ToInt32(city.Top * physicalDelta);

                    city.thisX = city.Left;
                    city.thisY = city.Top;
                    city.textBox1.Text = city.Left.ToString() + "," + city.Top.ToString();
                    this.Controls.Add(city);
                }
                if (startGame == true)
                {
                    //if(round.turn[1] == 25)
                    int startSide = new Random().Next(0, 100);

                    if (startSide < 100)
                        round.turn[2] = 0;
                    else
                        round.turn[2] = 1;

                    int startMonth = new Random().Next(0, 11);

                    //test
                   // startMonth = 10;

                    if (startMonth == 10)
                    {
                        round.turn[4] = 23;
                        round.turn[0] = round.turn[0] - 1;
                        round.turn[1] = round.turn[1] - 1;
                    }
                    else if (startMonth == 0)
                    {
                        round.turn[4] = 25;
                        round.turn[0] = round.turn[0] + 1;
                        round.turn[1] = round.turn[1] + 1;
                    }
                    else
                    {
                        round.turn[4] = 24;
                    }

                unitSetup();
            }
            else if (startGame ==false)
            {
                StreamReader loadGame;
                loadGame = new StreamReader("saveGame.txt");
                string line;
                int lineNumber = 0;

                while((line = loadGame.ReadLine()) != null)
                {
                    int param = 0;
                    string[] lineSection = line.Split(',');

                    if(line == "Cities")
                    {
                        startCities = true;
                        startUnits = false;
                        startTracks = false;
                        startGlobal = false;
                    }

                    if(line == "Units")
                    {
                        startUnits = true;
                        startCities = false;
                        startTracks = false;
                        startGlobal = false;
                    }

                    if(line == "Tracks")
                    {
                        startTracks = true;
                        startCities = false;
                        startUnits = false;
                        startGlobal = false;
                    }

                    if(line == "Global")
                    {
                        lineNumber = -1;
                        startGlobal = true;
                        startCities = false;
                        startTracks = false;
                        startUnits = false;
                    }

                    if(startCities)
                    {
                        City currentCity = new City();

                        foreach(string section in lineSection)
                        {
                            if(param == 0)
                            {
                                currentCity.Name = section;
                            }
                            if(param == 1)
                            {
                                currentCity.number = Convert.ToInt32(section);
                                currentCity.Left = Convert.ToInt32(Data.cityCoords[Convert.ToInt32(currentCity.number)][0]);
                                currentCity.Top = Convert.ToInt32(Data.cityCoords[Convert.ToInt32(currentCity.number)][1]);
                            }
                            if(param == 2)
                                currentCity.type = Convert.ToInt32(section);
                            if(param == 3)
                                currentCity.originalSide = Convert.ToInt32(section);
                            if(param == 4)
                                currentCity.side = Convert.ToInt32(section);
                            if(param == 5)
                                currentCity.points = Convert.ToInt32(section);
                            if(param == 6)
                                currentCity.supply = Convert.ToDouble(section);
                            if(param == 7)
                                currentCity.depotySupply = Convert.ToDouble(section);

                            param++;
                        }

                        this.Controls.Add(currentCity);
                        param = 0;
                    }
                    else if(startUnits)
                    {
                        Unit currentUnit = new Unit();

                        foreach(string section in lineSection)
                        {
                            if(param == 0)
                            {
                                currentUnit.Width = currentUnit.Height = unitSize;
                                currentUnit.Name = section;
                            }
                            if(param == 1)
                            {
                                currentUnit.type = Convert.ToInt32(section);
                                if(Convert.ToInt32(section) > 0)
                                    currentUnit.BackgroundImage = (Image)global::Barbarossa.Properties.Resources.ResourceManager.GetObject("_"+Data.unitTypes[Convert.ToInt32(currentUnit.type)][0][1].ToString());
                            }
                            if(param == 2)
                                currentUnit.intel = Convert.ToDouble(section);
                            if(param == 3)
                                currentUnit.side = Convert.ToInt32(section);
                            if(param == 4)
                                currentUnit.strength = Convert.ToDouble(section);
                            if(param == 5)
                                currentUnit.detection = Convert.ToDouble(section);
                            if(param == 6)
                                currentUnit.supply = Convert.ToDouble(section);
                            if(param == 7)
                                currentUnit.didMove = Convert.ToBoolean(section);
                            if(currentUnit.didMove)
                                currentUnit.BackColor = System.Drawing.Color.Black;
                            if(param == 8)
                                currentUnit.doMove = Convert.ToBoolean(section);
                            if(param == 9)
                                currentUnit.doDelayedMove = Convert.ToBoolean(section);
                            if(param == 10)
                                currentUnit.didResupply = Convert.ToBoolean(section);
                            if(param == 11)
                                currentUnit.didCombat = Convert.ToBoolean(section);
                            if(param == 12)
                                currentUnit.checkTrain = Convert.ToBoolean(section);
                            if(param == 13)
                                currentUnit.onTrain = Convert.ToBoolean(section);
                            if(currentUnit.didMove && currentUnit.onTrain)
                                currentUnit.BackColor = System.Drawing.Color.Red;
                            if(param == 14)
                                currentUnit.inCity = Convert.ToBoolean(section);
                            if(param == 15)
                                currentUnit.retreated = Convert.ToBoolean(section);
                            if(param == 16)
                                currentUnit.supplies = Convert.ToBoolean(section);
                            if(param == 17)
                                currentUnit.distanceMoved = Convert.ToInt32(section);
                            if(param == 18)
                                currentUnit.scrollX = Convert.ToInt32(section);
                            if(param == 19)
                                currentUnit.scrollY = Convert.ToInt32(section);
                            if(param == 20)
                                currentUnit.currX = Convert.ToInt32(section);
                            if(param == 21)
                                currentUnit.currY = Convert.ToInt32(section);
                            if(param == 22)
                                currentUnit.delayedMove = Convert.ToInt32(section);
                            if(param == 23)
                                currentUnit.delayedAttack = Convert.ToInt32(section);
                            if(param == 24)
                                currentUnit.randomDelay = Convert.ToInt32(section);
                            if(param == 25)
                                currentUnit.currentTurn = Convert.ToInt32(section);
                            if(param == 26)
                                currentUnit.currentTerrain = section;
                            if(param == 27)
                                currentUnit.coordinatingAttack = Convert.ToBoolean(section);
                            if(param == 28)
                            {
                                currentUnit.eliminated = Convert.ToBoolean(section);

                                if(currentUnit.eliminated)
                                    currentUnit.Width = currentUnit.Height = 0;
                            }
                            if(param == 29)
                                currentUnit.didAirdrop = Convert.ToBoolean(section);
                            if(param == 30)
                                currentUnit.didDelayedMove = Convert.ToBoolean(section);
                            if(param == 31)
                                currentUnit.didDelayedAttack = Convert.ToBoolean(section);
                            if(param == 34)
                            {
                                string[] listSection = section.Split('-');

                                foreach(string listItem in listSection)
                                {
                                    if(listItem != "")
                                    {
                                        string listItemCoords = listItem;
                                        listItemCoords = listItemCoords.Replace("x", ",");
                                        string[] coords = new string[] { listItemCoords };
                                        Point currPoint = new Point(Convert.ToInt32(listItemCoords[0]), Convert.ToInt32(listItemCoords[1]));
                                        currentUnit.plannedMove.Add(currPoint);
                                    }
                                }

                                currentUnit.Left = currentUnit.currX;
                                currentUnit.Top = currentUnit.currY;
                                this.Controls.Add(currentUnit);
                            }

                            param++;
                        }

                        foreach(string section in lineSection)
                        {
                            if(param == 32)
                            {
                                string[] listSection = section.Split('-');

                                foreach(string listItem in listSection)
                                {
                                    if(listItem != "")
                                        currentUnit.engagedUnits.Add((Unit)this.Controls.Find(listItem, true)[0]);
                                }
                            }
                            if(param == 33)
                            {
                                string[] listSection = section.Split('-');

                                foreach(string listItem in listSection)
                                {
                                    if(listItem != "")
                                        currentUnit.otherUnits.Add((Unit)this.Controls.Find(listItem, true)[0]);
                                }
                            }

                            param++;
                        }

                        param = 0;
                    }
                    else if(startTracks)
                    {
                        Track currentTrack = new Track();

                        foreach(string section in lineSection)
                        {
                            if(param == 0 && section != "Tracks")
                            {
                                currentTrack.Left = Convert.ToInt32(section);
                            }
                            else if(param == 1)
                            {
                                currentTrack.Top = Convert.ToInt32(section);
                                this.Controls.Add(currentTrack);
                            }

                            param++;
                        }

                        param = 0;
                    }
                    else if(startGlobal)
                    {
                        int w = 0;
                        int g = 0;
                        foreach(string section in lineSection)
                            {
                            if(lineNumber == 0)
                                round.turn[param] = Convert.ToInt32(section);
                            if(lineNumber == 1)
                                round.currentCalendar[param] = Convert.ToInt32(section);
                            //?
                         

                            if (lineNumber == 2)
                            {
                                //Calm is default
                                //MessageBox.Show(section.ToString());

                                round.currentWeather[w] = Convert.ToString(section);
                            

                               // MessageBox.Show(lineNumber.ToString());
                                /*
                                MessageBox.Show(lineSection.ToString());

                                //MessageBox.Show(lineSection.ToString());
                                string[] listSection = section.Split(',');
                                //MessageBox.Show(section.Length.ToString());
                                //MessageBox.Show(listSection.Length.ToString());
                                
                                foreach(string listItem in listSection)
                                {
                                    //round.currentWeather[0] = listItem[0].ToString();
                                    //round.currentWeather[1] = listItem[1].ToString();
                                    //round.currentWeather[2] = listItem[2].ToString();                              
                                  //currentUnit.otherUnits.Add((Unit)this.Controls.Find(listItem, true)[0]);

                                        //round.currentWeather[0] = Convert.ToString(section[0]);
                                        //round.currentWeather[1] = Convert.ToString(section[1]);
                                        //round.currentWeather[2] = Convert.ToString(section[2]);
                                 }
                                */
                                w++;
                             }

                            if (lineNumber == 3)
                            {   
                             // string[] listSection = section.Split(',');
                               //foreach(string listItem in listSection)
                               //{
                                   /*
                                   round.currentGround[0] = listItem[0].ToString();
                                   round.currentGround[1] = listItem[1].ToString();
                                   round.currentGround[2] = listItem[2].ToString();
                                    */

                                   round.currentGround[g] = Convert.ToString(section);
                      
                                    //currentUnit.otherUnits.Add((Unit)this.Controls.Find(listItem, true)[0]);
                                //}

                                   g++;
                            }
                            if(lineNumber == 4)
                                round.invasions[param] = Convert.ToBoolean(section);
                            if(lineNumber == 5 && section != "")
                                    moving.Add((Unit)this.Controls.Find(section, true)[0]);
                            if(lineNumber == 6 && section != "")
                                    engaged.Add((Unit)this.Controls.Find(section, true)[0]);
                            if(lineNumber == 7 && section != "")
                                    eliminated.Add((Unit)this.Controls.Find(section, true)[0]);
                            param++;
                          
                        }
                        
                        /*
                        saveFile.WriteLine("Global");
                        saveFile.WriteLine(round.turn[0].ToString() + "," + round.turn[1].ToString() + "," + round.turn[2].ToString() + "," + round.turn[3].ToString() + "," + round.turn[4].ToString());
                        saveFile.WriteLine(round.currentCalendar[0].ToString() + "," + round.currentCalendar[1].ToString() + "," + round.currentCalendar[2].ToString() + "," + round.currentCalendar[3].ToString());
                        saveFile.WriteLine(round.currentWeather);
                        saveFile.WriteLine(round.currentGround);
                        saveFile.WriteLine(round.invasions[0].ToString() + "," + round.invasions[1].ToString() + "," + round.invasions[2].ToString());
                        */
                        String savedSideName="German";

                        if (round.turn[2] == 1)
                            savedSideName = "Russian";

                       // savedConditions = savedSideName + "\nWeather: " + round.currentWeather + "\n" + "Week " + round.turn[0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][0][0].ToString() + " " + Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][0].ToString() + "\n";

                        savedConditions = savedSideName + "\nWeather: \n";
                        savedConditions += "\tNorth: " + round.currentWeather[0] + "\n";
                        savedConditions += "\tCenter: " + round.currentWeather[1] + "\n";
                        savedConditions += "\tSouth: " + round.currentWeather[2];
                        savedConditions += "\n" + "Week " + round.turn[0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][0][0].ToString() + " " + Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][0].ToString() + "\n";

                        //startingConditions.Text = startSideName + "\nWeather: " + round.currentWeather + "\n" + startDateText;
                        param = 0;
                    }

                    lineNumber++;
                }

                loadGame.Dispose();
            }

            //showStatus();
            //showRules();

            panel.Controls.Remove(chk);
            panel.Controls.Remove(newGame);
            panel.Controls.Remove(savedGame);
            panel.Controls.Add(startingConditions);
            //panel.Controls.Remove(closeInfo);
            startConditions();
            prompt.ShowDialog();
            

        }
        
        public void unitSetup()
        {
            int amt=0;
            currReinforcementsGerman = new List<string>();
            currReinforcementsGermanNumber=0;
            currReinforcementsRussian = new List<string>();
            currReinforcementsRussianNumber = 0;
            
           // "Starting turn conditions."
            
            if(round.turn[1] == round.turn[4])
                amt = Data.unitCoords.Length;
            else if (round.turn[0] == 1)
                amt = round.currentCalendar[3] + Convert.ToInt32(Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][2]);

            //+ Convert.ToInt32(Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][3]

            round.turn[3] = round.turn[1];
       

            for(int u = round.currentCalendar[3]; u < amt; u++)
            {
                Unit unit = new Unit();
                unit.Height = unit.Width = unitSize;

                if(u == 0)//DELEEUW; Only if u=0? What about Delayed Move/Attack
                    checkWeather();

                if(Convert.ToInt32(Data.units[u][1]) < 12)
                    unit.side = 1; 
                else
                    unit.side = 0;

                if(round.turn[1] == round.turn[4])
                {
                    unit.Left = Data.unitCoords[u][0];
                    unit.Top = Data.unitCoords[u][1];
                    unit.startCoords = unit.Left.ToString() + "," + unit.Top.ToString();

                    //Fullscreen
                    /*
                    unit.Left =Convert.ToInt32(Convert.ToDouble(unit.Left)/2.1);
                    unit.Top = Convert.ToInt32(Convert.ToDouble(unit.Top) / 2.6);
                    unit.Left = unit.Left + 20;
                    unit.Top = unit.Top - 20;
                    */
                    //Physical Screen
                    unit.Left = Convert.ToInt32(unit.Left * physicalDelta);
                    unit.Top = Convert.ToInt32(unit.Top * physicalDelta);

                    //unit.Left = Convert.ToInt32(Convert.ToDouble(unit.Left) / 3.87);
                    //unit.Top = Convert.ToInt32(Convert.ToDouble(unit.Top) / 3.6);
                }
                else
                {
                    if(unit.side == 1)
                    {
                        Control[] inMoscow = this.Controls.Find("Moscow", true);
                        City inMoscowCity = (City)inMoscow[new Random().Next(0, 3)];

                        //Airborne
                        if(unit.type == 3)
                        {
                            unit.Left = inMoscowCity.Left;
                            unit.Top = inMoscowCity.Top;
                        }
                        else
                        {
                            if(new Random().Next(0, 2) == 0)
                            {
                                unit.Left = 650;
                                unit.Top = 10;
                            }
                            else
                            {
                                unit.Left = inMoscowCity.Left;
                                unit.Top = inMoscowCity.Top;
                            }
                        }
                    }

                    if(unit.side == 0)
                    {
                        unit.Left = 1050 + this.AutoScrollPosition.X;
                        unit.Top = 1050 + this.AutoScrollPosition.Y;

                        if (unit.delayedUnit == true)
                        {
                            unit.delayedUnit = false;
                        }
                       
                            //if((round.turn[1] > 25 && new Random().Next(0, 5) == 0 && unit.Height != 0) || u > Convert.ToInt32(Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][2]))
                        if (round.turn[1] > 25 && new Random().Next(0, 5) == 0 )    
                        {
                            unit.delayedUnit = true;                           
                         }                          
                    }

                    /*
                    if(unit.side == 1)
                    {
                        //if(round.turn[1] > 25 && new Random().Next(0, 3) < 2 && unit.Height != 0 && u > Convert.ToInt32(Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][2]))
                        if (round.turn[1] > 25 && new Random().Next(0, 3) < 2 && unit.Height != 0 && u > Convert.ToInt32(Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][2]))

                        {
                            unit.Height = 0;
                            unit.Width = 0;
                        }
                        else if(unit.Height == 0)
                        {
                            unit.Height = unit.Width = unitSize;
                        }
                        
                    }
                    */

                    /*
                    unit.Left = Convert.ToInt32(Convert.ToDouble(unit.Left) / 2.1);
                    unit.Top = Convert.ToInt32(Convert.ToDouble(unit.Top) / 2.6);
                    unit.Left = unit.Left + 20;
                    unit.Top = unit.Top - 20;
                    */

                    //Test
                     //unit.Top = unit.Left = 900;
                }

                unit.type = Convert.ToInt32(Data.units[u][1]);

                unit.BackgroundImage = (Image)global::Barbarossa.Properties.Resources.ResourceManager.GetObject("_"+Data.unitTypes[Convert.ToInt32(Data.units[u][1])][0][1].ToString());
                unit.Name = Data.units[u][0];
                unit.intel = 1;
                unit.detection = 1;
                unit.plannedMove.Clear();
                unit.supply = ran.Next((100 - (unit.side * 10)), 100);
                ran = new Random();
                unit.strength = ran.Next((100 - (unit.side * 10)), 100);

                //currReinforcementsGerman[currReinforcementsGermanNumber] = unit.Name;
                //currReinforcementsGermanNumber++;
                //currReinforcementsRussian[currReinforcementsRussianNumber] = unit.Name;
                //currReinforcementsRussianNumber++;
               
                if (round.turn[1] == round.turn[4] || (unit.delayedUnit == false && new Random().Next(100) != 0))
                {
                    this.Controls.Add(unit);
               
                    if (unit.side == 1)
                        currReinforcementsRussian.Add(unit.Name);
                    else if (unit.side == 0)
                        currReinforcementsGerman.Add(unit.Name);
                   }
                                
                total++;
                unit.BringToFront();

                if(u == 7)
                    unit.Focus();
            }

            round.currentCalendar[3] = total;          
            //overviewMap.BackgroundImage = global::Barbarossa.Properties.Resources.Russland;
            //overviewMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            //overviewMap.Width = overviewMap.Height = 0;          
                    
            if(round.turn[1] > 25)
                doReplacements();

            this.Overview.Enabled = true;
        }

        public void checkWeather()
        {
            //int weatherFactor = ran.Next(0, 100);
            int weatherFactor = ran.Next(0, 90);
            for (int z=0;z<3;z++){
                
                if (z==0)
                    weatherFactor=weatherFactor-5;
                 if (z==2)
                    weatherFactor=weatherFactor+5;

                /*
                int weatherFactorN=weatherFactor-20;
                int weatherFactorC=weatherFactor;
                int weatherFactorS=weatherFactor+20;
                */
                //negative number is NOT an int
                
                weatherFactor = Math.Abs(weatherFactor);


                for (int f = 0; f < 4; f++)
                {
                    if (weatherFactor < Data.weather[round.turn[1]][f])
                    {
                        if (Data.weatherConditions[f] == "Snowing" && new Random().Next(0, 2) == 1)
                            round.currentGround[z] = "Snow";

                        if (Data.weatherConditions[f] == "Rain" && new Random().Next(0, 2) == 1)
                            round.currentGround[z]= "Mud";

                        if (Data.weatherConditions[f] != "Rain" && Data.weatherConditions[f] != "Snowing" && new Random().Next(0, 2) == 1)
                            round.currentGround[z] = "Clear";

                        //Test
                        round.currentWeather[z] = Data.weatherConditions[f];
                        //round.currentWeather[z] = Data.weatherConditions[f]+ " "+weatherFactor.ToString();
                        
                        /*
                         Russian
                        Weather: 
	                        North: Snowing -2
	                        Center: Snowing -2
	                        South: Calm 3
                        Week 4
                        1941 June1
                         */

                        break;
                    }
                }
            }
        }

        public void doReplacements()
        {
            checkInvasions();
            int replacementPoints = 0;
            replacementCities.Clear();

            for(int c = 0; c < this.Controls.Count; c++)
            {
                if(this.Controls[c].GetType().ToString() == "Barbarossa.City")
                {
                    City replacementCity = this.Controls[c] as City;

                    if(replacementCity.side == 1 && replacementCity.originalSide == 1)
                    {
                        replacementPoints += replacementCity.points;
                        replacementCities.Add(replacementCity);
                    }

                    if(replacementCity.side == replacementCity.originalSide)
                        replacementCity.supply = replacementCity.supply + ((ran.Next(10, 100) / 100) * replacementCity.supply);

                    if(replacementCity.side != replacementCity.originalSide)
                    {
                        replacementCity.depotySupply = new Random().Next(0, 100);

                        if(replacementCity.side == 0)
                            replacementCity.depotySupply = replacementCity.depotySupply * (replacementCity.thisY / 1000);
                    }
                }
            }

            List<Unit> eliminatedRussianUnits = new List<Unit>();

            for(int e = 0; e < eliminated.Count; e++)
            {
                if(eliminated[e].side == 1)
                    eliminatedRussianUnits.Add(eliminated[e]);
            }

            int lendleaseFactor = 0;

            if(round.currentCalendar[1] == 0 && round.currentCalendar[0] >= 10)
                lendleaseFactor++;

            if(round.currentCalendar[1] > 0)
                lendleaseFactor += 2;

            int replacementAmount = new Random().Next(0, replacementPoints);
            Control[] inMoscow = this.Controls.Find("Moscow", true);
            City inMoscowCity = (City)inMoscow[new Random().Next(0, 3)];

            for(int r = 0; r < replacementAmount; r++)
            {
                if(r < eliminatedRussianUnits.Count)
                {
                    int replacementNumber = ran.Next(0, eliminatedRussianUnits.Count);
                    eliminatedRussianUnits[replacementNumber].Height = 18;
                    eliminatedRussianUnits[replacementNumber].Width = 18;

                    if(ran.Next(0, 2) == 0)
                    {
                        //eliminatedRussianUnits[replacementNumber].Left = replacementCities[ran.Next(0, replacementCities.Count)].Left + this.AutoScrollPosition.X;
                        //eliminatedRussianUnits[replacementNumber].Top = replacementCities[ran.Next(0, replacementCities.Count)].Top + this.AutoScrollPosition.Y;                        
                        eliminatedRussianUnits[replacementNumber].Left = replacementCities[ran.Next(0, replacementCities.Count)].Left;
                        eliminatedRussianUnits[replacementNumber].Top = replacementCities[ran.Next(0, replacementCities.Count)].Top;
                    }
                    else
                    {
                        eliminatedRussianUnits[replacementNumber].Left = inMoscowCity.Left + this.AutoScrollPosition.X;
                        eliminatedRussianUnits[replacementNumber].Top = inMoscowCity.Top + this.AutoScrollPosition.Y;
                    }

                    if((eliminatedRussianUnits[replacementNumber].type == 2 || eliminatedRussianUnits[replacementNumber].type == 3 || eliminatedRussianUnits[replacementNumber].type == 4 || eliminatedRussianUnits[replacementNumber].type == 5 || eliminatedRussianUnits[replacementNumber].type == 6) && ran.Next(0, 2) == 0)
                    {
                        eliminatedRussianUnits[replacementNumber].type += 5;
                        eliminatedRussianUnits[replacementNumber].BackgroundImage = (Image)global::Barbarossa.Properties.Resources.ResourceManager.GetObject(Data.unitTypes[eliminatedRussianUnits[replacementNumber].type][0][1].ToString());
                    }

                    eliminatedRussianUnits[replacementNumber].intel = 1;
                    eliminatedRussianUnits[replacementNumber].detection = 1;
                    eliminatedRussianUnits[replacementNumber].strength = 100 - ran.Next(0, 11);
                    eliminatedRussianUnits[replacementNumber].supply = 100 - ran.Next(0, 11);
                    eliminatedRussianUnits[replacementNumber].eliminated = false;
                    currReinforcementsRussian.Add(eliminatedRussianUnits[replacementNumber].Name);
                    eliminated.Remove(eliminatedRussianUnits[replacementNumber]);
                    round.currentCalendar[3]++;
                    eliminatedRussianUnits.Remove(eliminatedRussianUnits[replacementNumber]);
                }
                else
                {
                    break;
                }
            }

            currentNewUnits = "Russian Replacements\n\n";
            if (currReinforcementsRussian.Count > 0)
            {
                for (int r = 0; r < currReinforcementsRussian.Count; r++)
                {
                     if (currReplacementsRussian.Count>0)
                        currentNewUnits += "\t" + currReplacementsRussian[r] + "\n";
                }
             }
             else
             {
                 currentNewUnits += "\t(none)";
             }

            //MessageBox.Show(currentReplacements, "Russian Replacements");

            showNewUnits();
            int germanReplacementNumber = new Random().Next(0, 12);

            if(round.invasions[0])
                germanReplacementNumber = germanReplacementNumber - 1;

            if(round.invasions[1])
                germanReplacementNumber = germanReplacementNumber - 2;

            if(germanReplacementNumber == 11)
            {
                List<Unit> eliminatedGermanUnits = new List<Unit>();

                for(int e = 0; e < eliminated.Count; e++)
                {
                    if(eliminated[e].side == 0)
                        eliminatedGermanUnits.Add(eliminated[e]);
                }

                int replacementNumber = new Random().Next(0, eliminatedGermanUnits.Count);

                if(eliminatedGermanUnits.Count > 0)
                {
                    eliminatedGermanUnits[replacementNumber].Height = 18;
                    eliminatedGermanUnits[replacementNumber].Width = 18;
                    eliminatedGermanUnits[replacementNumber].Left = 1050+ this.AutoScrollPosition.X;
                    eliminatedGermanUnits[replacementNumber].Top = 1050 + this.AutoScrollPosition.Y;
                    eliminatedGermanUnits[replacementNumber].eliminated = false;

                    int replacementFactor = 0;

                    if(round.invasions[0])
                        replacementFactor++;

                    if(round.invasions[1])
                        replacementFactor += 2;

                    if((eliminatedGermanUnits[replacementNumber].type == 18 || eliminatedGermanUnits[replacementNumber].type == 21 || eliminatedGermanUnits[replacementNumber].type == 25 || eliminatedGermanUnits[replacementNumber].type == 28) && (ran.Next(0, 2) + replacementFactor) == 0)
                    {
                        eliminatedGermanUnits[replacementNumber].type += 3;

                        if(eliminatedGermanUnits[replacementNumber].type > 28)
                            eliminatedGermanUnits[replacementNumber].type = 29;

                        eliminatedGermanUnits[replacementNumber].BackgroundImage = (Image)global::Barbarossa.Properties.Resources.ResourceManager.GetObject(Data.unitTypes[eliminatedGermanUnits[replacementNumber].type][0][1].ToString());
                    }

                    eliminatedGermanUnits[replacementNumber].intel = 1;
                    eliminatedGermanUnits[replacementNumber].detection = 1;
                    eliminatedGermanUnits[replacementNumber].strength = 100 - ran.Next(5, 21);
                    eliminatedGermanUnits[replacementNumber].supply = 100 - ran.Next(5, 21);
                    eliminated.Remove(eliminatedGermanUnits[replacementNumber]);
                    round.currentCalendar[3]++;
                    currReinforcementsGerman.Add(eliminatedGermanUnits[replacementNumber].Name);
                }

                currentNewUnits = "German Replacements\n\n";
                if (currReinforcementsGerman.Count > 0)
                {
                    for (int r = 0; r < currReinforcementsGerman.Count; r++)
                    {
                        if (currReplacementsGerman.Count>0)
                            currentNewUnits += "\t" + currReplacementsGerman[r] + "\n";
                    }
                }
                else
                {
                    currentNewUnits += "\t(none)";
                }

              
            }

            //Random German Unit Removal ("Transfer") Rule
            if(germanReplacementNumber < 1)
            {
                for(int c = 0; c < this.Controls.Count; c++)
                {
                    if(this.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                    {
                        Unit removedUnit = this.Controls[c] as Unit;

                        if(removedUnit.type > 17 && new Random().Next(0, 2) == 0)
                        {
                            removedUnit.Width = 0;
                            removedUnit.Height = 0;
                            removedUnit.Left = 1;
                            removedUnit.Top = 1;
                            break;
                        }
                    }
                }
            }
        }

        public void showNewUnits(){
              //MessageBox.Show(currentReplacements, "German Replacements");
            Form promptNew = new Form();
            Panel panelNew = new Panel();
            RichTextBox unitNames = new RichTextBox();
            Button closeInfoNew = new Button();
            
                panelNew.Left = 0;
                panelNew.Top = 0;
                promptNew.Height = 380;
                promptNew.Width = 330;
                panelNew.Width = 330;
                panelNew.Height = 380;
                unitNames.Left = 10;
                unitNames.Top = 10;
                unitNames.Height = 330;
                unitNames.Width = 305;
                closeInfoNew = new Button() { Text = "Continue" };
                closeInfoNew.Top = 350;
                closeInfoNew.Left = 130;
                closeInfoNew.Size = new Size(70, 25);
                closeInfoNew.Font = new Font("Times New Roman", 10);
                closeInfoNew.Click += (sender, e) => { promptNew.Close(); };
                closeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                closeInfo.FlatAppearance.BorderColor = Color.FromArgb(255, 150, 150, 150);
                promptNew.BackColor = Color.FromArgb(255, 150, 150, 150);
                promptNew.FormBorderStyle = FormBorderStyle.None;
                unitNames.Text = currentNewUnits;   
                panelNew.Controls.Add(unitNames);
                panelNew.Controls.Add(closeInfoNew);
                promptNew.Controls.Add(panelNew);
                promptNew.ShowDialog();
        }

        public void checkInvasions()
        {

            currentNewUnits = "Events:\n";
            //Rumanian Withdrawal
            if(bucharestiCaptured)
                doWithdrawal("Rumanian");

            //Hugarian Withdrawal, affected  by Rumanian withdrawal
            if(bucharestiCaptured && ran.Next(0, 2) == 0)
                doWithdrawal("Hugarian");

            //Italian withdrawal, due to Allied invasion or possibly by Rumanian withdrawal
            if(round.currentCalendar[1] == 2 && round.currentCalendar[00] >= 8 && !round.invasions[0])
            {
                if((ran.Next(0, 10) < round.currentCalendar[0]) || (bucharestiCaptured && ran.Next(0, 3) == 0))
                {
                    round.invasions[0] = true;
                    doWithdrawal("Italian");
                    currentNewUnits += "\tItaly invaded!\n";
                }
            }

            //Spanish withdrawal, based on Italian surrender
            if(round.currentCalendar[1] == 2 && round.currentCalendar[0] >= 5)
            {
                int italySurrender = 0;

                if(round.invasions[0])
                    italySurrender = 2;

                if(ran.Next(0, 12) - italySurrender < round.currentCalendar[0])
                {
                    Control[] azul = this.Controls.Find("250th Infantry, Spanish", true);
                    Unit azulUnit = (Unit)azul[0];
                    azulUnit.Width = 0;
                    azulUnit.Height = 0;
                    azulUnit.Left = 1;
                    azulUnit.Top = 0;
                    currentNewUnits += "\t250th (Spanish) removed\n";
                }
            }

            //D-Day
            if(round.currentCalendar[1] == 3 && round.currentCalendar[0] >= 5 && !round.invasions[1])
            {
                if (ran.Next(0, 8) < round.currentCalendar[0])
                {
                    round.invasions[1] = true;
                    currentNewUnits += "\tFrance invaded!\n";
                }
            }

            //Finnish Withdrawal
            if((round.currentCalendar[1] == 3 && ran.Next(0, 2) == 0 && !leningradCaptured && !moscowCaptured) || helsinkiCaptured)
                doWithdrawal("Finnish");

            //Partisans
            if((round.currentCalendar[1] == 0 && round.currentCalendar[0] > 7) || round.currentCalendar[1] > 0)
            {
                if(new Random().Next(0, 4) == 0)
                {
                    Unit unit = new Unit();

                    for(int c = 0; c < this.Controls.Count; c++)
                    {
                        if(this.Controls[c].GetType().ToString() == "Barbarossa.City")
                        {
                            City partisanCity = this.Controls[c] as City;

                            if(partisanCity.side == 0 && partisanCity.originalSide == 1 && ran.Next(0, 3) == 0)
                            {
                                unit.Left = partisanCity.thisX + AutoScrollPosition.X;
                                unit.Top = partisanCity.thisY + AutoScrollPosition.Y;
                                //unit.Left = partisanCity.thisX;
                                //unit.Top = partisanCity.thisY;
                                unit.type = 1;
                                unit.BackgroundImage = (Image)global::Barbarossa.Properties.Resources.ResourceManager.GetObject("_"+Data.unitTypes[1][0][1].ToString());
                                unit.Name = "Partisans";
                                unit.intel = 2;
                                unit.detection = 1;
                                unit.supply = ran.Next(90, 100);
                                ran = new Random();
                                unit.strength = ran.Next(90, 100);
                                this.Controls.Add(unit);
                                break;
                            }
                        }
                    }
                }
            }

            /*
            // Luftwaffe Removal
            if(round.currentCalendar[1] > 0 && round.currentCalendar[0] == 1 && round.turn[1] == 1)
            {
                int lwNumber = new Random().Next(-1, 2);

                if(round.currentCalendar[1] > 1)
                    lwNumber = lwNumber + 1;

                string[] lwUnits = new string[] { "4th LuftFlotte", "1st LuftFlotte", "3rd LuftFlotte" };

                for(int l = 0; l < lwNumber; l++)
                {
                    int lwRemove = ran.Next(0, 3);
                    Control[] lw = this.Controls.Find(lwUnits[lwRemove], true);
                    Unit lwUnit = (Unit)lw[0];

                    //Check if unit is still active
                    if(lwUnit.Width != 0)
                    {
                        lwUnit.Width = 0;
                        lwUnit.Height = 0;
                        lwUnit.Left = 0;
                        lwUnit.Top = 0;
                        currentNewUnits += lwUnit + " removed\n";
                    }
                    else if(l < (lwNumber - 1))
                    {
                        l = l--;
                    }
                }
            }
            */
            showNewUnits();
        }

        public void checkCaptures()
        {
            string[] cities = new string[] { "Moscow", "Moscow", "Moscow", "Leningrad", "Leningrad", "Bucharesti", "Helsinki" };

            for(int C = 0; C < 7; C++)
            {
                Control[] city = this.Controls.Find(cities[C], true);

                for(int c = 0; c < city.Length; c++)
                {
                    City thisCity = city[c] as City;

                    if(thisCity.side == 1)
                    {
                        if(C == 0 || C == 1 || C == 2)
                            moscowCaptured = false;
                        if(C == 3 || C == 4)
                            leningradCaptured = false;
                        if(C == 5)
                            bucharestiCaptured = true;
                        if(C == 6)
                            helsinkiCaptured = true;
                    }
                    else
                    {
                        if(C == 0 && C == 1 && C == 3)
                        {
                            moscowCaptured = true;

                            //Check if Moscow capture affects Russian Command/Control
                            if(!round.moscowTaken[0] && ran.Next(0, 3) == 0)
                                round.moscowTaken[1] = true;

                            round.moscowTaken[0] = true;
                        }

                        if(C == 3 && C == 4)
                            leningradCaptured = true;
                        if(C == 5)
                            bucharestiCaptured = false;
                        if(C == 6)
                            helsinkiCaptured = false;
                    }
                }
            }
            currentNewUnits = "Cities captured:";

            if (moscowCaptured == true)
                currentNewUnits += "\tMoscow under German control\n";

            if (leningradCaptured == true)
                currentNewUnits += "\tLeningrad under German control";

            showNewUnits();

            if((!moscowCaptured && round.invasions[1]) || round.currentCalendar[0] > 3)
                endGame(false);
            else if(moscowCaptured)
                checkGame();
        }

        public void doWithdrawal(String nation)
        {
            for(int c = 0; c < this.Controls.Count; c++)
            {
                if(this.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                {
                    Unit removedUnit = this.Controls[c] as Unit;

                    if(removedUnit.Name.IndexOf(nation) > -1)
                    {
                        removedUnit.Width = 0;
                        removedUnit.Height = 0;
                        removedUnit.Left = 1;
                        removedUnit.Top = 0;
                        currentNewUnits += removedUnit + " removed";

                    }
                }
            }
        }

        public void checkGame()
        {
            double gamePoints = 0;
            for(int c = 0; c < this.Controls.Count; c++)
            {
                if(this.Controls[c].GetType().ToString() == "Barbarossa.City")
                {
                    City pointCity = this.Controls[c] as City;

                    if(pointCity.side == 0 && pointCity.originalSide == 1)
                        gamePoints += new Random().Next(pointCity.points - 1, pointCity.points);

                }
                if(this.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                {
                    Unit pointUnit = this.Controls[c] as Unit;

                    if(pointUnit.side == 1 && pointUnit.eliminated)
                        gamePoints += new Random().Next(0, 2);

                    if(pointUnit.side == 0 && pointUnit.eliminated)
                        gamePoints = gamePoints - new Random().Next(2, 4);
                }

                Random ranPoints = new Random();
                if(round.invasions[0])
                    gamePoints = gamePoints * (ranPoints.Next(80, 96) / 100);
                if(round.invasions[1])
                    gamePoints = gamePoints * (ranPoints.Next(50, 81) / 100);
            }

            if(new Random().Next(0, 500) < gamePoints)
                endGame(true);
        }

        public void endGame(bool german)
        {
            for(int c = 0; c < this.Controls.Count; c++)
            {
                this.Controls.Remove(this.Controls[c]);
            }
					
            if(german)
                this.BackgroundImage = global::Barbarossa.Properties.Resources.German;
            else
                this.BackgroundImage = global::Barbarossa.Properties.Resources.Russian;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.IO.TextWriter saveFile = new System.IO.StreamWriter(@"saveGame.txt");
            startCities = false;
            startUnits = false;
            startTracks = false;
            startGlobal = false;

            for(int c = 0; c < this.Controls.Count; c++)
            {
                if(this.Controls[c].GetType().ToString() == "Barbarossa.City")
                {
                    if(!startCities)
                    {
                        saveFile.WriteLine("Cities");
                        startGlobal = false;
                        startTracks = false;
                        startUnits = false;
                        startCities = true;
                    }

                    City saveCity = this.Controls[c] as City;
                    saveFile.WriteLine(saveCity.Name.ToString() + "," + saveCity.number.ToString() + "," + saveCity.type.ToString() + "," + saveCity.originalSide.ToString() + "," + saveCity.side.ToString() + "," + saveCity.name.ToString() + "," + saveCity.points.ToString() + "," + saveCity.supply.ToString() + "," + saveCity.depotySupply.ToString());
                }
                else if(this.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                {
                    if(!startUnits)
                    {
                        saveFile.WriteLine("Units");
                        startGlobal = false;
                        startCities = false;
                        startTracks = false;
                        startUnits = true;
                    }

                    Unit saveUnit = this.Controls[c] as Unit;
                    engagedUnitList = "";
                    otherUnitList = "";
                    plannedMoveList = "";

                    for(int E = 0; E < saveUnit.engagedUnits.Count; E++)
                    {
                        engagedUnitList += saveUnit.engagedUnits[E].Name + "-";
                    }

                    for(int O = 0; O < saveUnit.otherUnits.Count; O++)
                    {
                        otherUnitList += saveUnit.otherUnits[O].Name + "-";
                    }

                    for(int P = 0; P < saveUnit.plannedMove.Count; P++)
                    {
                        string plannedMoveCoords = saveUnit.plannedMove[P].X.ToString() + "x" + saveUnit.plannedMove[P].Y.ToString();
                        plannedMoveList += plannedMoveCoords + "-";
                    }

                    string unitName = saveUnit.Name.ToString();
                    unitName = unitName.Replace(",", " ");
                    saveFile.WriteLine(unitName + "," + saveUnit.type.ToString() + "," + saveUnit.intel.ToString() + "," + saveUnit.side.ToString() + "," + saveUnit.strength.ToString() + "," + saveUnit.detection.ToString() + "," + saveUnit.supply.ToString() + "," + saveUnit.didMove.ToString() + "," + saveUnit.doMove.ToString() + "," + saveUnit.doDelayedMove.ToString() + "," + saveUnit.didResupply.ToString() + "," + saveUnit.didCombat.ToString() + "," + saveUnit.checkTrain.ToString() + "," + saveUnit.onTrain.ToString() + "," + saveUnit.inCity.ToString() + "," + saveUnit.retreated.ToString() + "," + saveUnit.supplies.ToString() + "," + saveUnit.distanceMoved.ToString() + "," + saveUnit.scrollX.ToString() + "," + saveUnit.scrollY.ToString() + "," + (saveUnit.Left - this.AutoScrollPosition.X).ToString() + "," + (saveUnit.Top - this.AutoScrollPosition.Y).ToString() + "," + saveUnit.delayedMove.ToString() + "," + saveUnit.delayedAttack.ToString() + "," + saveUnit.randomDelay.ToString() + "," + saveUnit.currentTurn.ToString() + "," + saveUnit.currentTerrain.ToString() + "," + saveUnit.coordinatingAttack.ToString() + "," + saveUnit.eliminated.ToString() + "," + saveUnit.didAirdrop.ToString() + "," + saveUnit.didDelayedMove.ToString() + "," + saveUnit.didDelayedAttack.ToString() + "," + this.engagedUnitList.ToString() + "," + this.otherUnitList.ToString() + "," + this.plannedMoveList.ToString());
                }
                else if(this.Controls[c].GetType().ToString() == "Barbarossa.Track")
                {
                    if(!startTracks)
                    {
                        saveFile.WriteLine("Tracks");
                        startGlobal = false;
                        startCities = false;
                        startUnits = false;
                        startTracks = true;
                    }

                    Track saveTrack = this.Controls[c] as Track;
                    saveFile.WriteLine((saveTrack.Left - this.AutoScrollPosition.X).ToString() + "," + (saveTrack.Top - this.AutoScrollPosition.Y).ToString());
                }
            }

            saveFile.WriteLine("Global");
            saveFile.WriteLine(round.turn[0].ToString() + "," + round.turn[1].ToString() + "," + round.turn[2].ToString() + "," + round.turn[3].ToString() + "," + round.turn[4].ToString());
            saveFile.WriteLine(round.currentCalendar[0].ToString() + "," + round.currentCalendar[1].ToString() + "," + round.currentCalendar[2].ToString() + "," + round.currentCalendar[3].ToString());
            saveFile.WriteLine(round.currentWeather[0] + "," + round.currentWeather[1] + "," + round.currentWeather[2]);
            saveFile.WriteLine(round.currentGround[0] + "," + round.currentGround[1] + "," + round.currentGround[2]);
            saveFile.WriteLine(round.invasions[0].ToString() + "," + round.invasions[1].ToString() + "," + round.invasions[2].ToString());

            for(int EL = 0; EL < this.engaged.Count; EL++)
            {
                engagedList += engaged[EL].Name + ",";
            }

            for(int ML = 0; ML < this.moving.Count; ML++)
            {
                movingList += moving[ML].Name + ",";
            }

            for(int XL = 0; XL < this.eliminated.Count; XL++)
            {
                eliminatedList += eliminated[XL].Name + ",";
            }

            saveFile.WriteLine(engagedList);
            saveFile.WriteLine(movingList);
            saveFile.Flush();
        }

        public void setEliminated(Unit u)
        {
            eliminated.Add(u);
        }

        public void setEngaged(Unit u)
        {
            engaged.Add(u);
        }

        public void getEngaged()
        {
            for(int e = 0; e < engaged.Count; e++)
            {
                if(!engaged[e].eliminated)
                {
                    if(engaged[e].delayedAttack == 1)
                    {
                        engaged[e].doCombat(engaged[e]);
                        engaged.Remove(engaged[e]);
                    }
                    else if(engaged[e].delayedAttack == 0)
                    {
                        engaged[e].delayedAttack = engaged[e].delayedAttack + 1;
                    }
                }
            }
        }

        public void setMoving(Unit u)
        {
            moving.Add(u);
            currentUnit = u;
        }

        public void getMoving()
        {
            for(int m = 0; m < moving.Count; m++)
            {
                moving[m].delayedMove = moving[m].delayedMove + 1;

                if(moving[m].delayedMove > 1 && !moving[m].eliminated)
                {
                    doPlannedMove = true;
                    moving[m].didDelayedMove = true;
                    moving[m].doDelayedMove = true;
                    moving[m].doMove = true;
                    moving[m].didMove = false;
                    moving[m].distanceMoved = 0;

                    if(moving[m].onTrain)
                        moving[m].allowedMove = Convert.ToDouble(ran.Next(100, 1000));

                    moving[m].allowedMove = moving[m].allowedMove * (moving[m].intel);
                    moving[m].allowedMove = moving[m].allowedMove / moving[m].detection;
                    moving[m].terrainName = "";
                    moving[m].startX = moving[m].Left;
                    moving[m].startY = moving[m].Top;

                    if(moving[m].onTrain)
                        moving[m].BackColor = System.Drawing.Color.Pink;
                    else
                        moving[m].BackColor = System.Drawing.Color.Empty;

                    moving[m].currentMove = 0;
                    moving[m].currentDistance = 0;
                    moving[m].totalDistance = 0;
                    moving[m].totalMove = 0;

                    for(int M = 0; M < moving[m].plannedMove.Count; M++)
                    {
                        moving[m].makeMove();
                    }

                    doPlannedMove = false;
                    moving[m].plannedMove.Clear();
                }
            }
        }

        public void removeMove(Unit mover)
        {
            moving.Remove(mover);
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            showRules();
        }

        private void conditionsDetails_MouseEnter(object sender, EventArgs e)
        {            
            conditionsDetails.Text = round.currentWeather[z];
            conditionsDetails.Text += "\n" + round.currentGround[z];
            conditionsDetails.Text += "\nWeek " + round.turn[0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][0][0].ToString(); 
            conditionsDetails.Text +="\n" + Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][0].ToString();
        }

        private void Condition_Selected(object sender, EventArgs e)
        {
            conditionsDetails.Text = round.currentWeather[z];
            conditionsDetails.Text += "\n" + round.currentGround[z];
            conditionsDetails.Text += "\nWeek " + round.turn[0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][0][0].ToString(); 
            conditionsDetails.Text += "\n" + Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][0].ToString();
        }

        private void GermanControlled_Click(object sender, EventArgs e)
        {
            if(!showGerman)
                showGerman = true;
            else
                showGerman = false;

            for(int c = 0; c < this.Controls.Count; c++)
            {
                if(this.Controls[c].GetType().ToString() == "Barbarossa.City")
                {
                    City GermanCity = this.Controls[c] as City;

                    if(GermanCity.side == 0)
                    {
                        if(showGerman)
                            GermanCity.BackgroundImage = global::Barbarossa.Properties.Resources.German_City2;
                        else
                            GermanCity.BackgroundImage = null;
                    }

                    //GermanCity.SendToBack();
                }

                if(this.Controls[c].GetType().ToString() == "Barbarossa.Track")
                {
                    Track GermanTrack = this.Controls[c] as Track;

                    if(showGerman)
                        GermanTrack.BackgroundImage = global::Barbarossa.Properties.Resources.Converted_Railroad;
                    else
                        GermanTrack.BackgroundImage = null;

                    if (showGerman)
                        GermanTrack.Width = GermanTrack.Height = 12;                        //GermanTrack.BackColor = System.Drawing.Color.Red;
                    else
                        GermanTrack.Width = GermanTrack.Height = 6;         //GermanTrack.BackColor = System.Drawing.Color.Transparent;                    

                        GermanTrack.BackColor = System.Drawing.Color.Transparent; 
                }
            }
        }

        private void politicalStatus_Click(object sender, EventArgs e)
        {
        }

        private void politicalStatus_MouseEnter(object sender, EventArgs e)
        {
            politicalStatusDetails.Text="";
            
            if (round.invasions[0])
                politicalStatusDetails.Text += "Italy invaded\n";

            if (round.invasions[1])
                politicalStatusDetails.Text += "France invaded";

        }

        private void showAll_Click(object sender, EventArgs e)
        {
            //if (showAllUnits==true){

             for(int c = 0; c < this.Controls.Count; c++)
            {
            
                if(this.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                {
                    Unit thisUnit = this.Controls[c] as Unit;

                    if (thisUnit.side == round.turn[2])
                        thisUnit.BringToFront();
                                    
                }
                
           //showAllUnits=false;

            }
    
        }

        private void nextMonthReinforcement_Click(object sender, EventArgs e)
        {
            if (showReinforcements == false)
            {
                nextMonthReinforcements = new Reinforcements();
                nextMonthReinforcements.Show();
                showReinforcements = true;
            }
            else
            {
                nextMonthReinforcements.Close();
                nextMonthReinforcements.Dispose();
                showReinforcements = false;
            }
        }
        
        private void showRules()
        {
            try
            {
                System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
                string filename = "Rules.pdf";
                string dd = thisExe.GetName().Name;
                System.IO.Stream fileIn = thisExe.GetManifestResourceStream(thisExe.GetName().Name + "." + filename);

                //Write the file and close it
                if(!File.Exists(@"Rules.pdf"))
                {
                    System.IO.Stream fileOut = System.IO.File.OpenWrite(@"Rules.pdf");
                    const int SIZE_BUFF = 1024;
                    byte[] buffer = new Byte[SIZE_BUFF];
                    int bytesRead;

                    while((bytesRead = fileIn.Read(buffer, 0, SIZE_BUFF)) > 0)
                    {
                        fileOut.Write(buffer, 0, bytesRead);
                    }

                    fileOut.Close();
                }

                System.Diagnostics.Process.Start(@"Rules.pdf ");
            }
            catch(Exception ex) { }
        }
        
        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (MousePosition.X < 320)
                z = 0;
            if (MousePosition.X > 1420)
                z = 2;

            if(round.turn[2] == 0)
                Active.Text = "German";
            else
                Active.Text = "Russian";
            /*
            Conditions.Text = round.currentWeather;
            Conditions.Text += "\n" + round.currentGround;
            Conditions.Text += "\n\nWeek " + round.turn[0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][0][0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][0].ToString();
            */
            int currX = (MousePosition.X - AutoScrollPosition.X);
            int currY = (MousePosition.Y - AutoScrollPosition.Y);
            Color terrainType = round.terrain.GetPixel(currX, currY);
            string terrainName = "Clear";
                
            //RR
            if (terrainType.R > 200 && terrainType.B < 150)
                terrainName += "Railroad";

            //River; Possibly Clear terrain during winter
            if (terrainType.R < 150 && terrainType.G < 150 && terrainType.B > 200 && ((round.currentGround[z] == "Snow" && new Random().Next(0, 3) < 2) || (round.currentGround[z] != "Snow")))
                terrainName += "River";

            //Towns/Cities
            if (terrainType.R < 150 && terrainType.G > 200 && terrainType.B > 200)
                terrainName += "Town";

            //Swamps; Probably Clear terrain during winter
            if (terrainType.R > 200 && terrainType.G < 150 && terrainType.B > 200 && ((round.currentGround[z] == "Snow" && new Random().Next(0, 2) == 1) || (round.currentGround[z] != "Snow")))
                terrainName += "Swamp";

            //Woods
            if (terrainType.R < 150 && terrainType.G > 200 && terrainType.B < 150)
                terrainName += "Woods";

            //Mountains
            if (terrainType.R > 200 && terrainType.G > 200 && terrainType.B > 200)
                terrainName += "Mountains";

            conditionsDetails.Text = "Weather: " +round.currentWeather[z];

           // if (round.currentGround[z] != "Clear")
                conditionsDetails.Text += "\nGround " + round.currentGround[z];

            conditionsDetails.Text += "\nTerrain: " + terrainName;
            conditionsDetails.Text += "\nWeek " + round.turn[0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][0][0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][0].ToString();
            Conditions.ShowDropDown();             
        }

        private void Game_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            round.mapCoords[0] = MousePosition.X - AutoScrollPosition.X;    
            round.mapCoords[1] = MousePosition.Y - AutoScrollPosition.Y;

            try                
            {
                if (overview)
                    Overview.GetType().GetMethod("moveMouse").Invoke(Overview, null);
            }
            catch (NullReferenceException exception) { }
            //ParentForm.GetType().GetMethod("getEngaged").Invoke(ParentForm, null);
            */
        }

        int theWidth = 1920;
        int theHeight = 1080;
        int theTop = 0;
        int theLeft = 0;
        bool changeZoom = false;

        private void Conditions_MouseEnter(object sender, EventArgs e)
        {
            //conditionsDetails.Text += "\n\nWeek " + round.turn[0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][0][0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][0].ToString();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (changeZoom)
                e.Graphics.DrawImage(BackgroundImage,theLeft, theTop, theWidth, theHeight);

            //MessageBox.Show(this.currentUnit.Name);
            
       //     base.OnPaint(e);
        }        

        private void Conditions_Click(object sender, EventArgs e)
        {
            //conditionsDetails.Text += "\n\nWeek " + round.turn[0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][0][0].ToString() + "\n" + Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][0].ToString();
         }

        private void Active_Click(object sender, EventArgs e)
        {
            round.turn[4] = 1;
           
            if (round.turn[2] == 0)
            {
                round.turn[2] = 1;
                if (new Random().Next(0, 2) == 0)
                    checkWeather();
            }
            else
            {
                round.turn[2] = 0;
                checkWeather();
                //Put in ActiveControl check

                //if (round.turn[2] == 1)
                //if (round.turn[4] == 1)
                
                round.turn[0] = round.turn[0] + 1;
                round.turn[1] = round.turn[1] + 1;
                
                //ParentForm.GetType().GetMethod("getMoving").Invoke(ParentForm, null);
                //ParentForm.GetType().GetMethod("getEngaged").Invoke(ParentForm, null);
                Console.Write(round.turn[2]+ "  "+ round.turn[0] + "  " + Convert.ToInt32(Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][1]) + ",      ");
                getMoving();
                getEngaged();

                if (round.turn[0] > Convert.ToInt32(Data.calendar[round.currentCalendar[0]][round.currentCalendar[1]][1]))
                {
                    round.turn[0] = 1; //Sets Week back to 1 when new month starts
                    //ParentForm.GetType().GetMethod("unitSetup").Invoke(ParentForm, null);
            
                    if (round.currentCalendar[1] < 12)
                    {
                        round.currentCalendar[1] = round.currentCalendar[1] + 1;
                    }
                    else
                    {
                        round.currentCalendar[1] = 1;
                        round.currentCalendar[0] = round.currentCalendar[0] + 1;
                        round.turn[1] = 0;
                    }

                    unitSetup();
                }

                if (round.turn[0] == 1)
                {
                    if (round.turn[2] == 0){
                        currentNewUnits = "German Reinforcements\n\n";
                        if (currReinforcementsGerman.Count < 1)
                            currentNewUnits += "\t(none)";

                        for (int r = 0; r < currReinforcementsGerman.Count; r++)
                        {
                            currentNewUnits += "\t" + currReinforcementsGerman[r] + "\n";
                        }


                        showNewUnits();
                    }
                    else if (round.turn[2] == 1){
                        currentNewUnits = "Russian Reinforcements\n\n";

                        if (currReinforcementsRussian.Count < 1)
                            currentNewUnits += "\t(none)";


                        for (int r = 0; r < currReinforcementsRussian.Count; r++)
                        {
                            currentNewUnits += "\t" + currReinforcementsRussian[r] + "\n";
                        }

                        showNewUnits();
                    }
                }

                    for (int c = 0; c < this.Controls.Count; c++)
                    {
                        if (this.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                        {
                            Unit clearUnit = this.Controls[c] as Unit;
                            clearUnit.didMove = false;

                            if (clearUnit.side == round.turn[2])
                            {
                                if (clearUnit.onTrain)
                                    clearUnit.BackColor = System.Drawing.Color.Pink;
                                else
                                    clearUnit.BackColor = System.Drawing.Color.Empty;
                            }
                        }
                    }


                    //Why is this invoked a second time?
                    //ParentForm.GetType().GetMethod("unitSetup").Invoke(ParentForm, null);
                }
            //}     
            panel.Controls.Remove(chk);
            panel.Controls.Remove(newGame);
            panel.Controls.Remove(savedGame);
            panel.Controls.Add(startingConditions);
            //panel.Controls.Remove(closeInfo);
            startConditions();
            
            prompt.ShowDialog();
            //
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {

            if (nextMonthReinforcements != null)
            {
                nextMonthReinforcements.Close();
                nextMonthReinforcements.Dispose();
                showReinforcements = false;
            }

            //mapDetail.BringToFront();
   
            
            //mapDetail.Refresh();

            showInset();


            //MessageBox.Show(MousePosition.X.ToString() + "," + MousePosition.Y.ToString());
        }


        public void showInset()
        {
/*
            if (mapDetail != null)
                mapDetail.Dispose();

            mapDetail = new Detail();

            mapDetail.Show(this);
            */
        }

        /*
        private Image backgroundImage;


        protected override void  map  OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);


            
            var rc = new Rectangle((0 - (Game.MousePosition.X) * 2) + 150,
                (0 - (Game.MousePosition.Y) * 2) + 150,
                backgroundImage.Width, backgroundImage.Height);
            e.Graphics.DrawImage(backgroundImage, rc);

        }
    */

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Map_Click(object sender, EventArgs e)
        {


        }
    }
}

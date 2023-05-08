using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;

namespace Barbarossa
{
    public partial class Unit : UserControl
    {
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public const int HORZSIZE = 4;
        public const int VERTSIZE = 6;
        public const double MM_TO_INCH_CONVERSION_FACTOR = 25.4;

        public List<Unit> engagedUnits = new List<Unit>() { };
        public List<Unit> otherUnits = new List<Unit>() { };
        public List<Point> plannedMove = new List<Point>() { };
        public Random ran = new Random();
        public City source;
        public double strength;
        public double supply;
        public double intel = 1;
        public double detection = 1;
        public double movementSupply;
        public double combatSupply;
        public double allowedMove;
        public double currentMove;
        public double currentDistance;
        public double totalMove;
        public double totalDistance;
        public int side;
        public int type;
        public int currentTurn;
        public int distanceMoved = 0;
        public int randomDelay = 0;
        public int dx, dy;
        public int t, l;
        public int currX, currY;
        public int scrollX, scrollY;
        public int startX, startY;
        public int prevX, prevY;
        public int trackX, trackY;
        public int delayedMove = 2;
        public int delayedAttack = 2;
        public int unitQuality = 0;
        public bool surprise = false;
        public bool retreated = false;
        public bool supplies;
        public bool didMove;
        public bool doMove;
        public bool doDelayedMove = false;
        public bool didResupply = false;
        public bool didCombat = false;
        public bool checkTrain = false;
        public bool onTrain = false;
        public int z = 1;

        //DELEEUW: If unit is on railroad terrain, regardless of terrainName
        public bool onRail = false;

        public bool inCity = false;
        public bool badMove = false;
        public bool didDelayedMove = false;
        public bool didDelayedAttack = false;
        public bool delayedUnit = false;
        public bool coordinatingAttack = false;
        public bool eliminated = false;
        public bool didAirdrop = false;
        public string terrainName = "";
        public string currentTerrain = "Clear";
        public string currentUnitWeather = "Calm";
        public string currentUnitGround = "Clear";
        public string currentWeather = "Calm";
        public string currentGround = "Clear";
        public int trackProgress = 0;
        public double physicalX = 1;
        public double physicalY = 1;
        public double physicalDelta = 1;
        public double currentMovementConditions = 0;
        public int unitSquare = 19;

        public Unit()
        {
            InitializeComponent();

            var hDC = Graphics.FromHwnd(this.Handle).GetHdc();
            int horizontalSizeInMilliMeters = GetDeviceCaps(hDC, HORZSIZE);
            double horizontalSizeInInches = horizontalSizeInMilliMeters / MM_TO_INCH_CONVERSION_FACTOR;
            int verticalSizeInMilliMeters = GetDeviceCaps(hDC, VERTSIZE);
            double verticalSizeInInches = verticalSizeInMilliMeters / MM_TO_INCH_CONVERSION_FACTOR;
            physicalX = horizontalSizeInInches / 26.6;
            physicalY = verticalSizeInInches / 15;
            physicalDelta = Math.Sqrt((physicalX * physicalX) + (physicalY * physicalY));
        }

        public void Unit_MouseEnter(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Focus();

            if (this.Left < 320)
                z = 0;
            if (this.Left > 1420)
                z = 2;

            if ((((!this.didMove || this.currentTurn != round.turn[1]) && this.plannedMove.Count < 1) || this.side != round.turn[2]) && this.Parent.ToString().IndexOf("Map") < 0)
            {
                if (this.onTrain)
                    this.BackColor = System.Drawing.Color.Pink;
                else
                    this.BackColor = System.Drawing.Color.Empty;
            }
        }

        public void Unit_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.terrainName.IndexOf("Rail") > -1 && this.terrainName.IndexOf("City") > -1 && (this.side == 1 || (this.side == 0 && this.checkTrain)))
                contextMenuStrip1.Items["Train"].Enabled = true;
            else
                contextMenuStrip1.Items["Train"].Enabled = false;
            if (MouseButtons.ToString() != "Right")
                this.Focus();

            if ((!this.didMove || this.currentTurn != round.turn[1]) && this.plannedMove.Count < 1)
            {
                for (int c = 0; c < Parent.Controls.Count; c++)
                {
                    if (Parent.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                    {
                        if (new Random().Next(0, 10) == 0)
                        {
                            Unit deployingUnit = Parent.Controls[c] as Unit;

                            if (deployingUnit.Left > 600 && deployingUnit.Left < 1200 && deployingUnit.Top > 300 && deployingUnit.Top < 400 && deployingUnit.delayedAttack > 1 && deployingUnit.delayedMove > 1 && this != deployingUnit)
                            {
                                int ranMove = ran.Next(-50, 50);
                                int ranX = deployingUnit.Left + ranMove;
                                int ranY = deployingUnit.Top + ranMove;

                                if (ranX - ParentForm.AutoScrollPosition.X < Parent.Width && ranY - ParentForm.AutoScrollPosition.Y < Parent.Height)
                                {
                                    Color terrainType = round.terrain.GetPixel((ranX - ParentForm.AutoScrollPosition.X) - 20, (ranY - ParentForm.AutoScrollPosition.Y) - 20);

                                    if ((terrainType.R > 20 || terrainType.G > 20 || terrainType.B > 20) && this.side != deployingUnit.side)
                                    {
                                        deployingUnit.Left = ranX;
                                        deployingUnit.Top = ranY;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }

            if (this.side == round.turn[2] && !this.didMove)
            {
                this.surprise = false;

                if (round.turn[1] == round.turn[4] && this.side == 0 && round.turn[2]==0)
                {
                    this.allowedMove = ran.Next(Convert.ToInt32(Convert.ToDouble(Data.unitTypes[this.type][1][0])), (Convert.ToInt32(Convert.ToDouble(Data.unitTypes[this.type][1][0])) * 2));

                    if (ran.Next(0, 5) != 0)
                        this.surprise = true;

                    if (this.surprise)
                        this.allowedMove += ran.Next(Convert.ToInt32(this.allowedMove / 10));
                }
                else if (round.moscowTaken[0] && round.moscowTaken[1] && this.side == 1)
                {
                    this.allowedMove = ran.Next(Convert.ToInt32(Convert.ToDouble(Data.unitTypes[this.type][1][0]) / 2), (Convert.ToInt32(Convert.ToDouble(Data.unitTypes[this.type][1][0]))));
                }
                // Finnish rule
                else if (this.type == 12 && this.Left > 200)
                {
                    if (ran.Next(0, 10) == 1)
                        this.allowedMove = ran.Next(Convert.ToInt32(Convert.ToDouble(Data.unitTypes[this.type][1][0]) / 2), (Convert.ToInt32(Convert.ToDouble(Data.unitTypes[this.type][1][0]))));
                    else
                        this.allowedMove = 0;
                }
                else
                {
                    this.allowedMove = ran.Next(Convert.ToInt32(Convert.ToDouble(Data.unitTypes[this.type][1][0]) / 2), (Convert.ToInt32(Convert.ToDouble(Data.unitTypes[this.type][1][0])) * 2));
                }

                if (this.onTrain)
                    this.allowedMove = ran.Next(100, 1000);

                //For full 1080x1920 screen
                this.allowedMove = Convert.ToInt32(Convert.ToDouble(this.allowedMove) / 1.5);

                //Physical screen
                if (physicalDelta > 1)
                    physicalDelta = 1;

                this.allowedMove = Convert.ToInt32(this.allowedMove * physicalDelta);

                if (this.onTrain)
                    this.BackColor = System.Drawing.Color.Pink;
                else
                    this.BackColor = System.Drawing.Color.Empty;

                this.currentMove = 0;
                this.currentDistance = 0;
                this.totalDistance = 0;
                this.totalMove = 0;
                this.distanceMoved = 0;
                this.badMove = false;
                this.doMove = true;
                this.startX = this.Left;
                this.startY = this.Top;
                this.terrainName = "";
                this.scrollX = ParentForm.AutoScrollPosition.X;
                this.scrollY = ParentForm.AutoScrollPosition.Y;
                this.allowedMove = this.allowedMove * (this.intel);
                this.allowedMove = this.allowedMove / this.detection;
                this.randomDelay = new Random().Next(0, 3);
                currentMovementConditions = 0;

                //if (this.surprise)
                //this.randomDelay++;

                if (this.type > 11)
                    this.unitQuality = 1;

                if ((this.randomDelay - (this.unitQuality * -1)) < 2 && this.side == round.turn[2])
                {
                    this.doDelayedMove = true;
                    this.delayedMove = this.randomDelay;
                    Parent.GetType().GetMethod("setMoving").Invoke(Parent, new object[] { this });
                }
                else
                {
                    this.delayedMove = 2;
                    this.doDelayedMove = false;
                }
            }
            else
            {
                if (this.Left > 1300)
                    this.contextMenuStrip1.Left = this.contextMenuStrip1.Left - 300;
                if (this.Top > 700)
                    this.contextMenuStrip1.Top = this.contextMenuStrip1.Top - 300;
            }
        }

        public void Unit_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.side == round.turn[2])
            {
                makeMove();
                round.lastMoved = this;
            }         
        }

        public void makeMove()
        {
            if (this.doMove)
            {
                if (this.currentMove < this.allowedMove && this.supply > 10)
                {
                    this.SendToBack(); //Is this needed??

                    if (round.currentGround[z] == "Snow" && new Random().Next(0, 2) == 1)
                        this.currentUnitWeather = "Snowing";

                    if (round.currentGround[z] == "Mud" && new Random().Next(0, 2) == 1)
                        this.currentUnitWeather = "Rain";


                    if ((Math.Abs((MousePosition.Y + (Math.Abs(ParentForm.AutoScrollPosition.Y - this.scrollY))) - this.Top) < 30 && Math.Abs((MousePosition.X + (Math.Abs(ParentForm.AutoScrollPosition.X - this.scrollX))) - this.Left) < 30) || this.doDelayedMove)
                    {
                        this.terrainName = ""; //??
                        this.totalMove = this.currentMove;
                        this.prevY = this.Top;
                        this.prevX = this.Left;

                        if (Math.Abs((MousePosition.Y - 8) - this.Top) > 2)
                            this.dy = Convert.ToInt32(Convert.ToDouble((MousePosition.Y - 8) - this.Top) / Convert.ToDouble(Math.Abs((MousePosition.Y - 8) - this.Top)));
                        else
                            this.dy = 0;

                        if (Math.Abs((MousePosition.X - 8) - this.Left) > 2)
                            this.dx = Convert.ToInt32(Convert.ToDouble((MousePosition.X - 8) - this.Left) / Convert.ToDouble(Math.Abs((MousePosition.X - 8) - this.Left)));
                        else
                            this.dx = 0;

                        if (this.scrollX != ParentForm.AutoScrollPosition.X || this.scrollY != ParentForm.AutoScrollPosition.Y)
                        {
                            this.doMove = false;
                            endMove();
                        }

                        if (this.delayedMove > 1)
                        {
                            if (!this.doDelayedMove)
                            {
                                this.Left = MousePosition.X - 8;
                                this.Top = MousePosition.Y - 8;

                                //"No Retreat" Rule 
                                if (this.side == 0 && this.currY - this.startY > 50 && this.currX - this.startX < 50 && ran.Next(0, 3) > 0 && !this.onTrain)
                                    endMove();

                                this.plannedMove.Clear();
                            }
                            else
                            {
                                if (this.distanceMoved < this.plannedMove.Count)
                                {
                                    this.Left = this.plannedMove[this.distanceMoved].X + ParentForm.AutoScrollPosition.X;
                                    this.Top = this.plannedMove[this.distanceMoved].Y + ParentForm.AutoScrollPosition.Y;
                                    this.didDelayedMove = true;
                                    this.distanceMoved++;
                                }
                            }

                            this.currentUnitGround = null;
                            this.currentUnitWeather = null;
                        }
                        else
                        {
                            this.Left = MousePosition.X - 8;
                            this.Top = MousePosition.Y - 8;
                            this.plannedMove.Add(new Point(this.Left - ParentForm.AutoScrollPosition.X, this.Top - ParentForm.AutoScrollPosition.Y));

                            this.didDelayedMove = true;
                            this.currentUnitGround = round.currentGround[z];
                            this.currentUnitWeather = round.currentWeather[z];
                        }

                        this.detection =Math.Round( this.detection + ((Convert.ToDouble(new Random().Next(1, 10)) / 10) * (this.currentMove * .0001) + (this.strength / 50)));
                        this.intel = Math.Round(this.intel + ((Convert.ToDouble(new Random().Next(1, 10)) / 10) * (this.currentMove * .0001) + (this.strength / 100)));
                        currentWeather = round.currentWeather[z];
                        currentGround = round.currentGround[z];

                        if (this.currentUnitGround != null)
                            currentGround = this.currentUnitGround;
                                             
                         if ( this.currentUnitWeather != null)
                            currentWeather = this.currentUnitWeather;
                       
                        for (int t = 3; t < 12; t++) //NOT incrementing for units previously moved (sometm
                        {
                            for (int l = 3; l < 12; l++)
                            {
                                currentMovementConditions = (((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][Data.conditions.IndexOf(currentWeather) + 1][0])) + (Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][Data.conditions.IndexOf(currentGround) + 1][0]))) / (unitSquare*unitSquare));
                                this.currentMove = this.currentMove + currentMovementConditions;

                                if (!this.onTrain || (this.type == 3 && !this.didAirdrop && !this.onTrain))
                                {
                                    currentMovementConditions = (((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][Data.conditions.IndexOf(currentWeather) + 1][0])) + (Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][Data.conditions.IndexOf(currentGround) + 1][0]))) / (unitSquare*unitSquare));

                                    this.currentMove = this.currentMove + currentMovementConditions;
                                    this.currX = ((this.Left - ParentForm.AutoScrollPosition.X) + l);
                                    this.currY = ((this.Top - ParentForm.AutoScrollPosition.Y) + t);

                                    if (this.currX < 1)
                                        this.currX = 1;

                                    if (this.currY < 1)
                                        this.currY = 1;

                                    if (this.currX > 1900)
                                        this.currX = 1900;

                                    if (this.currY > 1050)
                                        this.currY = 1050;

                                    Color terrainType = round.terrain.GetPixel(this.currX, this.currY);

                                    //RR
                                    if (terrainType.R > 200 && terrainType.B < 150) //&& terrainType.G < 200
                                    {
                                        this.terrainName += "Railroad,";
                                        this.trackX = this.Left + l;
                                        this.trackY = this.Top + t;

                                        if (!this.doDelayedMove)
                                        {
                                            if (this.side == 0 && this.type != 30)
                                            {
                                                int railFactor = ran.Next(0, 6);

                                                if (Convert.ToInt32(railFactor - this.trackProgress) > Convert.ToInt32((this.strength / 100) * (this.supply / 100)))
                                                {
                                                    this.trackProgress++;
                                                }
                                                else
                                                {
                                                    Track newTrack = new Track();
                                                    newTrack.Left = this.Left;
                                                    newTrack.Top = this.Top;
                                                    newTrack.Width = newTrack.Height = 6;
                                                    Parent.Controls.Add(newTrack);
                                                    newTrack.Visible = true;
                                                    newTrack.Focus();
                                                    newTrack.SendToBack();
                                                    this.trackProgress = 0;
                                                }
                                            }
                                        }
                                    }

                                    //Clear terrain
                                    if (terrainType.R < 150 && terrainType.G < 150 && terrainType.B < 150)
                                    {
                                        this.currentMove = this.currentMove + ((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][6][0])) / (unitSquare*unitSquare));
                                    }

                                    //River; Possibly Clear terrain during winter
                                    if (terrainType.R < 150 && terrainType.G < 150 && terrainType.B > 200 && ((round.currentGround[z] == "Snow" && new Random().Next(0, 3) < 2) || (round.currentGround[z] != "Snow")))
                                    {
                                        this.currentMove = this.currentMove + ((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][7][0])) / (unitSquare*unitSquare));
                                        this.terrainName += "River,";
                                    }

                                    //Towns/Cities
                                    if (terrainType.R < 150 && terrainType.G > 200 && terrainType.B > 200)
                                    {
                                        this.currentMove = this.currentMove + ((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][8][0])) / (unitSquare*unitSquare));
                                        this.terrainName += "Town,";
                                    }

                                    //Swamps; Probably Clear terrain during winter
                                    if (terrainType.R > 200 && terrainType.G < 150 && terrainType.B > 200 && ((round.currentGround[z] == "Snow" && new Random().Next(0, 2) == 1) || (round.currentGround[z] != "Snow")))
                                    {
                                        this.currentMove = this.currentMove + ((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][9][0])) / (unitSquare*unitSquare));
                                        this.terrainName += "Swamp,";
                                    }

                                    //Woods 
                                    if (terrainType.R < 150 && terrainType.G > 200 && terrainType.B < 150)
                                    {
                                        this.currentMove = this.currentMove + ((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][10][0])) / (unitSquare*unitSquare));
                                        this.terrainName += "Woods,";
                                    }

                                    //Mountains
                                    if (terrainType.R > 200 && terrainType.G > 200 && terrainType.B > 200)
                                    {
                                        this.currentMove = this.currentMove + ((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][12][0])) / (unitSquare*unitSquare));
                                        this.terrainName += "Mountains,";
                                    }

                                    if (terrainType.R < 20 && terrainType.G < 20 && terrainType.B < 20 && terrainType.A > 0)
                                    {
                                        this.Top = this.prevY;
                                        this.Left = this.prevX;
                                        this.badMove = true;
                                    }                         
                                }
                                else
                                {
                                    this.currX = ((this.Left - ParentForm.AutoScrollPosition.X) + l);
                                    this.currY = ((this.Top - ParentForm.AutoScrollPosition.Y) + t);

                                    if (this.currX < 1)
                                        this.currX = 1;
                                    if (this.currY < 1)
                                        this.currY = 1;
                                    if (this.currX > 1900)
                                        this.currX = 1900;
                                    if (this.currY > 1060)
                                        this.currY = 1060;

                                    Color terrainType = round.terrain.GetPixel(this.currX, this.currY);

                                    if (terrainType.R > 200 && terrainType.B < 150 && this.onTrain)
                                    {
                                        this.terrainName += "Railroad,";

                                        if (terrainType.G < 200) //Major RR
                                            this.currentMove = this.currentMove + 1 / 100;
                                        else if (terrainType.G > 199) //Minor RR
                                            this.currentMove = this.currentMove + 1 / 50;
                                    }
                                }

                                //?? Why is this done again??
                                this.currX = this.Left + l;
                                this.currY = this.Top + t;

                                if (this.currX < 1)
                                    this.currX = 1;
                                if (this.currY < 1)
                                    this.currY = 1;
                                if (this.currX > 1900)
                                    this.currX = 1900;
                                if (this.currY > 1060)
                                    this.currY = 1060;

                                if (!this.onTrain)
                                      this.supply = Math.Round(this.supply - (this.currentMove/500) * (this.strength / ran.Next(90, 101)));

                                if (this.delayedMove > 1)
                                {
                                    if (Parent.GetChildAtPoint(new Point(this.currX, this.currY)) != null)
                                    {
                                        if (Parent.GetChildAtPoint(new Point(this.currX, this.currY)) != this)
                                        {
                                            if (Parent.GetChildAtPoint(new Point(this.currX, this.currY)).GetType().ToString() == "Barbarossa.Unit")
                                            {
                                                Unit otherUnit = Parent.GetChildAtPoint(new Point(this.currX, this.currY)) as Unit;

                                                if (otherUnit.side != this.side && !this.retreated && !this.onTrain)
                                                {
                                                    this.didMove = true;
                                                    endMove();
                                                    otherUnit.engagedUnits.Add(this);

                                                    if (!this.coordinatingAttack)
                                                    {
                                                        delayedAttack = (ran.Next(0, 3) - (this.unitQuality * -1));

                                                        if (this.surprise)
                                                            delayedAttack++;

                                                        if (delayedAttack < 2)
                                                        {
                                                            Parent.GetType().GetMethod("setEngaged").Invoke(Parent, new object[] { otherUnit });
                                                            this.currentUnitGround = round.currentGround[z];
                                                            this.currentUnitWeather = round.currentWeather[z];
                                                        }
                                                        else
                                                        {
                                                            doCombat(otherUnit);
                                                            this.plannedMove.Clear();

                                                            if (this.plannedMove.Count > 0)
                                                                Parent.GetType().GetMethod("removeMover").Invoke(Parent, new object[] { this });

                                                            this.currentUnitGround = null;
                                                            this.currentUnitWeather = null;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        otherUnit.engagedUnits.Add(this);
                                                    }

                                                    break;
                                                }
                                                else if (this.supplies && !this.onTrain && !otherUnit.onTrain && !otherUnit.didMove)
                                                {
                                                    this.source.supply = this.source.supply - this.supply;                                                    

                                                    if (otherUnit.supply > 100)
                                                        otherUnit.supply = 100;

                                                    if (this.side == otherUnit.side)
                                                        otherUnit.supply = Math.Round(otherUnit.supply) + this.supply;  
                                                    else if (this.side != otherUnit.side)
                                                        otherUnit.supply = Math.Round(otherUnit.supply) + new Random().Next(0, Convert.ToInt32(this.supply));
                                                        
                                                    this.didMove = true;
                                                    break;
                                                }
                                            }

                                            if (Parent.GetChildAtPoint(new Point(this.currX, this.currY)).GetType().ToString() == "Barbarossa.City")
                                            {
                                                City currentCity = Parent.GetChildAtPoint(new Point(this.currX, this.currY)) as City;

                                                if (this.onTrain && currentCity.side != this.side && currentMove > 60)
                                                {
                                                    this.didMove = true;
                                                    endMove();
                                                    break;
                                                }

                                                //There is already a penalty for hit a town; this removes that and uses the City penalty
                                                this.currentMove = this.currentMove - ((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][8][0])) / (unitSquare*unitSquare));
                                                this.currentMove = this.currentMove + ((Convert.ToDouble(Data.unitTypes[this.type][1][0]) / Convert.ToDouble(Data.unitTypes[this.type][11][0])) / (unitSquare*unitSquare));
                                                this.terrainName += "City,";
                                                this.terrainName = this.terrainName.Replace("Town,", "");
                                            }

                                            if (Parent.GetChildAtPoint(new Point(this.currX, this.currY)).GetType().ToString() == "Barbarossa.Track")
                                            {
                                                if (this.side == 0)
                                                {
                                                    this.checkTrain = true;
                                                }
                                                else if (this.side == 1 && this.onTrain)
                                                {
                                                    this.didMove = true;
                                                    endMove();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (this.onTrain)
                            {
                                if (this.terrainName.IndexOf("Railroad") == -1)
                                {
                                    this.Left = this.prevX;
                                    this.Top = this.prevY;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Unit_MouseUp(object sender, MouseEventArgs e)
        {
            //DELEEUW: Required Move?
            if (this.doMove && this.side == round.turn[2])
            {
                endMove();
            }
        }

        public void endMove()
        {
            for (int t = 3; t < 12; t++)
            {
                for (int l = 3; l < 12; l++)
                {
                    //this.currX = this.Left + l;
                    this.currY = this.Top + t;
                    this.currX = ((this.Left - ParentForm.AutoScrollPosition.X) + l) + 20;
                    //this.currY = ((this.Top - ParentForm.AutoScrollPosition.Y) + t) + 40;
                    this.currY = ((this.Top - ParentForm.AutoScrollPosition.Y) + t) + 20;

                    if (this.currX < 1)
                        this.currX = 1;

                    if (this.currY < 1)
                        this.currY = 1;

                    if (this.currX > 1900)
                        this.currX = 1900;

                    if (this.currY > 1060)
                        this.currY = 1060;

                    Color terrainType = round.terrain.GetPixel(this.currX, this.currY);

                    //RR
                    if (terrainType.R > 200 && terrainType.B < 150)
                        this.terrainName += "Railroad,";

                    //River; Possibly Clear terrain during winter
                    if (terrainType.R < 150 && terrainType.G < 150 && terrainType.B > 200 && ((round.currentGround[z] == "Snow" && new Random().Next(0, 3) < 2) || (round.currentGround[z] != "Snow")))
                        this.terrainName += "River,";

                    //Towns/Cities
                    if (terrainType.R < 150 && terrainType.G > 200 && terrainType.B > 200)
                        this.terrainName += "Town,";

                    //Swamps; Probably Clear terrain during winter
                    if (terrainType.R > 200 && terrainType.G < 150 && terrainType.B > 200 && ((round.currentGround[z] == "Snow" && new Random().Next(0, 2) == 1) || (round.currentGround[z] != "Snow")))
                        this.terrainName += "Swamp,";

                    //Woods
                    if (terrainType.R < 150 && terrainType.G > 200 && terrainType.B < 150)
                        this.terrainName += "Woods,";

                    //Mountains
                    if (terrainType.R > 200 && terrainType.G > 200 && terrainType.B > 200)
                        this.terrainName += "Mountains,";
                }
            }

            if (this.delayedMove > 1)
            {
                if (this.currentMove > 50 && this.type == 3)
                    this.didAirdrop = true;

                this.supply = this.supply * Math.Round((Convert.ToDouble(ran.Next(90, 111)) / 100));

                //Russian Winter
                if (round.currentGround[z] == "Snow" && this.side == 0 && (round.currentCalendar[0] == 0 || round.currentCalendar[0] == 1))
                    this.supply = Math.Round((this.supply * ran.Next(6, 11))) / 10;

                if (this.supply < 1)
                    this.supply = 1;

                //Random move by another unit

                for (int c = 0; c < Parent.Controls.Count; c++)
                {
                    if (Parent.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                    {
                        if (new Random().Next(0, 10) == 0)
                        {
                            Unit deployingUnit = Parent.Controls[c] as Unit;

                            if (deployingUnit.Left - ParentForm.AutoScrollPosition.X > 100 && deployingUnit.Left - ParentForm.AutoScrollPosition.X < 1920 && deployingUnit.Top - ParentForm.AutoScrollPosition.Y > 100 && deployingUnit.Top - ParentForm.AutoScrollPosition.Y < 1000 && deployingUnit.delayedAttack > 1 && deployingUnit.delayedMove > 1 && this != deployingUnit)
                            {
                                int ranMove = ran.Next(-50, 50);
                                int ranX = deployingUnit.Left + ranMove;
                                int ranY = deployingUnit.Top + ranMove;
                                Color terrainType = round.terrain.GetPixel(ranX - ParentForm.AutoScrollPosition.X, ranY - ParentForm.AutoScrollPosition.Y);

                                if (terrainType.R > 20 || terrainType.G > 20 || terrainType.B > 20)
                                {
                                    deployingUnit.Left = ranX;
                                    deployingUnit.Top = ranY;
                                }

                                break;
                            }
                        }
                    }
                }

                if (this.onTrain && this.terrainName.IndexOf("Railroad") == -1)
                {
                    this.Left = this.prevX;
                    this.Top = this.prevY;
                }

                currentDistance = Math.Sqrt(((startX - this.Left) * (startX - this.Left)) + ((startY - this.Top) * (startY - this.Top)));

                //DELEEUW; go further along path (not "get lost" by deviating)
                if (currentDistance > 25 && this.Left - ParentForm.AutoScrollPosition.X > 150 && this.Left - ParentForm.AutoScrollPosition.X < 1800 && this.Top - ParentForm.AutoScrollPosition.Y > 150 && this.Top - ParentForm.AutoScrollPosition.Y < 900 && this.delayedAttack > 1)
                {
                    int ranMove = ran.Next(0, 100);
                    int ranX = this.Left + (this.dx * ((ranMove * Convert.ToInt32(currentMove / currentDistance)) * Convert.ToInt32((100 / this.supply) * 10)));
                    int ranY = this.Top + (this.dy * ((ranMove * Convert.ToInt32(currentMove / currentDistance)) * Convert.ToInt32((100 / this.supply) * 10)));

                    if (ranX > 1900)
                        ranX = 1900;

                    if (ranY > 1000)
                        ranY = 1000;

                    if (ranX < 0)
                        ranX = 0;

                    if (ranY < 0)
                        ranY = 0;
                    
                    Color terrainType = round.terrain.GetPixel(ranX - ParentForm.AutoScrollPosition.X, ranY - ParentForm.AutoScrollPosition.Y);

                    //Check if off map
                    if (terrainType.R > 20 || terrainType.G > 20 || terrainType.B > 20)
                    {
                        this.Top = ranY;
                        this.Left = ranX;
                    }
                }
                
                if (this.Left < 15)
                    this.Left = 15;
                if (this.Top < 15)
                    this.Top = 15;
                if (this.Left > 1920)
                    this.Left = 1920;
                if (this.Top > 1080)
                    this.Top = 1080;
                this.currX = this.Left;
                this.currY = this.Top;

                if (!this.didCombat)
                {
                    if (round.currentWeather[z] == "Snowing" && this.currentTerrain == "Woods")
                        this.detection = Math.Round(this.detection + (Convert.ToDouble(new Random().Next(0, 10) / 100)));

                    if (this.surprise)
                        this.detection = Math.Round(this.detection - (Convert.ToDouble(new Random().Next(0, 20) / 100)));

                    if (this.detection < 1)
                        this.detection = 1;

                    if (this.intel < 1)
                        this.intel = 1;
                }

                this.SendToBack();

                if (Parent.GetChildAtPoint(new Point(this.Left, this.Top)) != null)
                {
                    if (Parent.GetChildAtPoint(new Point(this.Left, this.Top)).GetType().ToString() == "Barbarossa.City" && !this.onTrain)
                    {
                        City captured = Parent.GetChildAtPoint(new Point(this.Left, this.Top)) as City;
                        this.inCity = true;
                        this.terrainName += "City,";
                        this.terrainName = this.terrainName.Replace("Town,", "");

                        if ((this.side == 0 && this.supply > 50 && this.strength > 50) || (this.side == 0 && (this.supply < 50 || this.strength < 50) && (this.supply > new Random().Next(0, 50) || this.strength < new Random().Next(0, 50))) || this.side == 1)
                            captured.side = this.side;

                        if (this.source!=null)
                            this.source.supply = this.source.supply - this.supply;

                        if (this.supplies)
                        {
                            if (this.side == captured.side)
                                captured.supply = captured.supply + this.supply;
                            else if (this.side != captured.side)
                                captured.supply = captured.supply + new Random().Next(0, Convert.ToInt32(this.supply));
                        }
                    }

                    if (Parent.GetChildAtPoint(new Point(this.Left, this.Top)).GetType().ToString() == "Barbarossa.Track" && this.side == 1 && !this.onTrain && this.type != 1)
                    {
                        Track demolished = Parent.GetChildAtPoint(new Point(this.Left, this.Top)) as Track;
                        demolished.Dispose();
                    }
                }

                if (this.terrainName != null)
                {
                    this.currentTerrain = this.terrainName;

                    if (this.currentTerrain.IndexOf("Railroad") > -1)
                        this.onRail = true;

                    if (this.side == 0 && this.onRail && this.type != 30)
                    {
                        int railFactor = ran.Next(0, 6);

                        if (Convert.ToInt32(railFactor - this.trackProgress) > Convert.ToInt32((this.strength / 100) * (this.supply / 100)))
                        {
                            this.trackProgress++;
                        }
                        else
                        {
                            Track newTrack = new Track();
                            newTrack.Left = this.Left;
                            newTrack.Top = this.Top;
                            newTrack.Width = newTrack.Height = 6;
                            newTrack.BackColor = System.Drawing.Color.FromArgb(10, 255, 0, 0);
                            Parent.Controls.Add(newTrack);
                            newTrack.Visible = true;
                            newTrack.Focus();
                            newTrack.SendToBack();
                            this.trackProgress = 0;
                        }
                    }

                    this.currentTerrain = this.currentTerrain.Replace("Railroad,", "");
                    string[] currentTerrains = this.currentTerrain.Split(new char[] { ',' });

                    if (currentTerrains.Length > 1)
                        this.currentTerrain = currentTerrains[ran.Next(currentTerrains.Length - 1)];
                    else
                        this.currentTerrain = "Clear";
                }
                else
                {
                    this.currentTerrain = "Clear";
                }

                if (!this.didDelayedMove)
                {
                    this.currentTurn = round.turn[1];
                    round.turn[2] = this.side;
                    this.doMove = false;
                    this.didMove = true;
                }

                if (this.surprise)
                    this.surprise = false;

                this.plannedMove.Clear();
                this.BringToFront();

                if (this.supplies)
                {
                    Parent.Controls.Remove(this);
                }

            }
            else if (this.delayedMove < 2)
            {
                this.doMove = false;
                this.didMove = true;
                this.Left = this.startX;
                this.Top = this.startY;
            }

            if (!this.onTrain)
                this.BackColor = System.Drawing.Color.Black;
            else
                this.BackColor = System.Drawing.Color.Red;
        }

        public void doCombat(Unit defender)
        {
            double attack = 0;
            double attackDetection = 1;
            int attackerRetreated = 0;
            string currentWeather = round.currentWeather[z];
            string currentGround = round.currentGround[z];

            if (this.currentUnitGround != null )
                currentGround = this.currentUnitGround;
              
            if ( this.currentUnitWeather == "")
                currentWeather = this.currentUnitWeather;
            
            foreach (Unit attacker in defender.engagedUnits)
            {
                attack += (Convert.ToInt32(Data.unitTypes[attacker.type][Data.conditions.IndexOf(currentWeather) + 1][1]) + Convert.ToInt32(Data.unitTypes[attacker.type][Data.conditions.IndexOf(currentGround) + 1][1]) + Convert.ToInt32(Data.unitTypes[attacker.type][Data.conditions.IndexOf(defender.currentTerrain)][1])) / 3;
                attack = attack * (Convert.ToDouble(attacker.supply) / 100) * (Convert.ToDouble(attacker.strength) / 100);
                attack = attack + ((ran.Next(0, 10) * defender.detection) + (ran.Next(-1, 10) * attacker.intel));
                attackDetection += attacker.detection;

                if (attacker.retreated)
                    attackerRetreated++;
            }

            double defense = (Convert.ToInt32(Data.unitTypes[defender.type][Data.conditions.IndexOf(currentWeather) + 1][2]) + Convert.ToInt32(Data.unitTypes[defender.type][Data.conditions.IndexOf(currentGround) + 1][1]) + Convert.ToInt32(Data.unitTypes[defender.type][Data.conditions.IndexOf(defender.currentTerrain)][2])) / 3;

            defense = defense + ((new Random().Next(0, 10) * (attackDetection / defender.engagedUnits.Count)) + (new Random().Next(-1, 10) * defender.intel));

            if (defender.onTrain)
                defense = 1;

            defense = defense * (Convert.ToDouble(defender.supply) / 100) * (Convert.ToDouble(defender.strength) / 100);
            double combat = (attack / defense) * (ran.Next(100));

            if (defender.retreated)
                combat = combat * ((ran.Next(100, 111) - (this.side * 5)) / 100);

            if (attackerRetreated > 0)
                combat = combat / ((ran.Next((100 - attackerRetreated), 101) - (this.side * 5)) / 100);

            foreach (Unit attacker in defender.engagedUnits)
            {
                if (combat < 20)
                {
                    if (attacker.type > 1)
                    {
                        attacker.eliminated = true;
                        Parent.GetType().GetMethod("setEliminated").Invoke(Parent, new object[] { this });
                    }

                    attacker.Width = attacker.Height = 0;
                    attacker.Top = attacker.Left = 0;
                }
                else if (combat < 30)
                {
                    attacker.Top = attacker.Top - (30 * this.dy);
                    attacker.Left = attacker.Left - (30 * this.dx);
                    attacker.strength = attacker.strength * (Convert.ToDouble(ran.Next(25, 75)) / 100);
                    attacker.retreated = true;
                }
                else if (combat < 40)
                {
                    attacker.strength = attacker.strength * (Convert.ToDouble(ran.Next(25, 75)) / 100);
                }
                else if (combat < 50)
                {
                    attacker.Top = attacker.Top - (30 * this.dy);
                    attacker.Left = attacker.Left - (30 * this.dx);
                    attacker.retreated = true;
                }
                else if (combat < 60 && attacker.type != 30)
                {
                }
                else if (combat < 70)
                {
                    defender.Top = defender.Top + (30 * this.dy);
                    defender.Left = defender.Left + (30 * this.dx);
                    defender.retreated = true;
                }
                else if (combat < 80)
                {
                    ran = new Random();
                    defender.strength = defender.strength * (Convert.ToDouble(ran.Next(25, 75)) / 100);
                }
                else if (combat < 90)
                {
                    defender.Top = defender.Top + (30 * this.dy);
                    defender.Left = defender.Left + (30 * this.dx);
                    defender.retreated = true;
                    ran = new Random();
                    defender.strength = defender.strength * (Convert.ToDouble(ran.Next(25, 75)) / 100);
                }
                else
                {
                    if (defender.type > 1)
                    {
                        defender.eliminated = true;
                        Parent.GetType().GetMethod("setEliminated").Invoke(Parent, new object[] { this });
                    }

                    defender.Width = defender.Height = 0;
                    defender.Top = defender.Left = 0;
                }
            }

            foreach (Unit attacker in defender.engagedUnits)
            {
                attacker.supply = attacker.supply * (Convert.ToDouble(ran.Next(85, 100)) / 100);
                attacker.intel = attacker.intel + .1 * ran.Next(0, 3);

                if (attacker.type != 30 && attacker.type != 0)
                    attacker.detection = attacker.detection + .1;

                if (attacker.type == 30)
                {
                    attacker.Left = attacker.startX;
                    attacker.Top = attacker.startY;
                }
            }

            defender.supply = defender.supply * (Convert.ToDouble(ran.Next(85, 100)) / 100);
            defender.intel = defender.intel + .1 * ran.Next(0, 3);
            defender.detection = defender.detection + .1;
            defender.engagedUnits.Clear();
        }
     
        public void contextMenuStrip1_MouseEnter(object sender, EventArgs e)
        {
            informationDetails.Text = this.Name;
            informationDetails.Text += "\n  Strength: " + this.strength.ToString();
            informationDetails.Text += "\n  Supply: " + this.supply.ToString();
            informationDetails.Text += "\n  Intel: " + this.intel.ToString();
            informationDetails.Text += "\n  Detection: " + this.detection.ToString();
            informationDetails.Text += "\n  Movement: " + ((Convert.ToInt32(Data.unitTypes[this.type][Data.conditions.IndexOf(round.currentWeather[z]) + 1][0]) + Convert.ToInt32(Data.unitTypes[this.type][Data.conditions.IndexOf(this.currentTerrain)][0])) / 2).ToString();
            informationDetails.Text += "\n  Attack: " + ((Convert.ToInt32(Data.unitTypes[this.type][Data.conditions.IndexOf(round.currentWeather[z]) + 1][1]) + Convert.ToInt32(Data.unitTypes[this.type][Data.conditions.IndexOf(this.currentTerrain)][1])) / 2).ToString();
            informationDetails.Text += "\n  Defense: " + ((Convert.ToInt32(Data.unitTypes[this.type][Data.conditions.IndexOf(round.currentWeather[z]) + 1][2]) + Convert.ToInt32(Data.unitTypes[this.type][Data.conditions.IndexOf(this.currentTerrain)][2])) / 2).ToString();

                if (this.onTrain)
                    informationDetails.Text += " On Train" + " \n" + round.currentWeather[z];
                else
                    informationDetails.Text += "\nTerrain: "+this.currentTerrain + "\nWeather: " + round.currentWeather[z] + "\nGround: " + round.currentGround[z];
    
            Information.ShowDropDown();
        }

        public void Coordinate_Click(object sender, EventArgs e)
        {
            if ((new Random().Next(3) - this.unitQuality) < 2 && !this.doMove && !this.didMove)
                this.coordinatingAttack = true;
        }

        public void Train_Click(object sender, EventArgs e)
        {
            if (!this.onTrain)
            {
                this.onTrain = true;
                this.BackColor = System.Drawing.Color.Pink;
            }
            else if (this.onTrain)
            {
                this.onTrain = false;
                this.didMove = true;
                endMove();
            }
        }

        int theWidth = 1920;
        int theHeight = 1080;

        public void doZoomIn(object sender, EventArgs e)
        {
            float _scaleX = ((float)2);
            float _scaleY = ((float)2);
            SizeF _sizeF = new SizeF(_scaleX, _scaleY);
            theWidth = theWidth * (int)_scaleX;
            theHeight = theHeight * (int)_scaleY;
            Parent.Scale(_sizeF);
        }

        public void doZoomOut(object sender, EventArgs e)
        {

        }
    }

    public class Track : UserControl
    {
        public Track()
        {
            this.Width = 6;
            this.Height = 6;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Barbarossa
{
    public partial class Reinforcements : Form
    {
        public bool doMove = false;

        public Reinforcements()
        {
            InitializeComponent();
            int U = 239;
            int MM = 0;

            //TEST
           // round.currentCalendar[0] = 2;
            //round.currentCalendar[1] = 3;
           // U += 39;
                                           
            int Y= round.currentCalendar[0] ;
           //int M=1;
           int M = round.currentCalendar[1];
                        
            //int MM= 13;
            //MM = 6;

            //MessageBox.Show(round.currentCalendar[1].ToString());
             //unitList1.Text = "\n\t" + Data.calendar[round.currentCalendar[0]][0][0].ToString() + "\r\n";
            
            /*
            if (Data.calendar[round.currentCalendar[0]][0][0].ToString() == "1941"){
                M=7;
                this.Width = this.Width - unitList2.Width;
                unitList2.Visible = false;                
            }

            if (Data.calendar[round.currentCalendar[0]][0][0].ToString() == "1945")
            {
               MM = 6;
               this.Width = this.Width - unitList1.Width;
               unitList1.Visible = false;
            }
            */

            //MessageBox.Show(round.turn[2].ToString());
            for (int m = M+1; m <M+2; m++)
                {
                    RichTextBox unitList=new RichTextBox();
                    unitList = unitList1;
                    MM = m;

                if (m>12){
                   MM = 1;
                    Y += 1;
                }
               
                /*
                    if (m > 5 && round.currentCalendar[0] > 0)
                    {
                        unitList = unitList2;
                        unitList.Text += "\n\r\n";
                    }
                */
       
                    unitList.Text += "\r\n\t"+Data.calendar[Y][MM][0] +" "+Data.calendar[Y][0][0].ToString()+ "\r\n";
                    bool hasReinforcements = false;
                    
                    for (int u = 0; u < Convert.ToInt32(Data.calendar[Y][MM][2]); u++)
                    {
                        U++;
                        if ( Convert.ToInt32(Data.units[U][1]) < 12)
                        {
                        //Should a side know the other side's reinforcements??
                        if (round.turn[2] == 1)
                        {
                            unitList.Text += "\t\t" + Data.units[U][0].ToString() + "\r\n";
                        }
                        if (round.turn[2] == 0 && Math.Round(Convert.ToDouble(new Random().Next(0,3)))==0)
                        {
                            unitList.Text += "\t\t" + Data.units[U][0].ToString() + "\r\n";
                        }


                        hasReinforcements = true;
                        }
                    //MessageBox.Show(Data.calendar[Y][m][0].ToString());
                    if ( Convert.ToInt32(Data.units[U][1]) > 11) 
                    {
                        //Should a side know the other side's reinforcements??

                        if (round.turn[2] == 0)
                        {
                            unitList.Text += "\t\t" + Data.units[U][0].ToString() + "\r\n";
                        }
                        if (round.turn[2] == 1 && Math.Round(Convert.ToDouble(new Random().Next(0, 3))) != 0)
                        {
                            unitList.Text += "\t\t" + Data.units[U][0].ToString() + "\r\n";
                        }
                        hasReinforcements = true;
                    }
                    //MessageBox.Show(Data.calendar[Y][m][0].ToString());


                }



                //MessageBox.Show(m.ToString());

                if (hasReinforcements == false)
                        unitList.Text += "\t\t(none)";
                
                    //MessageBox.Show(Data.calendar[round.currentCalendar[0]][m][0].ToString()+" "+Data.calendar[round.currentCalendar[0]][m][2].ToString());
                }
        }

        private void unitList1_MouseDown(object sender, MouseEventArgs e)
        {
            doMove = true;
        }

        private void unitList1_MouseMove(object sender, MouseEventArgs e)
        {
            if (doMove == true)
            {
                this.Left = MousePosition.X;
                this.Top = MousePosition.Y;
            }
        }

        private void unitList1_MouseUp(object sender, MouseEventArgs e)
        {
            doMove = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Barbarossa
{
    public partial class City : UserControl
    {
        public double supply;
        public double cityDupply;
        public double depotySupply=1;
        public bool allowMove = false;
        public bool doMove=false;
        public bool doDelete = false;
        public bool doSupply = false;
        public bool showCity = false;
        public int thisX, thisY;
        public int number;
        public int type;
        public int originalSide;
        public int side;
        public int name;
        public int points;
        public int defense;
        public int replacements;
        
        public City()
        {
            InitializeComponent();
        }

        private void City_MouseDown(object sender, MouseEventArgs e)
        {
            //if(doSupply)
                //doMove = true;
            //else
            this.SendToBack();

        }

        private void City_MouseMove(object sender, MouseEventArgs e)
        {            
            if (doMove)
            {
                this.Left = MousePosition.X;
                this.Top = MousePosition.Y;
            }
        }

        private void City_MouseUp(object sender, MouseEventArgs e)
        {          
            thisX = this.Left - ParentForm.AutoScrollPosition.X;
            thisY = this.Top - ParentForm.AutoScrollPosition.Y;
            doMove = false;         
        }  

        private void contextMenuStrip1_MouseEnter(object sender, EventArgs e)
        {
            contextMenuStrip1.Items["informationStripMenuItem"].Text = this.supply.ToString();
            
            if (this.side==0)
               contextMenuStrip1.Items["informationStripMenuItem"].Text+="\nGerman";
            else
                contextMenuStrip1.Items["informationStripMenuItem"].Text += "\nRussian";
        }

        private void supplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doSupply = true;
            
            if ((this.supply > 100 || this.depotySupply > 100) && round.turn[2] ==this.side)
            {
                Unit currSupplies = new Unit();
                /*
                currSupplies.Left = this.Left+40;
                currSupplies.Top = this.Top + 40;
                */
                currSupplies.Left = this.Left;
                currSupplies.Top = this.Top;
                currSupplies.BackColor = System.Drawing.Color.Transparent;
                currSupplies.BackgroundImage = global::Barbarossa.Properties.Resources.Supply;
                currSupplies.Name = "Supply";
                currSupplies.Width =  currSupplies.Height = 15;
                currSupplies.doMove = true;
                currSupplies.type = 32;
                currSupplies.strength = 1;
                currSupplies.side = this.originalSide;
                currSupplies.source = this; 
                currSupplies.supply = new Random().Next(1, 100);
                currSupplies.supply = Math.Round(currSupplies.supply);
                currSupplies.supplies = true;
                //currSupplies.BringToFront();
                ParentForm.Controls.Add(currSupplies);
            }
            else
            {
                MessageBox.Show("City does not have enough supplies");
            }
        }

    }
}

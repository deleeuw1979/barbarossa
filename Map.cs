﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Barbarossa
{
    public partial class Map : UserControl
    {
        public double ratioX;
        public double ratioY;
        public bool doMove = false;
        Unit cursor = new Unit();

        public Map()
        {
            InitializeComponent();
        }

        private void Map_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            ratioX = Convert.ToDouble(960) / Convert.ToDouble(3968);
            ratioY = Convert.ToDouble(540) / Convert.ToDouble(2765);
            Unit cursor = new Unit();
            cursor.Width = cursor.Height = 10;
            cursor.Left =Convert.ToInt32(Convert.ToDouble(round.mapCoords[0]) * ratioX);
            cursor.Top = Convert.ToInt32(Convert.ToDouble(round.mapCoords[1]) * ratioY);
            this.Controls.Add(cursor);

            for (int c = 0; c < ParentForm.Controls.Count; c++)
            {
                if (ParentForm.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                {
                    Unit overviewControl = new Unit();
                    overviewControl.Left = Convert.ToInt32((ParentForm.Controls[c].Left - ParentForm.AutoScrollPosition.X) * ratioX);
                    overviewControl.Top = Convert.ToInt32((ParentForm.Controls[c].Top - ParentForm.AutoScrollPosition.Y) * ratioY);
                    overviewControl.Width = Convert.ToInt32(ParentForm.Controls[c].Width *.5);
                    overviewControl.Height = Convert.ToInt32(ParentForm.Controls[c].Height * .5);
                    Unit currentOverviewControl = (Unit)ParentForm.Controls[c];         
                    overviewControl.BackgroundImage = ParentForm.Controls[c].BackgroundImage;
                    overviewControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    this.Controls.Add(overviewControl);
                }                       
            }
        }

        private void Map_MouseClick(object sender, MouseEventArgs e)
        {
            round.mapCoords[0] = MousePosition.X-this.Left;
            round.mapCoords[1] = MousePosition.Y - this.Top;
            this.Dispose();
        }

        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            doMove = true;
        }

        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            if (doMove)
            {
                this.Left = MousePosition.X;
                this.Top = MousePosition.Y;
            }
        }

        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            doMove = false;
        }
    }
}

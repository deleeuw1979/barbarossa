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
    public partial class Detail : Form
    {
        public Int32 ratioX;
        public Int32 ratioY;
        public bool doMove = false;
        Unit cursor = new Unit();
        private Image backgroundImage;
        public Rectangle rc;
        public double rcTop;
        public double rcLeft;

        public Detail()
        {
            InitializeComponent();
            backgroundImage = global::Barbarossa.Properties.Resources.Russland_Big;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
  
            rc = new Rectangle((0-(Game.MousePosition.X )*2)+150,
                (0-(Game.MousePosition.Y)*2)+150,
                backgroundImage.Width, backgroundImage.Height);
            e.Graphics.DrawImage(backgroundImage, rc);
        }

        private void Detail_Paint(object sender, PaintEventArgs e)
        {
      
        }

        private void Detail_Load(object sender, EventArgs e)
        {

           if (MousePosition.X > 350)
                this.Left = 0;
            else
                this.Left = 1570;

            if (MousePosition.Y > 350)
                this.Top = 0;
            else
                this.Left = 730;                 

            showUnits();          
        }

        private void showUnits()
        {
            for (int c = 0; c < this.Owner.Controls.Count; c++)
            {
                if (this.Owner.Controls[c].GetType().ToString() == "Barbarossa.Unit")
                {
                    Unit overviewControl = new Unit();       
                    overviewControl.Left = Convert.ToInt32((this.Owner.Controls[c].Left * 2) + ((0 - (Game.MousePosition.X) * 2) + 150));
                    overviewControl.Top = Convert.ToInt32((this.Owner.Controls[c].Top * 2) + ((0 - (Game.MousePosition.Y) * 2) + 150));
                    overviewControl.Width = Convert.ToInt32(this.Owner.Controls[c].Width * 2);
                    overviewControl.Height = Convert.ToInt32(this.Owner.Controls[c].Height * 2);
                    overviewControl.BackgroundImage = this.Owner.Controls[c].BackgroundImage;
                    overviewControl.BackColor = this.Owner.Controls[c].BackColor;
                    overviewControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    this.Controls.Add(overviewControl);
                }
            }
        }
        
        private void Detail_MouseDown(object sender, MouseEventArgs e)
        {
            doMove = true;
        }

        private void Detail_MouseMove(object sender, MouseEventArgs e)
        {
            if (doMove)
            {
                this.Left = MousePosition.X-175;
                this.Top = MousePosition.Y-175;
            }
        }

        private void Detail_MouseUp(object sender, MouseEventArgs e)
        {
            doMove = false;
        }
    }
}


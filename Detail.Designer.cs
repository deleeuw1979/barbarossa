namespace Barbarossa
{
    partial class Detail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.ControlBox = false;
            this.Name = "Detail";
            this.Load += new System.EventHandler(this.Detail_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Detail_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Detail_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Detail_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Detail_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
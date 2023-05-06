namespace Barbarossa
{
    partial class City
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.supplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.informationStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(31, 20);
            this.textBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplyToolStripMenuItem,
            this.toolStripSeparator1,
            this.informationStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
                  this.contextMenuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 76);
            this.contextMenuStrip1.MouseEnter += new System.EventHandler(this.contextMenuStrip1_MouseEnter);
            // 
            // supplyToolStripMenuItem
            // 
            this.supplyToolStripMenuItem.Name = "supplyToolStripMenuItem";
            this.supplyToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.supplyToolStripMenuItem.Text = "Supply";
            this.supplyToolStripMenuItem.Click += new System.EventHandler(this.supplyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // informationStripMenuItem
            // 
            this.informationStripMenuItem.Name = "informationStripMenuItem";
            this.informationStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.informationStripMenuItem.Text = "toolStripMenuItem1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(4, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // City
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "City";
            this.Size = new System.Drawing.Size(55, 55);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.City_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.City_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.City_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem supplyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem informationStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
        }
}

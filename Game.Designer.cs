namespace Barbarossa
{
    partial class Game
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Active = new System.Windows.Forms.ToolStripMenuItem();
            this.Conditions = new System.Windows.Forms.ToolStripMenuItem();
            this.conditionsDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.GermanControlled = new System.Windows.Forms.ToolStripMenuItem();
            this.showAll = new System.Windows.Forms.ToolStripMenuItem();
            this.nextMonthReinforcement = new System.Windows.Forms.ToolStripMenuItem();
            this.politicalStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.politicalStatusDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.Rules = new System.Windows.Forms.ToolStripMenuItem();
            this.Spacer = new System.Windows.Forms.ToolStripMenuItem();
            this.Overview = new System.Windows.Forms.ToolStripMenuItem();
            this.debug = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Map = new System.Windows.Forms.Panel();
            this.gameBoard = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1024, 768);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Active,
            this.Conditions,
            this.GermanControlled,
            this.nextMonthReinforcement,
            this.politicalStatus,
            this.Rules});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(520, 284);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // Active
            // 
            this.Active.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Active.Name = "Active";
            this.Active.Size = new System.Drawing.Size(519, 40);
            this.Active.Text = "Active";
            this.Active.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Active.Click += new System.EventHandler(this.Active_Click);
            // 
            // Conditions
            // 
            this.Conditions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conditionsDetails});
            this.Conditions.Name = "Conditions";
            this.Conditions.Size = new System.Drawing.Size(519, 40);
            this.Conditions.Text = "Weather/Turn";
            this.Conditions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
           
            // 
            // conditionsDetails
            // 
            this.conditionsDetails.Name = "conditionsDetails";
            this.conditionsDetails.Size = new System.Drawing.Size(259, 42);
            this.conditionsDetails.Text = "Conditions";
            // 
            // GermanControlled
            // 
            this.GermanControlled.Name = "GermanControlled";
            this.GermanControlled.Size = new System.Drawing.Size(519, 40);
            this.GermanControlled.Text = "German-controlled Cities/Railroads";
            this.GermanControlled.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.GermanControlled.Click += new System.EventHandler(this.GermanControlled_Click);
            // 
            // nextMonthReinforcement
            // 
            this.nextMonthReinforcement.Name = "nextMonthReinforcement";
            this.nextMonthReinforcement.Size = new System.Drawing.Size(519, 40);
            this.nextMonthReinforcement.Text = "Next month\'s reinforcements (estimated) ";
            this.nextMonthReinforcement.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.nextMonthReinforcement.Click += new System.EventHandler(this.nextMonthReinforcement_Click);
            // 
            // politicalStatus
            // 
            this.politicalStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.politicalStatusDetails});
            this.politicalStatus.Name = "politicalStatus";
            this.politicalStatus.Size = new System.Drawing.Size(519, 40);
            this.politicalStatus.Text = "Political Status ";
            this.politicalStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.politicalStatus.Click += new System.EventHandler(this.politicalStatus_Click);
            this.politicalStatus.MouseEnter += new System.EventHandler(this.politicalStatus_MouseEnter);
            // 
            // politicalStatusDetails
            // 
            this.politicalStatusDetails.Name = "politicalStatusDetails";
            this.politicalStatusDetails.Size = new System.Drawing.Size(120, 40);
            // 
            // Rules
            // 
            this.Rules.Name = "Rules";
            this.Rules.Size = new System.Drawing.Size(519, 40);
            this.Rules.Text = "Rules";
            this.Rules.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Rules.Click += new System.EventHandler(this.Rules_Click);
            // 
            // Spacer
            // 
            this.Spacer.Name = "Spacer";
            this.Spacer.Size = new System.Drawing.Size(248, 22);
            // 
            // Overview
            // 
            this.Overview.Name = "Overview";
            this.Overview.Size = new System.Drawing.Size(32, 19);
            // 
            // debug
            // 
            this.debug.Location = new System.Drawing.Point(0, 0);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(100, 29);
            this.debug.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeButton.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.Blue;
            this.closeButton.Location = new System.Drawing.Point(1800, 1060);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(54, 27);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // Map
            // 
            this.Map.BackColor = System.Drawing.Color.Transparent;
            this.Map.BackgroundImage = global::Barbarossa.Properties.Resources.Russland_Light;
            this.Map.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.Margin = new System.Windows.Forms.Padding(0);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(1920, 1080);
            this.Map.TabIndex = 1;
            // 
            // gameBoard
            // 
            this.gameBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gameBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameBoard.Image = global::Barbarossa.Properties.Resources.Russland_Light2;
            this.gameBoard.Location = new System.Drawing.Point(0, 0);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(1808, 638);
            this.gameBoard.TabIndex = 2;
            this.gameBoard.TabStop = false;
            // 
            // Game
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1131, 668);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.closeButton);
            this.DoubleBuffered = true;
            this.Icon = global::Barbarossa.Properties.Resources.german1;
            this.KeyPreview = true;
            this.Name = "Game";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_MouseClick);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Game_Scroll);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
            this.ResumeLayout(false);

        }

        private void Game_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void VBar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Rules;
        private System.Windows.Forms.ToolStripMenuItem Conditions;
        private System.Windows.Forms.ToolStripMenuItem conditionsDetails;
        private System.Windows.Forms.ToolStripMenuItem GermanControlled;
        private System.Windows.Forms.ToolStripMenuItem nextMonthReinforcement;        
        private System.Windows.Forms.ToolStripMenuItem politicalStatus;
        private System.Windows.Forms.ToolStripMenuItem politicalStatusDetails;
        private System.Windows.Forms.ToolStripMenuItem showAll;
        private System.Windows.Forms.ToolStripMenuItem Active;
        private System.Windows.Forms.ToolStripMenuItem Overview;
        private System.Windows.Forms.TextBox debug;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Spacer;
       private System.Windows.Forms.Panel Map;
        private System.Windows.Forms.PictureBox gameBoard;
    }
}


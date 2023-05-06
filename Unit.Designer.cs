namespace Barbarossa
{
    partial class Unit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
      
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Coordinate = new System.Windows.Forms.ToolStripMenuItem();
            this.Train = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Information = new System.Windows.Forms.ToolStripMenuItem();
            this.informationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Conditions = new System.Windows.Forms.ToolStripMenuItem();
            this.conditionsDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Coordinate,
            this.Train,
            //this.toolStripSeparator1,
            this.Information,
            //this.toolStripSeparator3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 126);
            this.contextMenuStrip1.MouseEnter += new System.EventHandler(this.contextMenuStrip1_MouseEnter);
            // 
            // Coordinate
            // 
            this.Coordinate.Name = "Coordinate";
            this.Coordinate.Size = new System.Drawing.Size(168, 22);
            this.Coordinate.Text = "Coordinate";
            this.Coordinate.Click += new System.EventHandler(this.Coordinate_Click);
            // 
            // Train
            // 
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(168, 22);
            this.Train.Text = "En/De-train";
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // Information
            // 
            this.Information.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationDetails});
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(168, 22);
            this.Information.Text = "Information";
            // 
            // informationDetails
            // 
            this.informationDetails.Name = "informationDetails";
            this.informationDetails.Size = new System.Drawing.Size(130, 22);
            this.informationDetails.Text = "Information";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // Conditions
            // 
            this.Conditions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conditionsDetails});
            this.Conditions.Name = "Conditions";
            this.Conditions.Size = new System.Drawing.Size(130, 22);
            this.Conditions.Text = "Conditions";
            // 
            // conditionsDetails
            // 
            this.conditionsDetails.Name = "conditionsDetails";
            this.conditionsDetails.Size = new System.Drawing.Size(124, 22);
            this.conditionsDetails.Text = "Conditions";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "Zoom In";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem1.Text = "Zoom In";
            this.toolStripMenuItem1.Click+=new System.EventHandler(doZoomIn);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "Zoom Out";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem2.Text = "Zoom Out";
            this.toolStripMenuItem1.Click += new System.EventHandler(doZoomOut);
            // 
            // Unit
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Unit";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(19, 19);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Unit_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Unit_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Unit_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Unit_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Coordinate;
        private System.Windows.Forms.ToolStripMenuItem Train;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Information;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Conditions;
        private System.Windows.Forms.ToolStripMenuItem informationDetails;
        private System.Windows.Forms.ToolStripMenuItem conditionsDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

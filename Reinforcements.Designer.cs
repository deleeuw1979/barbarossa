namespace Barbarossa
{
    partial class Reinforcements
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
            this.unitList1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // unitList1
            // 
            this.unitList1.BackColor = System.Drawing.Color.Cornsilk;
            this.unitList1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unitList1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitList1.Location = new System.Drawing.Point(1, -2);
            this.unitList1.Margin = new System.Windows.Forms.Padding(0);
            this.unitList1.Name = "unitList1";
            this.unitList1.Size = new System.Drawing.Size(341, 301);
            this.unitList1.TabIndex = 0;
            this.unitList1.Text = "";
            this.unitList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.unitList1_MouseDown);
            this.unitList1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.unitList1_MouseMove);
            this.unitList1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.unitList1_MouseUp);
            // 
            // Reinforcements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 301);
            this.ControlBox = false;
            this.Controls.Add(this.unitList1);
            this.MaximizeBox = false;
            this.Name = "Reinforcements";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox unitList1;
    }
}
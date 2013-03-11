namespace CustomVote.AddIn.PowerPoint2010.Hardware
{
    partial class RetrieveVotesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCronometer = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnVotesSave = new System.Windows.Forms.ToolStripButton();
            this.btnVotesPreview = new System.Windows.Forms.ToolStripButton();
            this.btbVotesStop = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCronometer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblCronometer
            // 
            this.lblCronometer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCronometer.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCronometer.Location = new System.Drawing.Point(3, 16);
            this.lblCronometer.Name = "lblCronometer";
            this.lblCronometer.Size = new System.Drawing.Size(208, 45);
            this.lblCronometer.TabIndex = 0;
            this.lblCronometer.Text = "00:00:00:0";
            this.lblCronometer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVotesSave,
            this.btnVotesPreview,
            this.btbVotesStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 67);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(214, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnVotesSave
            // 
            this.btnVotesSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnVotesSave.Enabled = false;
            this.btnVotesSave.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.disk_black;
            this.btnVotesSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVotesSave.Name = "btnVotesSave";
            this.btnVotesSave.Size = new System.Drawing.Size(51, 22);
            this.btnVotesSave.Text = "Save";
            this.btnVotesSave.Click += new System.EventHandler(this.btnVotesSave_Click);
            // 
            // btnVotesPreview
            // 
            this.btnVotesPreview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnVotesPreview.Enabled = false;
            this.btnVotesPreview.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.magnifier_zoom_actual_equal;
            this.btnVotesPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVotesPreview.Name = "btnVotesPreview";
            this.btnVotesPreview.Size = new System.Drawing.Size(68, 22);
            this.btnVotesPreview.Text = "Preview";
            this.btnVotesPreview.Click += new System.EventHandler(this.btnVotesPreview_Click);
            // 
            // btbVotesStop
            // 
            this.btbVotesStop.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btbVotesStop.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.control_stop_square;
            this.btbVotesStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btbVotesStop.Name = "btbVotesStop";
            this.btbVotesStop.Size = new System.Drawing.Size(54, 22);
            this.btbVotesStop.Text = "Parar";
            this.btbVotesStop.Click += new System.EventHandler(this.btbVotesStop_Click);
            // 
            // RetrieveVotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 92);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(-210, -125);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RetrieveVotesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Votos";
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btbVotesStop;
        private System.Windows.Forms.ToolStripButton btnVotesPreview;
        private System.Windows.Forms.ToolStripButton btnVotesSave;
        private System.Windows.Forms.Label lblCronometer;
    }
}
namespace CustomVote.AddIn.PowerPoint2010.Questions
{
    partial class AnswerView
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAnswClose = new System.Windows.Forms.ToolStripButton();
            this.btnAnswSave = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numAnswerPoints = new System.Windows.Forms.NumericUpDown();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnswerPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAnswClose,
            this.btnAnswSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 80);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(379, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAnswClose
            // 
            this.btnAnswClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAnswClose.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.arrow_curve_000_left;
            this.btnAnswClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnswClose.Name = "btnAnswClose";
            this.btnAnswClose.Size = new System.Drawing.Size(59, 22);
            this.btnAnswClose.Text = "Cerrar";
            this.btnAnswClose.Click += new System.EventHandler(this.btnAnswClose_Click);
            // 
            // btnAnswSave
            // 
            this.btnAnswSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAnswSave.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.disk_black;
            this.btnAnswSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnswSave.Name = "btnAnswSave";
            this.btnAnswSave.Size = new System.Drawing.Size(69, 22);
            this.btnAnswSave.Text = "Guardar";
            this.btnAnswSave.Click += new System.EventHandler(this.btnAnswSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Respuesta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puntos";
            // 
            // numAnswerPoints
            // 
            this.numAnswerPoints.Location = new System.Drawing.Point(84, 37);
            this.numAnswerPoints.Name = "numAnswerPoints";
            this.numAnswerPoints.Size = new System.Drawing.Size(95, 20);
            this.numAnswerPoints.TabIndex = 3;
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(84, 9);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(283, 20);
            this.txtRespuesta.TabIndex = 2;
            // 
            // AnswerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 105);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.numAnswerPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(395, 143);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(395, 143);
            this.Name = "AnswerView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Respuesta";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnswerPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAnswClose;
        private System.Windows.Forms.ToolStripButton btnAnswSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAnswerPoints;
        private System.Windows.Forms.TextBox txtRespuesta;
    }
}
namespace CustomVote.AddIn.PowerPoint2010.Questions
{
    partial class CreateQuestionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateQuestionView));
            this.toolStripPrincipal = new System.Windows.Forms.ToolStrip();
            this.btnQuestionCerrar = new System.Windows.Forms.ToolStripButton();
            this.btnQueationApply = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuestionTitle = new System.Windows.Forms.TextBox();
            this.tabQDef = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewAnswer = new System.Windows.Forms.ToolStripButton();
            this.btnEditAnswer = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteAnswer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.grdQuestions = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Respuesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkVotesCounter = new System.Windows.Forms.CheckBox();
            this.rdbCronoAnimacion = new System.Windows.Forms.RadioButton();
            this.rdbCronoNumerico = new System.Windows.Forms.RadioButton();
            this.chkAcumTimePoints = new System.Windows.Forms.CheckBox();
            this.cboPuntCalc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripPrincipal.SuspendLayout();
            this.tabQDef.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuestions)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripPrincipal
            // 
            this.toolStripPrincipal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuestionCerrar,
            this.btnQueationApply});
            this.toolStripPrincipal.Location = new System.Drawing.Point(0, 347);
            this.toolStripPrincipal.Name = "toolStripPrincipal";
            this.toolStripPrincipal.Size = new System.Drawing.Size(394, 25);
            this.toolStripPrincipal.TabIndex = 0;
            this.toolStripPrincipal.Text = "toolStrip1";
            // 
            // btnQuestionCerrar
            // 
            this.btnQuestionCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnQuestionCerrar.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.arrow_curve_000_left;
            this.btnQuestionCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuestionCerrar.Name = "btnQuestionCerrar";
            this.btnQuestionCerrar.Size = new System.Drawing.Size(59, 22);
            this.btnQuestionCerrar.Text = "Cerrar";
            this.btnQuestionCerrar.Click += new System.EventHandler(this.btnQuestionCerrar_Click);
            // 
            // btnQueationApply
            // 
            this.btnQueationApply.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnQueationApply.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.disk_black;
            this.btnQueationApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQueationApply.Name = "btnQueationApply";
            this.btnQueationApply.Size = new System.Drawing.Size(64, 22);
            this.btnQueationApply.Text = "Aplicar";
            this.btnQueationApply.Click += new System.EventHandler(this.btnQueationApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pregunta";
            // 
            // txtQuestionTitle
            // 
            this.txtQuestionTitle.Location = new System.Drawing.Point(68, 9);
            this.txtQuestionTitle.Name = "txtQuestionTitle";
            this.txtQuestionTitle.Size = new System.Drawing.Size(314, 20);
            this.txtQuestionTitle.TabIndex = 2;
            // 
            // tabQDef
            // 
            this.tabQDef.Controls.Add(this.tabPage1);
            this.tabQDef.Controls.Add(this.tabPage2);
            this.tabQDef.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabQDef.Location = new System.Drawing.Point(0, 35);
            this.tabQDef.Name = "tabQDef";
            this.tabQDef.SelectedIndex = 0;
            this.tabQDef.Size = new System.Drawing.Size(394, 312);
            this.tabQDef.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.grdQuestions);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Respuestas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewAnswer,
            this.btnEditAnswer,
            this.btnDeleteAnswer,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(380, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewAnswer
            // 
            this.btnNewAnswer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewAnswer.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.document_text;
            this.btnNewAnswer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewAnswer.Name = "btnNewAnswer";
            this.btnNewAnswer.Size = new System.Drawing.Size(23, 22);
            this.btnNewAnswer.Text = "&Nuevo";
            this.btnNewAnswer.Click += new System.EventHandler(this.btnNewAnswer_Click);
            // 
            // btnEditAnswer
            // 
            this.btnEditAnswer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditAnswer.Image = ((System.Drawing.Image)(resources.GetObject("btnEditAnswer.Image")));
            this.btnEditAnswer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditAnswer.Name = "btnEditAnswer";
            this.btnEditAnswer.Size = new System.Drawing.Size(23, 22);
            this.btnEditAnswer.Text = "&Editar";
            this.btnEditAnswer.Click += new System.EventHandler(this.btnEditAnswer_Click);
            // 
            // btnDeleteAnswer
            // 
            this.btnDeleteAnswer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteAnswer.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.eraser;
            this.btnDeleteAnswer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteAnswer.Name = "btnDeleteAnswer";
            this.btnDeleteAnswer.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteAnswer.Text = "&Eliminar";
            this.btnDeleteAnswer.Click += new System.EventHandler(this.btnDeleteAnswer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // grdQuestions
            // 
            this.grdQuestions.AllowUserToAddRows = false;
            this.grdQuestions.AllowUserToDeleteRows = false;
            this.grdQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Respuesta,
            this.Puntos});
            this.grdQuestions.Location = new System.Drawing.Point(3, 31);
            this.grdQuestions.MultiSelect = false;
            this.grdQuestions.Name = "grdQuestions";
            this.grdQuestions.ReadOnly = true;
            this.grdQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdQuestions.Size = new System.Drawing.Size(380, 252);
            this.grdQuestions.TabIndex = 0;
            this.grdQuestions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdQuestions_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 30;
            // 
            // Respuesta
            // 
            this.Respuesta.DataPropertyName = "Text";
            this.Respuesta.HeaderText = "Respuesta";
            this.Respuesta.Name = "Respuesta";
            this.Respuesta.ReadOnly = true;
            this.Respuesta.Width = 250;
            // 
            // Puntos
            // 
            this.Puntos.DataPropertyName = "Points";
            this.Puntos.HeaderText = "Puntos";
            this.Puntos.Name = "Puntos";
            this.Puntos.ReadOnly = true;
            this.Puntos.Width = 50;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.chkAcumTimePoints);
            this.tabPage2.Controls.Add(this.cboPuntCalc);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Puntuación";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkVotesCounter);
            this.groupBox1.Controls.Add(this.rdbCronoAnimacion);
            this.groupBox1.Controls.Add(this.rdbCronoNumerico);
            this.groupBox1.Location = new System.Drawing.Point(11, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 81);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cronómetro";
            // 
            // chkVotesCounter
            // 
            this.chkVotesCounter.AutoSize = true;
            this.chkVotesCounter.Location = new System.Drawing.Point(161, 20);
            this.chkVotesCounter.Name = "chkVotesCounter";
            this.chkVotesCounter.Size = new System.Drawing.Size(150, 17);
            this.chkVotesCounter.TabIndex = 5;
            this.chkVotesCounter.Text = "Mostrar contador de votos";
            this.chkVotesCounter.UseVisualStyleBackColor = true;
            // 
            // rdbCronoAnimacion
            // 
            this.rdbCronoAnimacion.AutoSize = true;
            this.rdbCronoAnimacion.Location = new System.Drawing.Point(45, 42);
            this.rdbCronoAnimacion.Name = "rdbCronoAnimacion";
            this.rdbCronoAnimacion.Size = new System.Drawing.Size(74, 17);
            this.rdbCronoAnimacion.TabIndex = 1;
            this.rdbCronoAnimacion.Text = "Animación";
            this.rdbCronoAnimacion.UseVisualStyleBackColor = true;
            // 
            // rdbCronoNumerico
            // 
            this.rdbCronoNumerico.AutoSize = true;
            this.rdbCronoNumerico.Checked = true;
            this.rdbCronoNumerico.Location = new System.Drawing.Point(45, 19);
            this.rdbCronoNumerico.Name = "rdbCronoNumerico";
            this.rdbCronoNumerico.Size = new System.Drawing.Size(70, 17);
            this.rdbCronoNumerico.TabIndex = 0;
            this.rdbCronoNumerico.TabStop = true;
            this.rdbCronoNumerico.Text = "Numérico";
            this.rdbCronoNumerico.UseVisualStyleBackColor = true;
            // 
            // chkAcumTimePoints
            // 
            this.chkAcumTimePoints.AutoSize = true;
            this.chkAcumTimePoints.Location = new System.Drawing.Point(56, 53);
            this.chkAcumTimePoints.Name = "chkAcumTimePoints";
            this.chkAcumTimePoints.Size = new System.Drawing.Size(185, 17);
            this.chkAcumTimePoints.TabIndex = 3;
            this.chkAcumTimePoints.Text = "Considerar el tiempo de respuesta";
            this.chkAcumTimePoints.UseVisualStyleBackColor = true;
            // 
            // cboPuntCalc
            // 
            this.cboPuntCalc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntCalc.FormattingEnabled = true;
            this.cboPuntCalc.Items.AddRange(new object[] {
            "Acumular puntos de las respuestas"});
            this.cboPuntCalc.Location = new System.Drawing.Point(56, 16);
            this.cboPuntCalc.Name = "cboPuntCalc";
            this.cboPuntCalc.Size = new System.Drawing.Size(303, 21);
            this.cboPuntCalc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Calculo";
            // 
            // CreateQuestionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 372);
            this.Controls.Add(this.tabQDef);
            this.Controls.Add(this.txtQuestionTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripPrincipal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 410);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 410);
            this.Name = "CreateQuestionView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Pregunta";
            this.toolStripPrincipal.ResumeLayout(false);
            this.toolStripPrincipal.PerformLayout();
            this.tabQDef.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuestions)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripPrincipal;
        private System.Windows.Forms.ToolStripButton btnQuestionCerrar;
        private System.Windows.Forms.ToolStripButton btnQueationApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuestionTitle;
        private System.Windows.Forms.TabControl tabQDef;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grdQuestions;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewAnswer;
        private System.Windows.Forms.ToolStripButton btnEditAnswer;
        private System.Windows.Forms.ToolStripButton btnDeleteAnswer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Respuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntos;
        private System.Windows.Forms.CheckBox chkAcumTimePoints;
        private System.Windows.Forms.ComboBox cboPuntCalc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbCronoAnimacion;
        private System.Windows.Forms.RadioButton rdbCronoNumerico;
        private System.Windows.Forms.CheckBox chkVotesCounter;
    }
}
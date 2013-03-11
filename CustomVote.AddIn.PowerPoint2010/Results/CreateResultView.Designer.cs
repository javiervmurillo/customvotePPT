namespace CustomVote.AddIn.PowerPoint2010.Results
{
    partial class CreateResultView
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboResultType = new System.Windows.Forms.ComboBox();
            this.toolStripPrincipal = new System.Windows.Forms.ToolStrip();
            this.btnResultClose = new System.Windows.Forms.ToolStripButton();
            this.btnResultApply = new System.Windows.Forms.ToolStripButton();
            this.chkQuestionsList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numDecimals = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHistWidthAjust = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboHistOrder = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboHistValueType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabAvanzadas = new System.Windows.Forms.TabPage();
            this.toolStripPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecimals)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de resultado";
            // 
            // cboResultType
            // 
            this.cboResultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResultType.FormattingEnabled = true;
            this.cboResultType.Items.AddRange(new object[] {
            "Normal",
            "Ranking Acumulado",
            "Espejo",
            "Comparación cruzada"});
            this.cboResultType.Location = new System.Drawing.Point(107, 16);
            this.cboResultType.Name = "cboResultType";
            this.cboResultType.Size = new System.Drawing.Size(248, 21);
            this.cboResultType.TabIndex = 1;
            this.cboResultType.SelectedIndexChanged += new System.EventHandler(this.cboResultType_SelectedIndexChanged);
            // 
            // toolStripPrincipal
            // 
            this.toolStripPrincipal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnResultClose,
            this.btnResultApply});
            this.toolStripPrincipal.Location = new System.Drawing.Point(0, 395);
            this.toolStripPrincipal.Name = "toolStripPrincipal";
            this.toolStripPrincipal.Size = new System.Drawing.Size(367, 25);
            this.toolStripPrincipal.TabIndex = 2;
            this.toolStripPrincipal.Text = "toolStrip1";
            // 
            // btnResultClose
            // 
            this.btnResultClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnResultClose.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.arrow_curve_000_left;
            this.btnResultClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResultClose.Name = "btnResultClose";
            this.btnResultClose.Size = new System.Drawing.Size(59, 22);
            this.btnResultClose.Text = "Cerrar";
            this.btnResultClose.Click += new System.EventHandler(this.btnResultClose_Click);
            // 
            // btnResultApply
            // 
            this.btnResultApply.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnResultApply.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.disk_black;
            this.btnResultApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResultApply.Name = "btnResultApply";
            this.btnResultApply.Size = new System.Drawing.Size(64, 22);
            this.btnResultApply.Text = "Aplicar";
            this.btnResultApply.Click += new System.EventHandler(this.btnResultApply_Click);
            // 
            // chkQuestionsList
            // 
            this.chkQuestionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkQuestionsList.FormattingEnabled = true;
            this.chkQuestionsList.Location = new System.Drawing.Point(3, 16);
            this.chkQuestionsList.Name = "chkQuestionsList";
            this.chkQuestionsList.ScrollAlwaysVisible = true;
            this.chkQuestionsList.Size = new System.Drawing.Size(337, 157);
            this.chkQuestionsList.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkQuestionsList);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 176);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preguntas";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabAvanzadas);
            this.tabControl1.Location = new System.Drawing.Point(12, 225);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(343, 169);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numDecimals);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtHistWidthAjust);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cboHistOrder);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboHistValueType);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(335, 143);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Histograma";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numDecimals
            // 
            this.numDecimals.Location = new System.Drawing.Point(123, 48);
            this.numDecimals.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numDecimals.Name = "numDecimals";
            this.numDecimals.Size = new System.Drawing.Size(178, 20);
            this.numDecimals.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Decimales";
            // 
            // txtHistWidthAjust
            // 
            this.txtHistWidthAjust.Location = new System.Drawing.Point(123, 101);
            this.txtHistWidthAjust.Mask = "00% del \\ancho de l\\a di\\apositiv\\a";
            this.txtHistWidthAjust.Name = "txtHistWidthAjust";
            this.txtHistWidthAjust.Size = new System.Drawing.Size(178, 20);
            this.txtHistWidthAjust.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ajuste de tamaño";
            // 
            // cboHistOrder
            // 
            this.cboHistOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHistOrder.FormattingEnabled = true;
            this.cboHistOrder.Items.AddRange(new object[] {
            "Ninguno",
            "Ascendente",
            "Descendente"});
            this.cboHistOrder.Location = new System.Drawing.Point(123, 74);
            this.cboHistOrder.Name = "cboHistOrder";
            this.cboHistOrder.Size = new System.Drawing.Size(178, 21);
            this.cboHistOrder.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Orden";
            // 
            // cboHistValueType
            // 
            this.cboHistValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHistValueType.FormattingEnabled = true;
            this.cboHistValueType.Items.AddRange(new object[] {
            "Porcentual",
            "Numérico"});
            this.cboHistValueType.Location = new System.Drawing.Point(123, 21);
            this.cboHistValueType.Name = "cboHistValueType";
            this.cboHistValueType.Size = new System.Drawing.Size(178, 21);
            this.cboHistValueType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo de valor";
            // 
            // tabAvanzadas
            // 
            this.tabAvanzadas.Location = new System.Drawing.Point(4, 22);
            this.tabAvanzadas.Name = "tabAvanzadas";
            this.tabAvanzadas.Padding = new System.Windows.Forms.Padding(3);
            this.tabAvanzadas.Size = new System.Drawing.Size(335, 143);
            this.tabAvanzadas.TabIndex = 1;
            this.tabAvanzadas.Text = "Avanzadas";
            this.tabAvanzadas.UseVisualStyleBackColor = true;
            // 
            // CreateResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 420);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripPrincipal);
            this.Controls.Add(this.cboResultType);
            this.Controls.Add(this.label1);
            this.Name = "CreateResultView";
            this.Text = "Resultado";
            this.toolStripPrincipal.ResumeLayout(false);
            this.toolStripPrincipal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecimals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboResultType;
        private System.Windows.Forms.ToolStrip toolStripPrincipal;
        private System.Windows.Forms.ToolStripButton btnResultClose;
        private System.Windows.Forms.ToolStripButton btnResultApply;
        private System.Windows.Forms.CheckedListBox chkQuestionsList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MaskedTextBox txtHistWidthAjust;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboHistOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboHistValueType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numDecimals;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabAvanzadas;
    }
}
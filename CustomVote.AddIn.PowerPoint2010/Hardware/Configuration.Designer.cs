namespace CustomVote.AddIn.PowerPoint2010.Hardware
{
    partial class Configuration
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
            this.btnConfigCerrar = new System.Windows.Forms.ToolStripButton();
            this.btnConfigSave = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDescBase2 = new System.Windows.Forms.Button();
            this.lblConectStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkSimulateMode = new System.Windows.Forms.CheckBox();
            this.txtConfigBaseId = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkOnlyThisKeypads = new System.Windows.Forms.CheckBox();
            this.gridKeyPads = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnDescubrirMandos = new System.Windows.Forms.ToolStripButton();
            this.btnConfigMandosImportFromCSV = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtCsvDelimiter = new System.Windows.Forms.ToolStripTextBox();
            this.tabReceptor = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbCommitOnOK = new System.Windows.Forms.RadioButton();
            this.rbCommitAuto = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkDoNotOffKeypad = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numTimeToOffKeyPad = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbReportOnStandby = new System.Windows.Forms.RadioButton();
            this.rbReportOnStandbyOrVoting = new System.Windows.Forms.RadioButton();
            this.rbReportOnVoting = new System.Windows.Forms.RadioButton();
            this.rbNorReport = new System.Windows.Forms.RadioButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnGetFeatureConfig = new System.Windows.Forms.ToolStripButton();
            this.btnSetFeaturedConfig = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkPPtRemote = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKeyPads)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabReceptor.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeToOffKeyPad)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfigCerrar,
            this.btnConfigSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 453);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(488, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConfigCerrar
            // 
            this.btnConfigCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnConfigCerrar.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.arrow_curve_000_left;
            this.btnConfigCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfigCerrar.Name = "btnConfigCerrar";
            this.btnConfigCerrar.Size = new System.Drawing.Size(59, 22);
            this.btnConfigCerrar.Text = "Cerrar";
            this.btnConfigCerrar.Click += new System.EventHandler(this.btnConfigCerrar_Click);
            // 
            // btnConfigSave
            // 
            this.btnConfigSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnConfigSave.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.disk_black;
            this.btnConfigSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfigSave.Name = "btnConfigSave";
            this.btnConfigSave.Size = new System.Drawing.Size(69, 22);
            this.btnConfigSave.Text = "Guardar";
            this.btnConfigSave.Click += new System.EventHandler(this.btnConfigSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Receptor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPPtRemote);
            this.groupBox1.Controls.Add(this.btnDescBase2);
            this.groupBox1.Controls.Add(this.lblConectStatus);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.chkSimulateMode);
            this.groupBox1.Controls.Add(this.txtConfigBaseId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base";
            // 
            // btnDescBase2
            // 
            this.btnDescBase2.Location = new System.Drawing.Point(177, 16);
            this.btnDescBase2.Name = "btnDescBase2";
            this.btnDescBase2.Size = new System.Drawing.Size(101, 23);
            this.btnDescBase2.TabIndex = 7;
            this.btnDescBase2.Text = "Descubrir Base";
            this.btnDescBase2.UseVisualStyleBackColor = true;
            this.btnDescBase2.Click += new System.EventHandler(this.btnDescBase2_Click);
            // 
            // lblConectStatus
            // 
            this.lblConectStatus.AutoSize = true;
            this.lblConectStatus.Location = new System.Drawing.Point(284, 45);
            this.lblConectStatus.Name = "lblConectStatus";
            this.lblConectStatus.Size = new System.Drawing.Size(0, 13);
            this.lblConectStatus.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(284, 16);
            this.progressBar1.Maximum = 8;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(173, 22);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // chkSimulateMode
            // 
            this.chkSimulateMode.AutoSize = true;
            this.chkSimulateMode.Location = new System.Drawing.Point(23, 46);
            this.chkSimulateMode.Name = "chkSimulateMode";
            this.chkSimulateMode.Size = new System.Drawing.Size(77, 17);
            this.chkSimulateMode.TabIndex = 4;
            this.chkSimulateMode.Text = "Simulación";
            this.chkSimulateMode.UseVisualStyleBackColor = true;
            this.chkSimulateMode.CheckedChanged += new System.EventHandler(this.chkSimulateMode_CheckedChanged);
            // 
            // txtConfigBaseId
            // 
            this.txtConfigBaseId.Location = new System.Drawing.Point(71, 16);
            this.txtConfigBaseId.Name = "txtConfigBaseId";
            this.txtConfigBaseId.Size = new System.Drawing.Size(100, 20);
            this.txtConfigBaseId.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabReceptor);
            this.tabControl1.Location = new System.Drawing.Point(12, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 363);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkOnlyThisKeypads);
            this.tabPage1.Controls.Add(this.gridKeyPads);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mandos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkOnlyThisKeypads
            // 
            this.chkOnlyThisKeypads.AutoSize = true;
            this.chkOnlyThisKeypads.Location = new System.Drawing.Point(6, 314);
            this.chkOnlyThisKeypads.Name = "chkOnlyThisKeypads";
            this.chkOnlyThisKeypads.Size = new System.Drawing.Size(301, 17);
            this.chkOnlyThisKeypads.TabIndex = 2;
            this.chkOnlyThisKeypads.Text = "Tener en cuenta unicamente estos mandos en la votación";
            this.chkOnlyThisKeypads.UseVisualStyleBackColor = true;
            this.chkOnlyThisKeypads.CheckedChanged += new System.EventHandler(this.chkOnlyThisKeypads_CheckedChanged);
            // 
            // gridKeyPads
            // 
            this.gridKeyPads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKeyPads.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridKeyPads.Location = new System.Drawing.Point(3, 28);
            this.gridKeyPads.Name = "gridKeyPads";
            this.gridKeyPads.Size = new System.Drawing.Size(450, 282);
            this.gridKeyPads.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDescubrirMandos,
            this.btnConfigMandosImportFromCSV,
            this.toolStripLabel1,
            this.txtCsvDelimiter});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(450, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnDescubrirMandos
            // 
            this.btnDescubrirMandos.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.tag_label;
            this.btnDescubrirMandos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDescubrirMandos.Name = "btnDescubrirMandos";
            this.btnDescubrirMandos.Size = new System.Drawing.Size(123, 22);
            this.btnDescubrirMandos.Text = "Descubrir mandos";
            this.btnDescubrirMandos.Click += new System.EventHandler(this.btnDescubrirMandos_Click);
            // 
            // btnConfigMandosImportFromCSV
            // 
            this.btnConfigMandosImportFromCSV.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.counter;
            this.btnConfigMandosImportFromCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfigMandosImportFromCSV.Name = "btnConfigMandosImportFromCSV";
            this.btnConfigMandosImportFromCSV.Size = new System.Drawing.Size(127, 22);
            this.btnConfigMandosImportFromCSV.Text = "Importa desde CSV";
            this.btnConfigMandosImportFromCSV.Click += new System.EventHandler(this.btnConfigMandosImportFromCSV_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel1.Text = "Delimitador";
            // 
            // txtCsvDelimiter
            // 
            this.txtCsvDelimiter.Name = "txtCsvDelimiter";
            this.txtCsvDelimiter.Size = new System.Drawing.Size(25, 25);
            this.txtCsvDelimiter.Text = ";";
            // 
            // tabReceptor
            // 
            this.tabReceptor.Controls.Add(this.groupBox4);
            this.tabReceptor.Controls.Add(this.groupBox3);
            this.tabReceptor.Controls.Add(this.groupBox2);
            this.tabReceptor.Controls.Add(this.toolStrip3);
            this.tabReceptor.Location = new System.Drawing.Point(4, 22);
            this.tabReceptor.Name = "tabReceptor";
            this.tabReceptor.Padding = new System.Windows.Forms.Padding(3);
            this.tabReceptor.Size = new System.Drawing.Size(456, 337);
            this.tabReceptor.TabIndex = 1;
            this.tabReceptor.Text = "Votación";
            this.tabReceptor.UseVisualStyleBackColor = true;
            this.tabReceptor.Enter += new System.EventHandler(this.tabReceptor_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbCommitOnOK);
            this.groupBox4.Controls.Add(this.rbCommitAuto);
            this.groupBox4.Location = new System.Drawing.Point(19, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(422, 66);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Envío de Votos";
            // 
            // rbCommitOnOK
            // 
            this.rbCommitOnOK.AutoSize = true;
            this.rbCommitOnOK.Location = new System.Drawing.Point(22, 28);
            this.rbCommitOnOK.Name = "rbCommitOnOK";
            this.rbCommitOnOK.Size = new System.Drawing.Size(128, 17);
            this.rbCommitOnOK.TabIndex = 5;
            this.rbCommitOnOK.TabStop = true;
            this.rbCommitOnOK.Text = "Al presionar boton OK";
            this.rbCommitOnOK.UseVisualStyleBackColor = true;
            // 
            // rbCommitAuto
            // 
            this.rbCommitAuto.AutoSize = true;
            this.rbCommitAuto.Location = new System.Drawing.Point(211, 28);
            this.rbCommitAuto.Name = "rbCommitAuto";
            this.rbCommitAuto.Size = new System.Drawing.Size(78, 17);
            this.rbCommitAuto.TabIndex = 4;
            this.rbCommitAuto.TabStop = true;
            this.rbCommitAuto.Text = "Automático";
            this.rbCommitAuto.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkDoNotOffKeypad);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numTimeToOffKeyPad);
            this.groupBox3.Location = new System.Drawing.Point(19, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tiempo de apagado de mandos";
            this.groupBox3.Visible = false;
            // 
            // chkDoNotOffKeypad
            // 
            this.chkDoNotOffKeypad.AutoSize = true;
            this.chkDoNotOffKeypad.Location = new System.Drawing.Point(241, 31);
            this.chkDoNotOffKeypad.Name = "chkDoNotOffKeypad";
            this.chkDoNotOffKeypad.Size = new System.Drawing.Size(76, 17);
            this.chkDoNotOffKeypad.TabIndex = 2;
            this.chkDoNotOffKeypad.Text = "No apagar";
            this.chkDoNotOffKeypad.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tiempo (minutos):";
            // 
            // numTimeToOffKeyPad
            // 
            this.numTimeToOffKeyPad.Location = new System.Drawing.Point(106, 29);
            this.numTimeToOffKeyPad.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.numTimeToOffKeyPad.Name = "numTimeToOffKeyPad";
            this.numTimeToOffKeyPad.Size = new System.Drawing.Size(120, 20);
            this.numTimeToOffKeyPad.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbReportOnStandby);
            this.groupBox2.Controls.Add(this.rbReportOnStandbyOrVoting);
            this.groupBox2.Controls.Add(this.rbReportOnVoting);
            this.groupBox2.Controls.Add(this.rbNorReport);
            this.groupBox2.Location = new System.Drawing.Point(19, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reporte";
            // 
            // rbReportOnStandby
            // 
            this.rbReportOnStandby.AutoSize = true;
            this.rbReportOnStandby.Location = new System.Drawing.Point(7, 43);
            this.rbReportOnStandby.Name = "rbReportOnStandby";
            this.rbReportOnStandby.Size = new System.Drawing.Size(123, 17);
            this.rbReportOnStandby.TabIndex = 3;
            this.rbReportOnStandby.TabStop = true;
            this.rbReportOnStandby.Text = "Reportar en Standby";
            this.rbReportOnStandby.UseVisualStyleBackColor = true;
            // 
            // rbReportOnStandbyOrVoting
            // 
            this.rbReportOnStandbyOrVoting.AutoSize = true;
            this.rbReportOnStandbyOrVoting.Location = new System.Drawing.Point(196, 43);
            this.rbReportOnStandbyOrVoting.Name = "rbReportOnStandbyOrVoting";
            this.rbReportOnStandbyOrVoting.Size = new System.Drawing.Size(189, 17);
            this.rbReportOnStandbyOrVoting.TabIndex = 2;
            this.rbReportOnStandbyOrVoting.TabStop = true;
            this.rbReportOnStandbyOrVoting.Text = "Reportar en standby o en votación";
            this.rbReportOnStandbyOrVoting.UseVisualStyleBackColor = true;
            // 
            // rbReportOnVoting
            // 
            this.rbReportOnVoting.AutoSize = true;
            this.rbReportOnVoting.Location = new System.Drawing.Point(196, 20);
            this.rbReportOnVoting.Name = "rbReportOnVoting";
            this.rbReportOnVoting.Size = new System.Drawing.Size(125, 17);
            this.rbReportOnVoting.TabIndex = 1;
            this.rbReportOnVoting.TabStop = true;
            this.rbReportOnVoting.Text = "Reportar en votación";
            this.rbReportOnVoting.UseVisualStyleBackColor = true;
            // 
            // rbNorReport
            // 
            this.rbNorReport.AutoSize = true;
            this.rbNorReport.Location = new System.Drawing.Point(7, 20);
            this.rbNorReport.Name = "rbNorReport";
            this.rbNorReport.Size = new System.Drawing.Size(78, 17);
            this.rbNorReport.TabIndex = 0;
            this.rbNorReport.TabStop = true;
            this.rbNorReport.Text = "No reportar";
            this.rbNorReport.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGetFeatureConfig,
            this.btnSetFeaturedConfig});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(450, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            this.toolStrip3.Visible = false;
            // 
            // btnGetFeatureConfig
            // 
            this.btnGetFeatureConfig.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.keyboard_command;
            this.btnGetFeatureConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetFeatureConfig.Name = "btnGetFeatureConfig";
            this.btnGetFeatureConfig.Size = new System.Drawing.Size(142, 22);
            this.btnGetFeatureConfig.Text = "Obtener Cofiguración";
            this.btnGetFeatureConfig.Click += new System.EventHandler(this.btnGetFeatureConfig_Click);
            // 
            // btnSetFeaturedConfig
            // 
            this.btnSetFeaturedConfig.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.tick;
            this.btnSetFeaturedConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetFeaturedConfig.Name = "btnSetFeaturedConfig";
            this.btnSetFeaturedConfig.Size = new System.Drawing.Size(138, 22);
            this.btnSetFeaturedConfig.Text = "Enviar Configuración";
            this.btnSetFeaturedConfig.Click += new System.EventHandler(this.btnSetFeaturedConfig_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkPPtRemote
            // 
            this.chkPPtRemote.AutoSize = true;
            this.chkPPtRemote.Location = new System.Drawing.Point(124, 46);
            this.chkPPtRemote.Name = "chkPPtRemote";
            this.chkPPtRemote.Size = new System.Drawing.Size(167, 17);
            this.chkPPtRemote.TabIndex = 8;
            this.chkPPtRemote.Text = "Activar Mando de PowerPoint";
            this.chkPPtRemote.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 478);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKeyPads)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabReceptor.ResumeLayout(false);
            this.tabReceptor.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeToOffKeyPad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnConfigCerrar;
        private System.Windows.Forms.ToolStripButton btnConfigSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConfigBaseId;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gridKeyPads;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnConfigMandosImportFromCSV;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkSimulateMode;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblConectStatus;
        private System.Windows.Forms.Button btnDescBase2;
        private System.Windows.Forms.TabPage tabReceptor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbReportOnStandby;
        private System.Windows.Forms.RadioButton rbReportOnStandbyOrVoting;
        private System.Windows.Forms.RadioButton rbReportOnVoting;
        private System.Windows.Forms.RadioButton rbNorReport;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnGetFeatureConfig;
        private System.Windows.Forms.ToolStripButton btnSetFeaturedConfig;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbCommitOnOK;
        private System.Windows.Forms.RadioButton rbCommitAuto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkDoNotOffKeypad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numTimeToOffKeyPad;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtCsvDelimiter;
        private System.Windows.Forms.ToolStripButton btnDescubrirMandos;
        private System.Windows.Forms.CheckBox chkOnlyThisKeypads;
        private System.Windows.Forms.CheckBox chkPPtRemote;
    }
}
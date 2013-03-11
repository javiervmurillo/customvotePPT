namespace CustomVote.AddIn.PowerPoint2010.Results
{
    partial class RankingConfigView
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.rnkTopResults = new System.Windows.Forms.NumericUpDown();
            this.chkShowTime = new System.Windows.Forms.CheckBox();
            this.rdbPregAcertadas = new System.Windows.Forms.RadioButton();
            this.rdbCantPuntos = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.rnkTopResults)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad de resultados:";
            // 
            // rnkTopResults
            // 
            this.rnkTopResults.Location = new System.Drawing.Point(127, 15);
            this.rnkTopResults.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rnkTopResults.Name = "rnkTopResults";
            this.rnkTopResults.Size = new System.Drawing.Size(120, 20);
            this.rnkTopResults.TabIndex = 1;
            // 
            // chkShowTime
            // 
            this.chkShowTime.AutoSize = true;
            this.chkShowTime.Location = new System.Drawing.Point(14, 48);
            this.chkShowTime.Name = "chkShowTime";
            this.chkShowTime.Size = new System.Drawing.Size(95, 17);
            this.chkShowTime.TabIndex = 2;
            this.chkShowTime.Text = "Mostrar tiempo";
            this.chkShowTime.UseVisualStyleBackColor = true;
            // 
            // rdbPregAcertadas
            // 
            this.rdbPregAcertadas.AutoSize = true;
            this.rdbPregAcertadas.Location = new System.Drawing.Point(14, 3);
            this.rdbPregAcertadas.Name = "rdbPregAcertadas";
            this.rdbPregAcertadas.Size = new System.Drawing.Size(123, 17);
            this.rdbPregAcertadas.TabIndex = 0;
            this.rdbPregAcertadas.TabStop = true;
            this.rdbPregAcertadas.Text = "Preguntas acertadas";
            this.rdbPregAcertadas.UseVisualStyleBackColor = true;
            // 
            // rdbCantPuntos
            // 
            this.rdbCantPuntos.AutoSize = true;
            this.rdbCantPuntos.Location = new System.Drawing.Point(143, 3);
            this.rdbCantPuntos.Name = "rdbCantPuntos";
            this.rdbCantPuntos.Size = new System.Drawing.Size(118, 17);
            this.rdbCantPuntos.TabIndex = 1;
            this.rdbCantPuntos.TabStop = true;
            this.rdbCantPuntos.Text = "Cantidad de Puntos";
            this.rdbCantPuntos.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbPregAcertadas);
            this.panel1.Controls.Add(this.rdbCantPuntos);
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 28);
            this.panel1.TabIndex = 3;
            // 
            // RankingConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkShowTime);
            this.Controls.Add(this.rnkTopResults);
            this.Controls.Add(this.label1);
            this.Name = "RankingConfigView";
            this.Size = new System.Drawing.Size(330, 145);
            ((System.ComponentModel.ISupportInitialize)(this.rnkTopResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown rnkTopResults;
        private System.Windows.Forms.CheckBox chkShowTime;
        private System.Windows.Forms.RadioButton rdbCantPuntos;
        private System.Windows.Forms.RadioButton rdbPregAcertadas;
        private System.Windows.Forms.Panel panel1;
    }
}

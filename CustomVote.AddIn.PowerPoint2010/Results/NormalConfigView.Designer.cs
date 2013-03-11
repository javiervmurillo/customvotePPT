namespace CustomVote.AddIn.PowerPoint2010.Results
{
    partial class NormalConfigView
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
            this.chkKeepTogetherResult = new System.Windows.Forms.CheckBox();
            this.chkCopyQuetionShapesFormat = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkKeepTogetherResult
            // 
            this.chkKeepTogetherResult.AutoSize = true;
            this.chkKeepTogetherResult.Location = new System.Drawing.Point(16, 20);
            this.chkKeepTogetherResult.Name = "chkKeepTogetherResult";
            this.chkKeepTogetherResult.Size = new System.Drawing.Size(189, 17);
            this.chkKeepTogetherResult.TabIndex = 0;
            this.chkKeepTogetherResult.Text = "Mantener resultado junto al gráfico";
            this.chkKeepTogetherResult.UseVisualStyleBackColor = true;
            // 
            // chkCopyQuetionShapesFormat
            // 
            this.chkCopyQuetionShapesFormat.AutoSize = true;
            this.chkCopyQuetionShapesFormat.Location = new System.Drawing.Point(16, 43);
            this.chkCopyQuetionShapesFormat.Name = "chkCopyQuetionShapesFormat";
            this.chkCopyQuetionShapesFormat.Size = new System.Drawing.Size(218, 17);
            this.chkCopyQuetionShapesFormat.TabIndex = 1;
            this.chkCopyQuetionShapesFormat.Text = "Copiar formato de la diapositiva pregunta";
            this.chkCopyQuetionShapesFormat.UseVisualStyleBackColor = true;
            // 
            // NormalConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkCopyQuetionShapesFormat);
            this.Controls.Add(this.chkKeepTogetherResult);
            this.Name = "NormalConfigView";
            this.Size = new System.Drawing.Size(330, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkKeepTogetherResult;
        private System.Windows.Forms.CheckBox chkCopyQuetionShapesFormat;
    }
}

namespace CustomVote.AddIn.PowerPoint2010
{
    partial class CustomVoteRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CustomVoteRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; en caso contrario, false.</param>
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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.CustomVoteTab = this.Factory.CreateRibbonTab();
            this.RibbonGroupMando = this.Factory.CreateRibbonGroup();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.grpVotes = this.Factory.CreateRibbonGroup();
            this.btnCtrlConfig = this.Factory.CreateRibbonButton();
            this.btnBlanckSlide = this.Factory.CreateRibbonButton();
            this.btnAddQuestion = this.Factory.CreateRibbonButton();
            this.btnAddResult = this.Factory.CreateRibbonButton();
            this.btnClearVotes = this.Factory.CreateRibbonButton();
            this.btnKeyPadsPowerOff = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.CustomVoteTab.SuspendLayout();
            this.RibbonGroupMando.SuspendLayout();
            this.group3.SuspendLayout();
            this.grpVotes.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // CustomVoteTab
            // 
            this.CustomVoteTab.Groups.Add(this.RibbonGroupMando);
            this.CustomVoteTab.Groups.Add(this.group3);
            this.CustomVoteTab.Groups.Add(this.grpVotes);
            this.CustomVoteTab.Label = "CustomVote";
            this.CustomVoteTab.Name = "CustomVoteTab";
            // 
            // RibbonGroupMando
            // 
            this.RibbonGroupMando.Items.Add(this.btnCtrlConfig);
            this.RibbonGroupMando.Items.Add(this.btnKeyPadsPowerOff);
            this.RibbonGroupMando.Label = "Mandos";
            this.RibbonGroupMando.Name = "RibbonGroupMando";
            // 
            // group3
            // 
            this.group3.Items.Add(this.btnBlanckSlide);
            this.group3.Items.Add(this.btnAddQuestion);
            this.group3.Items.Add(this.btnAddResult);
            this.group3.Label = "Diapositivas";
            this.group3.Name = "group3";
            // 
            // grpVotes
            // 
            this.grpVotes.Items.Add(this.btnClearVotes);
            this.grpVotes.Label = "Votos";
            this.grpVotes.Name = "grpVotes";
            // 
            // btnCtrlConfig
            // 
            this.btnCtrlConfig.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnCtrlConfig.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.application_sidebar_list;
            this.btnCtrlConfig.Label = "Configuración";
            this.btnCtrlConfig.Name = "btnCtrlConfig";
            this.btnCtrlConfig.ShowImage = true;
            this.btnCtrlConfig.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCtrlConfig_Click);
            // 
            // btnBlanckSlide
            // 
            this.btnBlanckSlide.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnBlanckSlide.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.blue_document_horizontal;
            this.btnBlanckSlide.Label = "Nueva";
            this.btnBlanckSlide.Name = "btnBlanckSlide";
            this.btnBlanckSlide.ShowImage = true;
            this.btnBlanckSlide.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnBlanckSlide_Click);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAddQuestion.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.balloon;
            this.btnAddQuestion.Label = "Pregunta";
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.ShowImage = true;
            this.btnAddQuestion.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAddQuestion_Click);
            // 
            // btnAddResult
            // 
            this.btnAddResult.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAddResult.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.tick;
            this.btnAddResult.Label = "Resultados";
            this.btnAddResult.Name = "btnAddResult";
            this.btnAddResult.ShowImage = true;
            this.btnAddResult.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAddResult_Click);
            // 
            // btnClearVotes
            // 
            this.btnClearVotes.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnClearVotes.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.eraser;
            this.btnClearVotes.Label = "Limpiar Votos";
            this.btnClearVotes.Name = "btnClearVotes";
            this.btnClearVotes.ShowImage = true;
            this.btnClearVotes.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnClearVotes_Click);
            // 
            // btnKeyPadsPowerOff
            // 
            this.btnKeyPadsPowerOff.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnKeyPadsPowerOff.Image = global::CustomVote.AddIn.PowerPoint2010.Properties.Resources.keyboard_command;
            this.btnKeyPadsPowerOff.Label = "Apagar Mandos";
            this.btnKeyPadsPowerOff.Name = "btnKeyPadsPowerOff";
            this.btnKeyPadsPowerOff.ShowImage = true;
            this.btnKeyPadsPowerOff.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnKeyPadsPowerOff_Click);
            // 
            // CustomVoteRibbon
            // 
            this.Name = "CustomVoteRibbon";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.CustomVoteTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.CustomVoteRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.CustomVoteTab.ResumeLayout(false);
            this.CustomVoteTab.PerformLayout();
            this.RibbonGroupMando.ResumeLayout(false);
            this.RibbonGroupMando.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.grpVotes.ResumeLayout(false);
            this.grpVotes.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        private Microsoft.Office.Tools.Ribbon.RibbonTab CustomVoteTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup RibbonGroupMando;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAddQuestion;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAddResult;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCtrlConfig;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnBlanckSlide;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpVotes;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnClearVotes;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnKeyPadsPowerOff;
    }

    partial class ThisRibbonCollection
    {
        internal CustomVoteRibbon CustomVoteRibbon
        {
            get { return this.GetRibbon<CustomVoteRibbon>(); }
        }
    }
}

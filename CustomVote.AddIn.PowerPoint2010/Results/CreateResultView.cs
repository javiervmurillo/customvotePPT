using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomVote.AddIn.PowerPoint2010.Results.Data;
using CustomVote.AddIn.PowerPoint2010.Helpers;
using CustomVote.AddIn.PowerPoint2010.Properties;

namespace CustomVote.AddIn.PowerPoint2010.Results
{
    public partial class CreateResultView : Form
    {
        private Microsoft.Office.Interop.PowerPoint.Application _app = Globals.ThisAddIn.Application;
        ResultSlideConfiguration _currentConfig;
        
        public CreateResultView()
        {
            InitializeComponent();
            _app = Globals.ThisAddIn.Application;
            ValidateResultSlide();
            FillQuestionsList();
            SetInitialValues();
        }

        private void ValidateResultSlide()
        {
            var slidesCounts = _app.ActivePresentation.Slides.Count;
            if (slidesCounts == 0)
            {
                MessageBox.Show("Agregue una nueva diapositiva", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception("Slides empty");
            }
            var slideId = ((Microsoft.Office.Interop.PowerPoint.Slide)_app.ActiveWindow.View.Slide).SlideID;

            if (!IsResultSlide(slideId))
            {
                MessageBox.Show(Resources.ResourceManager.GetString("Msg_IsNotResultSlide"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(Resources.ResourceManager.GetString("Msg_IsNotResultSlide"));
            }
            _currentConfig = Globals.ThisAddIn.Session.GetResultSlideConfiguration(slideId);
        }

        private bool IsResultSlide(int slideId)
        {
            return Globals.ThisAddIn.Session.IsResultSlide(slideId);
        }

        private void FillQuestionsList()
        {
            var qestionsLst = Globals.ThisAddIn.Session.GetQuestionList();
            chkQuestionsList.Items.AddRange(qestionsLst.ToArray());
        }

        private void SetInitialValues()
        {
            cboResultType.SelectedIndex = (int)_currentConfig.ResultType;
            cboHistValueType.SelectedIndex = (int)_currentConfig.Valuetype;
            cboHistOrder.SelectedIndex = (int)_currentConfig.ValueOrder;
            txtHistWidthAjust.Text = _currentConfig.HistWidthPercent.ToString();
            
            foreach (var q in _currentConfig.SelectedQuestions)
            {
                int index = 0;
                List<int> forCheck = new List<int>();
                foreach (var sq in chkQuestionsList.Items)
                {
                    var item = sq as ItemList;
                    if (item.Id == q.QuestionRelation.Id)
                        forCheck.Add(index);
                    index++;
                }
                foreach (var i in forCheck)
                {
                    chkQuestionsList.SetItemCheckState(i, CheckState.Checked);
                    chkQuestionsList.SetSelected(i, true);
                }
            }
            if (!_currentConfig.IsNew)
            {
                cboResultType.Enabled = false;
                chkQuestionsList.Enabled = false;
            }
        }

        private void btnResultClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResultApply_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateView();
                SaveConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK);
            }
        }

        private void SaveConfig()
        {
            foreach (var ctrl in ((Control)tabAvanzadas).Controls)
            {
                if (ctrl is Interfaces.IResultView)
                    ((Interfaces.IResultView)ctrl).Save();

            }

            if (_currentConfig.IsNew)
                CompleteNewConfig();
            else
                ApplyResultChanges();

            
        }

        private void UpdateConfigFromView()
        {
            _currentConfig.Decimals = numDecimals.Value;
            _currentConfig.ValueOrder = (HistValueOrder)Enum.Parse(typeof(HistValueOrder), (string)cboHistOrder.SelectedItem, true);
            _currentConfig.Valuetype = (HistValueType)Enum.Parse(typeof(HistValueType), (string)cboHistValueType.SelectedItem, true);
            _currentConfig.HistWidthPercent = Int32.Parse(txtHistWidthAjust.Text.Substring(0, 2));
            
        }

        private void ApplyResultChanges()
        {
            UpdateConfigFromView();

            _currentConfig.UpdateChartValues();
            _currentConfig.Ordering();
            _currentConfig.ResizeCharts();
        }

        private void CompleteNewConfig()
        {
            _currentConfig.SlideAssociated = Helpers.PowerPointHelper.CreateSlideOn(_currentConfig.SlideId);
            _currentConfig.ResultType = (ResultType)cboResultType.SelectedIndex;
            

            UpdateConfigFromView();

            List<ItemList> lstQuestions = new List<ItemList>();

            foreach (var item in this.chkQuestionsList.CheckedItems)
            {
                lstQuestions.Add(item as ItemList);
            }

            _currentConfig.DrawSlide(lstQuestions);
            _currentConfig.CreateTitle();
            _currentConfig.Ordering();
            
            Globals.ThisAddIn.Session.SaveResultConfiguration(_currentConfig);
        }

        private void ValidateView()
        {
            var selectedQuestions = chkQuestionsList.CheckedItems;

            if (selectedQuestions.Count == 0)
                throw new Exception("No ha seleccionado ninguna pregunta");

            ResultType resultType = (ResultType)cboResultType.SelectedIndex;
            switch (resultType)
            {
                case ResultType.Normal:
                    if (selectedQuestions.Count > 1)
                        throw new Exception("Debe seleccionar solo una pregunta");
                    break;
                case ResultType.Ranking:
                    break;
                case ResultType.Espejo:
                case ResultType.Cruza:
                    if (selectedQuestions.Count != 2)
                        throw new Exception("Debe seleccionar dos preguntas");
                    break;
                default:
                    break;
            }
        }

        private void cboResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResultType type = (ResultType)cboResultType.SelectedIndex;
            
            switch (type)
            {
                case ResultType.Normal:
                    ((Control)tabAvanzadas).Controls.Clear();
                    NormalConfigView norm= new NormalConfigView();
                    norm.Init(_currentConfig.NormalConfig);
                    ((Control)tabAvanzadas).Controls.Add(norm);
                    ((Control)tabAvanzadas).Enabled = true;
                    break;
                case ResultType.Ranking:
                    RankingConfigView rnk = new RankingConfigView();
                    rnk.Init(_currentConfig.RankingConfig);
                    ((Control)tabAvanzadas).Controls.Clear();
                    ((Control)tabAvanzadas).Controls.Add(rnk);
                    ((Control)tabAvanzadas).Enabled = true;
                    break;
                case ResultType.Espejo:
                    ((Control)tabAvanzadas).Controls.Clear();
                    ((Control)tabAvanzadas).Enabled = false;
                    break;
                case ResultType.Cruza:
                    break;
                default:
                    
                    break;
            }
        }
    }
}

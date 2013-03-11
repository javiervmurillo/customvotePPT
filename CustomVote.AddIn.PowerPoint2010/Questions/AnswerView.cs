using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomVote.AddIn.PowerPoint2010.Questions.Data;

namespace CustomVote.AddIn.PowerPoint2010.Questions
{
    public partial class AnswerView : Form
    {
        AnswerEntity _currentAnswer;
        public AnswerView(AnswerEntity answer)
        {
            _currentAnswer = answer;
            InitializeComponent();
            InitAnswer();
        }

        private void InitAnswer()
        {
            txtRespuesta.Text = _currentAnswer.Text;
            numAnswerPoints.Value = Convert.ToDecimal(_currentAnswer.Points);
        }

        private void btnAnswSave_Click(object sender, EventArgs e)
        {
            _currentAnswer.Text = txtRespuesta.Text;
            _currentAnswer.Points = Convert.ToInt32(numAnswerPoints.Value);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnAnswClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}

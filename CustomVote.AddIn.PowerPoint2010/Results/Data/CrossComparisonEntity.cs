using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomVote.AddIn.PowerPoint2010.Questions.Data;

namespace CustomVote.AddIn.PowerPoint2010.Results.Data
{
    [Serializable]
    public class CrossComparisonEntity
    {
        private ResultSlideConfiguration _resultConfig;

        public CrossComparisonEntity(ResultSlideConfiguration resultConfig)
        {
            Matriz = new Dictionary<AnswerEntity, Dictionary<AnswerEntity, double>>();

            this._resultConfig = resultConfig;

            var raiz = resultConfig.SelectedQuestions[0];
            var qRaizConfig = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(raiz.QuestionRelation.Id);

            foreach (var a in qRaizConfig.Answers)
            {
                this.Matriz.Add(a, new Dictionary<Questions.Data.AnswerEntity, double>());
            }
            var hojas = resultConfig.SelectedQuestions[1];
            var qHojasConfig = Globals.ThisAddIn.Session.GetQuestionSlideConfiguration(hojas.QuestionRelation.Id);

            foreach (var r in this.Matriz.Keys)
            {
                //var votesForRaiz = r.GetPercentValue(Convert.ToInt32(resultConfig.Decimals));
                foreach (var hoja in qHojasConfig.Answers)
                {
                    //var votesForHoja = hoja.GetPercentValue(Convert.ToInt32(resultConfig.Decimals));
                    //var CrossVotes = (votesForRaiz + votesForHoja) / 2.0;

                    var CrossVotes = r.GetCoincidencesFor(hoja);

                    if (!this.Matriz[r].ContainsKey(hoja))
                        this.Matriz[r].Add(hoja, CrossVotes);
                }

                
            }

        }
        public Dictionary<AnswerEntity,Dictionary<AnswerEntity, double>> Matriz { get; set; }
    }
}

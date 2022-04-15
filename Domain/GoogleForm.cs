using GoogleFormsFiller.Domain;
using GoogleFormsFiller.Domain.QuestionTypes;
using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    class GoogleForm
    {
        private readonly List<IQuestion> _questions;

        public GoogleForm(string page)
        {
            var parser = new PublicLoadParser();
            var rawPublicLoad = parser.GetPublicLoad(page);
            var parsedPublicLoad = parser.ParsePublicLoad(rawPublicLoad);

            _questions = MakeQuestions(parsedPublicLoad[1][1] as SquareBracketsField);
        }

        public KeyValuePair<string, string>[] GetRandomAnswers() => 
            _questions.SelectMany(q => q.GetRandomAnswer()).ToArray();

        public override string ToString() => string.Join("\n\n******************\n\n", _questions.Select(q => q.ToString()));


        private List<IQuestion> MakeQuestions(SquareBracketsField field)
        {
            var result = new List<IQuestion>();

            foreach(var question in field.Fields)
            {
                var questionType = Enum.TryParse<QuestionType>(question[3].GetValue(), out var qType)
                    ? qType
                    : throw new ArgumentException($"Неизвестный тип вопроса: {question[3].GetValue()}");

                result.Add(MakeQuestion(questionType, question as SquareBracketsField));
            }

            return result;
        }

        private IQuestion MakeQuestion(QuestionType type, SquareBracketsField field) => type switch
        {
            QuestionType.TextLine => new TextLineQuestion(field),
            QuestionType.TextParagraph => new TextParagraphQuestion(field),
            QuestionType.SingleChoice => new SingleChoiceQuestion(field),
            QuestionType.DropDownList => new DropDownListQuestion(field),
            QuestionType.MultipleChoice => new MultipleChoiceQuestion(field),
            QuestionType.Scale => new ScaleQuestion(field),
            QuestionType.Grid => new GridQuestion(field),
            _ => throw new NotImplementedException(), //Студия упорно просила это сделать
        };
    }
}

﻿using GoogleFormsFiller.Domain;
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

        public KeyValuePair<string, string>[] GetRandomAnswers()
        { 
            return _questions.Select(q=>new KeyValuePair<string, string>(q.)) //TODO
        }

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
            QuestionType.TextParagraph => new TextParagraphQuestion(),
            QuestionType.SingleChoice => new SingleChoiceQuestion(),
            QuestionType.DropDownList => new DropDownListQuestion(),
            QuestionType.MultipleChoice => new MultipleChoiceQuestion(),
            QuestionType.Scale => new ScaleQuestion(),
            QuestionType.Grid => new GridQuestion(),
            _ => throw new NotImplementedException(), //Студия упорно просила это сделать
        };
    }
}

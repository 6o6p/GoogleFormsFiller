using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Domain.QuestionTypes
{
    class GridQuestion : IQuestion
    {
        private readonly QuestionType _type = QuestionType.Grid;
        private readonly string _question;

        private readonly IQuestion[] _questions;

        public GridQuestion(SquareBracketsField field)
        {
            _question = field[1].GetValue();

            _questions = (field[4] as SquareBracketsField).Fields.Select(f => MakeQuestion(f)).ToArray();
        }

        public KeyValuePair<string, string>[] GetRandomAnswer() =>
            _questions.SelectMany(q => q.GetRandomAnswer()).ToArray();

        public string GetPossibleAnswers() => 
            string.Join("\n", _questions.Select(q => q.GetPossibleAnswers()).ToArray());

        public string GetQuestion() => _question;

        private IQuestion MakeQuestion(IField field)
        {
            var sqField = field as SquareBracketsField;
            var question = field[3].GetValue();
            var type = field[11].GetValue();

            switch(type)
            {
                case "[0]":
                    return new SingleChoiceQuestion(question, sqField);
                case "[1]":
                    return new MultipleChoiceQuestion(question, sqField);
            };
            throw new ArgumentException($"Что-то пошло не так. Поле: {sqField.GetValue()}, {question}, {type}");
        }
    }
}

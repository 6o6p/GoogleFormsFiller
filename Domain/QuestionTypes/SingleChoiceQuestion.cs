using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Domain.QuestionTypes
{
    class SingleChoiceQuestion : IQuestion
    {
        private readonly QuestionType _type;
        private readonly string _entry;
        private readonly string _question;

        private readonly string[] _variants;

        public SingleChoiceQuestion(SquareBracketsField field)
        {
            _question = field[1].GetValue();

            _type = Enum.Parse<QuestionType>(field[3].GetValue());

            _entry = field[4][0][0].GetValue();

            _variants = (field[4][0][1] as SquareBracketsField).Fields.Select(f => (f as SquareBracketsField)[0].GetValue()).ToArray();
        }

        public KeyValuePair<string, string>[] GetRandomAnswer() => new[]
        {
            new KeyValuePair<string, string>($"entry.{_entry}", new RandomAnswerGenerator().SelectRandomVariant(_variants))
        };

        public string GetPossibleAnswers() => string.Join("\n", _variants.Select((v, i) => $"{i + 1}. {v}"));

        public string GetQuestion() => _question;
    }
}

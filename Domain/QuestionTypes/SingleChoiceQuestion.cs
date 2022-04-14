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
        private readonly QuestionType _type = QuestionType.SingleChoice;
        private readonly string _entry;
        private readonly string _question;

        private readonly string[] _variants;

        public SingleChoiceQuestion(SquareBracketsField field)
        {
            _question = field[1].GetValue();

            _entry = field[4][0][0].GetValue();

            _variants = (field[4][0][1] as SquareBracketsField).Fields.Select(f => f[0].GetValue()).ToArray();
        }

        public SingleChoiceQuestion(string question, SquareBracketsField field)
        {
            _question = question;

            _entry = field[0].GetValue();

            _variants = (field[1] as SquareBracketsField).Fields.Select(f => f[0].GetValue()).ToArray();
        }

        public KeyValuePair<string, string>[] GetRandomAnswer()
        {
            var rnd = new RandomAnswerGenerator();

            var response = rnd.GetRandomVariant(_variants);

            return response == string.Empty
                ? new[]
                {
                    new KeyValuePair<string, string>($"entry.{_entry}.other_option_response", rnd.GetRandomString(10)),
                    new KeyValuePair<string, string>($"entry.{_entry}", "__other_option__")
                }
                : new[]
                {
                    new KeyValuePair<string, string>($"entry.{_entry}", response)
                };
        }

        public string GetPossibleAnswers() => string.Join("\n", _variants.Select((v, i) => $"{i + 1}. {v}"));

        public string GetQuestion() => _question;
    }
}

using GoogleFormsFiller.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace GoogleFormsFiller.Domain.QuestionTypes
{
    class MultipleChoiceQuestion : BaseChoiсeQuestion
    {
        private readonly QuestionType _type = QuestionType.MultipleChoice;

        public MultipleChoiceQuestion(SquareBracketsField field) : base(field) { }

        public MultipleChoiceQuestion(string question, SquareBracketsField field)
        {
            _question = question;

            _entry = field[0].GetValue();

            _variants = (field[1] as SquareBracketsField).Fields.Select(f => f[0].GetValue()).ToArray();
        }

        public override KeyValuePair<string, string>[] GetRandomAnswer()
        {
            var rnd = new RandomAnswerGenerator();
            var result = new List<KeyValuePair<string, string>>();
            foreach(var variant in _variants)
            {
                if (rnd.Chosen())
                {
                    var response = variant == string.Empty
                    ? new[]
                    {
                        new KeyValuePair<string, string>($"entry.{_entry}.other_option_response", rnd.GetRandomString(10)),
                        new KeyValuePair<string, string>($"entry.{_entry}", "__other_option__")
                    }
                    : new[]
                    {
                        new KeyValuePair<string, string>($"entry.{_entry}", variant)
                    };
                    result.AddRange(response);
                }
            }

            return result.ToArray();
        }
    }
}

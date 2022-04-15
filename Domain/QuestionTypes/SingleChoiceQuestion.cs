using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Domain.QuestionTypes
{
    class SingleChoiceQuestion : BaseChoiсeQuestion
    {
        private readonly QuestionType _type = QuestionType.SingleChoice;

        public SingleChoiceQuestion(SquareBracketsField field) : base(field) { }

        public SingleChoiceQuestion(string question, SquareBracketsField field) 
        {
            _question = question;

            _entry = field[0].GetValue();

            _variants = (field[1] as SquareBracketsField).Fields.Select(f => f[0].GetValue()).ToArray();
        }

        public override KeyValuePair<string, string>[] GetRandomAnswer()
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
    }
}

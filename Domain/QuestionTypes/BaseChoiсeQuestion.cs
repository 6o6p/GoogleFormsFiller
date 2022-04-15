using GoogleFormsFiller.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace GoogleFormsFiller.Domain.QuestionTypes
{
    abstract class BaseChoiсeQuestion : IQuestion
    {
        private protected string _entry;
        private protected string _question;
        private protected string[] _variants;

        public BaseChoiсeQuestion() { }

        public BaseChoiсeQuestion(SquareBracketsField field)
        {
            _question = field[1].GetValue();

            _entry = field[4][0][0].GetValue();

            _variants = (field[4][0][1] as SquareBracketsField).Fields.Select(f => f[0].GetValue()).ToArray();
        }

        public virtual KeyValuePair<string, string>[] GetRandomAnswer() => new[]
        {
            new KeyValuePair<string, string>($"entry.{_entry}", new RandomAnswerGenerator().GetRandomVariant(_variants))
        };

        public virtual string GetPossibleAnswers() => string.Join("\n", _variants.Select((v, i) => $"{i + 1}. {v}"));

        public string GetQuestion() => _question;
    }
}

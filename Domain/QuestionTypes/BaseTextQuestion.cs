using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Domain.QuestionTypes
{
    abstract class BaseTextQuestion : IQuestion
    {
        private protected string _entry;
        private protected string _question;

        public BaseTextQuestion(SquareBracketsField field)
        {
            _question = field[1].GetValue();

            _entry = field[4][0][0].GetValue();
        }

        public string GetPossibleAnswers() => "Пеши чо хошь. Ограничений нет.";

        public string GetQuestion() => _question;

        public KeyValuePair<string, string>[] GetRandomAnswer() => new[]
        {
            new KeyValuePair<string, string>($"entry.{_entry}", new RandomAnswerGenerator().GetRandomString(13))
        };
    }
}

using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Domain.QuestionTypes
{
    class TextParagraphQuestion : IQuestion
    {
        private readonly QuestionType _type;
        private readonly string _entry;
        private readonly string _question;

        public TextParagraphQuestion(SquareBracketsField field)
        {
            _question = field[1].GetValue();

            _type = Enum.Parse<QuestionType>(field[3].GetValue());

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

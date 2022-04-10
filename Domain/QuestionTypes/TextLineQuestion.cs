using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Domain.QuestionTypes
{
    class TextLineQuestion : IQuestion
    {
        private readonly QuestionType _type;
        private string _entry { get; }
        private string _question { get; }

        public TextLineQuestion(SquareBracketsField field)
        {
            _question = field[1].GetValue();

            _type = Enum.Parse<QuestionType>(field[3].GetValue());

            _entry = field[4][0][0].GetValue();
        }

        public string GetPossibleAnswers() => "Пеши чо хошь. Ограничений нет.";

        public string GetEntries() => _entry;

        public string GetQuestion() => _question;
    }
}

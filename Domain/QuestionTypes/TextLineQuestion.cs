using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Domain.QuestionTypes
{
    class TextLineQuestion : BaseTextQuestion
    {
        private readonly QuestionType _type = QuestionType.TextLine;

        public TextLineQuestion(SquareBracketsField field) : base(field) { }
    }
}

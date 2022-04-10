using GoogleFormsFiller.Domain;
using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    class GoogleForm
    {
        private readonly List<IQuestion> _questions;

        public GoogleForm(string page)
        {
            var rawPublicLoad = page.Split("var FB_PUBLIC_LOAD_DATA_ = ")[1];

            var publicLoad = new StringBuilder();
            var openingBrackets = new Stack<char>();

            foreach (var letter in rawPublicLoad)
            {
                if (letter == '[')
                    openingBrackets.Push(letter);

                publicLoad.Append(letter);

                if (letter == ']')
                    openingBrackets.Pop();

                if (openingBrackets.Count == 0)
                    break;
            }

            var parsedPublicLoad = new PublicLoadParser(publicLoad.ToString()).Result;

            _questions = MakeQuestions(parsedPublicLoad[1][1] as SquareBracketsField);
        }

        private List<IQuestion> MakeQuestions(SquareBracketsField field)
        {
            var result = new List<IQuestion>();
            foreach(var question in field.Fields)
            {
                var questionType = Enum.TryParse<QuestionType>(question[3].GetValue(), out var q)
                    ? q
                    : throw new ArgumentException($"Неизвестный тип вопроса: {question[3].GetValue()}");


            }
            return result;
        }
    }
}

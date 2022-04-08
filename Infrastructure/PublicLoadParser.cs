using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Infrastructure
{
    class PublicLoadParser
    {
        public string ParsePublicLoadFromPage(string page)
        {
            var rawPublicLoad = page.Split("var FB_PUBLIC_LOAD_DATA_ = ")[1];

            var squareBracketCounter = 2;
            var temp = string.Empty;

            for (var i = 0; i < rawPublicLoad.Length; i++) 
            {
                if (rawPublicLoad[i] == '[')
                    squareBracketCounter--;

                if (squareBracketCounter < 0 && rawPublicLoad[i] == '[')
                {
                    temp = rawPublicLoad.Substring(i);
                    break;
                }
            }

            var question = new StringBuilder();
            var openingBrackets = new Stack<char>();
            var questions = new List<string>();
            foreach (var letter in temp)
            {
                if (openingBrackets.Count != 0)
                    question.Append(letter);

                if(letter == '[')
                    openingBrackets.Push(letter);
                if (letter == ']')
                    openingBrackets.Pop();
                if (openingBrackets.Count == 0)
                    break;



                if (openingBrackets.Count == 1 && question.Length != 0)
                {
                    questions.Add(question.ToString());
                    question.Clear();
                }
            }

            return temp;
        }

        
    }
}

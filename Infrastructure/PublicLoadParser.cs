using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Infrastructure
{
    class PublicLoadParser
    {
        public string GetPublicLoad(string page)
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

            return publicLoad.ToString();
        }

        public SquareBracketsField ParsePublicLoad(string str) => ParseField(str, 0).field;

        private (SquareBracketsField field, int finish) ParseField(string str, int start)
        {
            var result = new SquareBracketsField();
            var finish = start;

            for (var i = start + 1; i < str.Length; i++)
            {
                if(str[i] == '[')
                {
                    var otherField = ParseField(str, i);
                    result.Fields.Add(otherField.field);
                    i = otherField.finish;
                    continue;
                }

                if(str[i] == '"')
                {
                    var otherField = ParseQuotedField(str, i + 1);
                    result.Fields.Add(otherField.field);
                    i = otherField.finish;
                    continue;
                }

                if (str[i] == ']')
                {
                    finish = i;
                    break;
                }

                if (str[i] == ',')
                    continue;

                var textField = ParseTextField(str, i);
                result.Fields.Add(textField.field);
                i = textField.finish;
            }

            return (result,finish);
        }

        private static (TextField field, int finish) ParseTextField(string str, int start)
        {
            var result = new StringBuilder();
            var finish = start;
            for (var i = start; i < str.Length; i++)
            {
                if (str[i] == ',' || str[i] == ']')
                    break;
                result.Append(str[i]);
                finish++;
            }
            return (new TextField(result.ToString()), finish - 1);
        }

        private static (TextField field, int finish) ParseQuotedField(string str, int start)
        {
            var result = new StringBuilder();
            var skippedSymbolsCounter = 0;
            var finish = start;
            for (var i = start; i < str.Length; i++)
            {
                if (str[i] == '"')
                {
                    break;
                }

                if (str[i] == '\\')
                {
                    skippedSymbolsCounter++;
                    i++;
                }

                result.Append(str[i]);
                finish++;
            }
            return (new TextField(result.ToString()), finish + skippedSymbolsCounter);
        }
    }
}

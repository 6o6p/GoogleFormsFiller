using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Infrastructure
{
    class RandomAnswerGenerator
    {
        public string GenerateRandomString(int count)
        {
            var rnd = new Random();

            var result = new StringBuilder();

            for (var i = 0; i < count; i++)
                result.Append((char)rnd.Next(33, 127));

            return result.ToString();
        }

        public string SelectRandomVariant(string[] variants)
        {
            var rnd = new Random();

            var answer = variants[rnd.Next(0, variants.Length)];

            return answer == string.Empty
                ? GenerateRandomString(10)
                : answer;
        }
    }
}

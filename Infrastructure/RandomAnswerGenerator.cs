using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Infrastructure
{
    class RandomAnswerGenerator
    {
        private readonly Random _rnd = new Random();

        public string GetRandomString(int count)
        {
            var result = new StringBuilder();

            for (var i = 0; i < count; i++)
                result.Append((char)_rnd.Next(33, 127));

            return result.ToString();
        }

        public string GetRandomVariant(string[] variants) => variants[_rnd.Next(0, variants.Length)];

        public bool Chosen() => _rnd.Next(0, 2) == 0 ? true : false;
    }
}

using GoogleFormsFiller.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    class GoogleFormQuestion
    {
        private readonly QuestionType _type;
        private readonly RestrictionType? _restriction;
        public uint? Entry { get; }
        public string Question { get; }

        public string[] Variants { get; }
        public GoogleFormQuestion[] Questions { get; }

        public GoogleFormQuestion(string str)
        {
            var parser = new PublicLoadParser(str);


        }


    }
}

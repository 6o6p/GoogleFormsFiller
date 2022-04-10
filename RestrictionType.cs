using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    enum RestrictionType 
    {
        MustContain = 100,
        MustNotContain = 101,
        MustBeEmail = 102,
        MustBeUrl = 103,
        LimitedLength = 203,
    }
}

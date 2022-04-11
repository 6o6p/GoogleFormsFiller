using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Domain
{
    public interface IQuestion
    {
        string GetQuestion();
        string GetEntries();
        string GetPossibleAnswers();
        string GetRandomAnswer();
    }
}

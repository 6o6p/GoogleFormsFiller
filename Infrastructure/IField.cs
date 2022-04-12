using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Infrastructure
{
    public interface IField
    {
        IField this[int index] { get; }
        string GetValue();
    }
}

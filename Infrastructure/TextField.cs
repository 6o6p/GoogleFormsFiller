using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Infrastructure
{
    class TextField : IField
    {
        private readonly string _value;

        public TextField(string str)
        {
            _value = str;
        }

        public IField this[int index]
        {
            get
            {
                if (index > 0)
                    throw new IndexOutOfRangeException();
                return this;
            }
        }

        public string GetValue() => _value;
    }
}

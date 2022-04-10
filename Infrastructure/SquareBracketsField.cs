using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Infrastructure
{
    class SquareBracketsField : IField
    {
        public List<IField> Fields { get; set; }

        public SquareBracketsField()
        {
            Fields = new List<IField>();
        }

        public string GetValue() => $"[{string.Join(',', Fields.Select(f => f.GetValue()).ToArray())}]";

        public IField this[int index]
        {
            get => Fields[index];
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller
{
    enum QuestionType
    {
        [Description("Текст (строка)")]
        TextLine = 0,
        [Description("Текст (абзац)")]
        TextParagraph = 1,
        [Description("Один из списка")]
        SingleChoice = 2,
        [Description("Раскрывающийся список")]
        DropDownList = 3,
        [Description("Несколько из списка")]
        MultipleChoice = 4,
        [Description("Шкала")]
        Scale = 5,
        [Description("Сетка")]
        Grid = 7
    }
}

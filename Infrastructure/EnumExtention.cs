using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoogleFormsFiller.Infrastructure
{
    static class EnumExtention
    {
        public static string GetDescription(this Enum item) =>
            item.GetType().GetMember(item.ToString())[0].GetCustomAttribute<DescriptionAttribute>()?.Description
            ?? "Описание отсутствует";
    }
}

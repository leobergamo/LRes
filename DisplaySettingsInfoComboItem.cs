using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRes
{
    internal class DisplaySettingsInfoComboItem
    {
        public string string_Text { get; set; } = string.Empty;
        public DisplaySettingsInfo? object_Value { get; set; }

        public override string ToString()
        {
            return string_Text;
        }
    }
}

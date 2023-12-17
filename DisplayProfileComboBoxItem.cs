using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRes
{
    internal class DisplayProfileComboBoxItem
    {
        public string string_text { get; set; } = string.Empty;
        public DisplayProfile? object_displayProfile { get; set; }

        public override string ToString()
        {
            return string_text;
        }
    }
}

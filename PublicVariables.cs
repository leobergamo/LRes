using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LRes
{
    internal class PublicVariables
    {
        public static DisplayProfile? Object_CurrentDisplayProfile;
        public static DisplayProfile? Object_SelectedDisplayProfile;
        public static String String_AppWorkingDirectory = Directory.GetParent(Application.ExecutablePath).FullName;
    }
}

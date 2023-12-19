using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRes
{
    internal class Log
    {

        public static void NOTICE(
            object object_message,
            [CallerMemberName] string string_memberName = "",
            [CallerFilePath] string string_fileName = "",
            [CallerLineNumber] int int_lineNumber = 0
        ) {
            string string_timeStamp = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            string string_appName = AppDomain.CurrentDomain.FriendlyName;

            Debug.WriteLine(
                "[ {0} ] [ NOTICE ] {1}({2}):{3} :: {4}",
                string_timeStamp,
                string_appName + " @ " + Path.GetFileName(string_fileName),
                int_lineNumber,
                string_memberName,
                object_message
            );

            Console.WriteLine(
                "[ {0} ] [ NOTICE ] {1}({2}):{3} :: {4}",
                string_timeStamp,
                string_appName + " @ " + Path.GetFileName(string_fileName),
                int_lineNumber,
                string_memberName,
                object_message
            );
        }






        public static void DEBUG(
            object object_message,
            [CallerMemberName] string string_memberName = "",
            [CallerFilePath] string string_fileName = "",
            [CallerLineNumber] int int_lineNumber = 0
        ) {
            string string_timeStamp = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            string string_appName = AppDomain.CurrentDomain.FriendlyName;

            Debug.WriteLine(
                "[ {0} ] [ DEBUG ] {1}({2}):{3} :: {4}",
                string_timeStamp,
                string_appName + " @ " + Path.GetFileName(string_fileName),
                int_lineNumber,
                string_memberName,
                object_message
            );

            Console.WriteLine(
                "[ {0} ] [ DEBUG ] {1}({2}):{3} :: {4}",
                string_timeStamp,
                string_appName + " @ " + Path.GetFileName(string_fileName),
                int_lineNumber,
                string_memberName,
                object_message
            );
        }






        public static void WARNING(
            object object_message,
            [CallerMemberName] string string_memberName = "",
            [CallerFilePath] string string_fileName = "",
            [CallerLineNumber] int int_lineNumber = 0
        ) {
            string string_timeStamp = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            string string_appName = AppDomain.CurrentDomain.FriendlyName;

            Debug.WriteLine(
                "[ {0} ] [ WARNING ] {1}({2}):{3} :: {4}",
                string_timeStamp,
                string_appName + " @ " + Path.GetFileName(string_fileName),
                int_lineNumber,
                string_memberName,
                object_message
            );

            Console.WriteLine(
                "[ {0} ] [ WARNING ] {1}({2}):{3} :: {4}",
                string_timeStamp,
                string_appName + " @ " + Path.GetFileName(string_fileName),
                int_lineNumber,
                string_memberName,
                object_message
            );
        }






        public static void ERROR(
            object object_message,
            [CallerMemberName] string string_memberName = "",
            [CallerFilePath] string string_fileName = "",
            [CallerLineNumber] int int_lineNumber = 0
        )
        {
            string string_timeStamp = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            string string_appName = AppDomain.CurrentDomain.FriendlyName;

            Debug.WriteLine(
                "[ {0} ] [ ERROR ] {1}({2}):{3} :: {4}",
                string_timeStamp,
                string_appName + " @ " + Path.GetFileName(string_fileName),
                int_lineNumber,
                string_memberName,
                object_message
            );

            Console.WriteLine(
                "[ {0} ] [ ERROR ] {1}({2}):{3} :: {4}",
                string_timeStamp,
                string_appName + " @ " + Path.GetFileName(string_fileName),
                int_lineNumber,
                string_memberName,
                object_message
            );
        }


    }
}

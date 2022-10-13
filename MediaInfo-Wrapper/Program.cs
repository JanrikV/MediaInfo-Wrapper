using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Text;

namespace MediaInfoWrapper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static public string UpperCaseFirstCharacter(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return string.Format(
                    "{0}{1}",
                    text.Substring(0, 1).ToUpper(),
                    text.Substring(1));
            }

            return text;
        }
    }
}

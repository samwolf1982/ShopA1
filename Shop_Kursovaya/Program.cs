using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Shop_Kursovaya
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutentificationForm frm = new AutentificationForm();
            frm.ShowDialog();

           if (frm.DialogResult == DialogResult.OK)
               Application.Run(new FormARM(frm.usr));
         

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XHE._Helper.Tools.GUI
{
    public class ShowMessage
    {
        /// <summary>
        /// Показать информационное сообщение
        /// </summary>
        /// <param name="sText">текст сообщения</param>
        /// <param name="sCaption">заголовок сообщения</param>
        public static void  ShowInfoMessage(string sText, string sCaption)
        {
            MessageBox.Show(sText, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Показать информационное сообщение
        /// </summary>
        /// <param name="sText">заголовок сообщения</param>
        public static void ShowInfoMessage(string sText)
        {
            ShowInfoMessage(sText, "Information");
        }
        /// <summary>
        /// показать сообщение с предупреждением
        /// </summary>
        /// <param name="sText">текст сообщения</param>
        /// <param name="sCaption">загаловок сообщения</param>
        public static void ShowWarningMessage(string sText, string sCaption)
        {
           MessageBox.Show(sText, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// показать сообщение с предупреждением в зависимости от языка
        /// </summary>
        /// <param name="sText">текст сообщения</param>
        public static void ShowWarningMessage(string sText)
        {
            ShowWarningMessage(sText, "Warning");
        }
    }
}

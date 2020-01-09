using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XHE._Helper.Tools.GUI
{
    public class ShowMessage
    {
        /// <summary>
        /// �������� �������������� ���������
        /// </summary>
        /// <param name="sText">����� ���������</param>
        /// <param name="sCaption">��������� ���������</param>
        public static void  ShowInfoMessage(string sText, string sCaption)
        {
            MessageBox.Show(sText, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// �������� �������������� ���������
        /// </summary>
        /// <param name="sText">��������� ���������</param>
        public static void ShowInfoMessage(string sText)
        {
            ShowInfoMessage(sText, "Information");
        }
        /// <summary>
        /// �������� ��������� � ���������������
        /// </summary>
        /// <param name="sText">����� ���������</param>
        /// <param name="sCaption">��������� ���������</param>
        public static void ShowWarningMessage(string sText, string sCaption)
        {
           MessageBox.Show(sText, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// �������� ��������� � ��������������� � ����������� �� �����
        /// </summary>
        /// <param name="sText">����� ���������</param>
        public static void ShowWarningMessage(string sText)
        {
            ShowWarningMessage(sText, "Warning");
        }
    }
}

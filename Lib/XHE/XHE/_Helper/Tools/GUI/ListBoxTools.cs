using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XHE._Helper.Tools.GUI
{
    /// <summary>
    /// ����������� �� ������ � ��������
    /// </summary>
    public class ListBoxTools
    {
        #region ������ � �������
        /// <summary>
        /// ���� ������ ����� � ���������
        /// </summary>
        /// <param name="lbList">��������</param>
        /// <param name="iSelected">������</param>
        static public void SetSelected(ListBox lbList,int iSelected)
        {
            // �������� � �����������
            if (iSelected >= lbList.Items.Count)
                iSelected = lbList.Items.Count - 1;
            // ��������
            lbList.SelectedIndex = iSelected;
        }
        #endregion
    }

    #region ��������������� ������� ��� �������� ���������
    /// <summary>
    /// ������ ��� �������� ����� � �������� � ���������
    /// </summary>
    public class LbItems : object
    {
        // ������
        public string m_sItem;
        // ������ 
        public int m_iIndex;

        // �����������
        public LbItems(string sItem, int iIndex)
        {
            m_sItem = sItem;
            m_iIndex = iIndex;
        }
        // ��������� �������������
        public override string ToString()
        {
            return m_sItem;
        }
    };
    #endregion
}

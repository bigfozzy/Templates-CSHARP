using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XHE._Helper.Tools.GUI
{
    /// <summary>
    /// инструменты по работе с листбокс
    /// </summary>
    public class ListBoxTools
    {
        #region работа с выбором
        /// <summary>
        /// умно задать выбор в листбоксе
        /// </summary>
        /// <param name="lbList">листбокс</param>
        /// <param name="iSelected">индекс</param>
        static public void SetSelected(ListBox lbList,int iSelected)
        {
            // проверим и пеерсчитаем
            if (iSelected >= lbList.Items.Count)
                iSelected = lbList.Items.Count - 1;
            // зададаим
            lbList.SelectedIndex = iSelected;
        }
        #endregion
    }

    #region вспомогательные объекты для хранения элементов
    /// <summary>
    /// объект для хранения строк с индексом в листбоксе
    /// </summary>
    public class LbItems : object
    {
        // строка
        public string m_sItem;
        // индекс 
        public int m_iIndex;

        // конструктор
        public LbItems(string sItem, int iIndex)
        {
            m_sItem = sItem;
            m_iIndex = iIndex;
        }
        // строковое представление
        public override string ToString()
        {
            return m_sItem;
        }
    };
    #endregion
}

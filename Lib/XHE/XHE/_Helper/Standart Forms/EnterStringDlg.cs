using System;
using System.Windows.Forms;

namespace XHE._Helper.Standart_Forms
{
    /// <summary>
    /// стандартный диалог ввода номера
    /// </summary>
    public partial class EnterStringDlg : Form
    {
        /// заголовок диалога
        private string m_sCaption;

        // конструктор
        public EnterStringDlg(string sCaption, string _default)
        {
            InitializeComponent();
            
            m_sCaption = sCaption;
            m_tbString.Text = _default;
            //m_tbString.Text = Application.CommonAppDataRegistry.GetValue(sRegName, "") as string;
        }

        // OK
        private void m_btnOK_Click(object sender, EventArgs e)
        {
            //Application.CommonAppDataRegistry.SetValue(m_sRegName, m_tbString.Text);
        }

        // «агрузка формы
        private void EnterNumberDlg_Load(object sender, EventArgs e)
        {
            Text = m_sCaption;
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
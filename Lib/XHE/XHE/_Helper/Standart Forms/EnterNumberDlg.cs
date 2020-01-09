using System;
using System.Windows.Forms;

namespace XHE._Helper.Standart_Forms
{
    /// <summary>
    /// стандартный диалог ввода номера
    /// </summary>
    public partial class EnterNumberDlg : Form
    {
        /// имя в реестре для хранения предыдущего ввода
        private string m_sRegName;

        /// заголовок диалога
        private string m_sCaption;

        // конструктор
        public EnterNumberDlg(string sCaption, string sRegName)
        {
            InitializeComponent();

            m_sRegName = sRegName;
            m_sCaption = sCaption;
            m_tbNumber.Text = Application.CommonAppDataRegistry.GetValue(sRegName, "1") as string;
        }

        // OK
        private void m_btnOK_Click(object sender, EventArgs e)
        {
            Application.CommonAppDataRegistry.SetValue(m_sRegName, m_tbNumber.Text);
        }

        // Загрузка формы
        private void EnterNumberDlg_Load(object sender, EventArgs e)
        {
            Text = m_sCaption;
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
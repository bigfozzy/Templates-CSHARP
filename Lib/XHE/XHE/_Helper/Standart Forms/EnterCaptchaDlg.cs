using System;
using System.Windows.Forms;

namespace XHE._Helper.Standart_Forms
{
    /// <summary>
    /// стандартный диалог ввода номера
    /// </summary>
    public partial class EnterCaptchaDlg : Form
    {
        /// им€ в реестре дл€ хранени€ предыдущего ввода
        private string m_sRegName;

        /// заголовок диалога
        private string m_sCaption;

        /// заголовок диалога
        private string m_sCapchaUrl;

        // конструктор
        public EnterCaptchaDlg(string sCaption, string sRegName, string sCapchaUrl)
        {
            InitializeComponent();

            m_sCapchaUrl = sCapchaUrl;
            m_sRegName = sRegName;
            m_sCaption = sCaption;
        }

        // OK
        private void m_btnOK_Click(object sender, EventArgs e)
        {
            Application.CommonAppDataRegistry.SetValue(m_sRegName, m_tbCapcha.Text);
        }

        // «агрузка формы
        private void EnterCaptchaDlg_Load(object sender, EventArgs e)
        {
            Text = m_sCaption;
            m_tbCapcha.Text = Application.CommonAppDataRegistry.GetValue(m_sRegName, "") as string;
            m_wbShowCapcha.Navigate(m_sCapchaUrl);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
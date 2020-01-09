using System;
using System.Windows.Forms;

namespace XHE._Helper.Standart_Forms
{
    /// <summary>
    /// диалог ввода логина и пароля
    /// </summary>
    public partial class LoginAndPasswordForm : Form
    {
        /// <summary>
        /// логин
        /// </summary>
        public string Login;

        /// <summary>
        /// пароль
        /// </summary>
        public string Password;

        /// <summary>
        /// конструктjh
        /// </summary>
        public LoginAndPasswordForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// форма загрузилась
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterLoginAndPasswordDlg_Load(object sender, EventArgs e)
        {
            m_loginTextBox.Text = Login;
            m_passwordTextBox.Text = Password;
        }

        /// <summary>
        /// человек ввел логин и пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            Login = m_loginTextBox.Text;
            Password = m_passwordTextBox.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
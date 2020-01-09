using System;
using System.Windows.Forms;

namespace XHE._Helper.Standart_Forms
{
    /// <summary>
    /// ������ ����� ������ � ������
    /// </summary>
    public partial class LoginAndPasswordForm : Form
    {
        /// <summary>
        /// �����
        /// </summary>
        public string Login;

        /// <summary>
        /// ������
        /// </summary>
        public string Password;

        /// <summary>
        /// ���������jh
        /// </summary>
        public LoginAndPasswordForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����� �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterLoginAndPasswordDlg_Load(object sender, EventArgs e)
        {
            m_loginTextBox.Text = Login;
            m_passwordTextBox.Text = Password;
        }

        /// <summary>
        /// ������� ���� ����� � ������
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
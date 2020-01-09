using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace XHE.Helper.GUI
{
    /// <summary>
    /// сплеш-скрин диалог
    /// </summary>
    public partial class SplashForm : Form
    {
        #region Создание
        
        /// конструктор
        public SplashForm(string title)
        {
            InitializeComponent();

            labelTitle.Text = title;
            labelTitle.BackColor = Color.Transparent;
            

            label.Text = "Warning: This computer program is protected by copyright law and international treaties.\nUnauthorized reproduction or distribution of this program, or any portion of it, may result in severe \ncivil and criminal penalties, and will be prosecuted to the maximum extent possible under the law.";
    
            label.Refresh();
            labelTitle.Refresh();            
        }
        
        /// загрузка
        private void SplashForm_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Обработчики

        #endregion

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            if (m_pbProgress.Value == m_pbProgress.Maximum)
            {
                m_Timer.Enabled = false;
                Close();
                return;
            }
            else
                m_pbProgress.Value += 100;
        }

        private void m_pbProgress_Click(object sender, EventArgs e)
        {

        }

        private void SplashForm_Shown(object sender, EventArgs e)
        {
            m_Timer.Enabled = true;
        }

    }
}
using System;
using System.Windows.Forms;
using XHE._Helper.Tools.File;

namespace XHE.Helper.GUI
{
    /// <summary>
    /// диалог просмотра текстовых файлов
    /// </summary>
    public partial class EditTextFileDlg : Form
    {
        #region переменные
        
        // путь к файлу 
        private string m_sFilePath=null;
        // описание операции
        private string m_sDescribtion = null;
        
        
        #endregion

        #region инициализация
                        
        // конструктор
        public EditTextFileDlg(string sFilePath,string sDesribtion)
        {
            // инитим компонеты 
            InitializeComponent();

            //  перемнные
            m_sDescribtion = sDesribtion;
            m_sFilePath = sFilePath;
        }
        
        // загрузка формы
        private void ViewSavedUrlsDlg_Load(object sender, EventArgs e)
        {
            // заполнить текстбокс списком уров
            FillEdit();

            // зададим заголовок
            Text = m_sDescribtion;
        }

        #endregion

        #region сервисные функции
    
        // заполнить тектсбокс спиком урлов + стат
        public void FillEdit()
        {
            // текст
            m_tbUrls.Text = TextFileTools.ReadFile(m_sFilePath);
            
            // статистика
            m_lblUrlsCount.Text = "Lines count :" + TextFileTools.GetLinesCount(m_sFilePath).ToString();
        }
        
        #endregion

        #region реакция на кнопки

        // скопировать
        private void m_btnCopy_Click(object sender, EventArgs e)
        {
            // скопировать
            if (m_lblUrlsCount.Text!="")
                Clipboard.SetText(m_tbUrls.Text);
        }
        
        // вставить
        private void m_btnPaste_Click(object sender, EventArgs e)
        {
            // вставить
            m_tbUrls.Text = Clipboard.GetText();
        }
        
        // сохранить 
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            // сохарнить
            TextFileTools.WriteFile(m_sFilePath, m_tbUrls.Text);
        }
        // закрыть диалог
        private void m_btnClose_Click(object sender, EventArgs e)
        {
            // спрятоать
            Hide();
        }
        
        #endregion

    }
}
using System;
using System.Windows.Forms;
using XHE._Helper.Tools.File;

namespace XHE.Helper.GUI
{
    /// <summary>
    /// ������ ��������� ��������� ������
    /// </summary>
    public partial class EditTextFileDlg : Form
    {
        #region ����������
        
        // ���� � ����� 
        private string m_sFilePath=null;
        // �������� ��������
        private string m_sDescribtion = null;
        
        
        #endregion

        #region �������������
                        
        // �����������
        public EditTextFileDlg(string sFilePath,string sDesribtion)
        {
            // ������ ��������� 
            InitializeComponent();

            //  ���������
            m_sDescribtion = sDesribtion;
            m_sFilePath = sFilePath;
        }
        
        // �������� �����
        private void ViewSavedUrlsDlg_Load(object sender, EventArgs e)
        {
            // ��������� ��������� ������� ����
            FillEdit();

            // ������� ���������
            Text = m_sDescribtion;
        }

        #endregion

        #region ��������� �������
    
        // ��������� ��������� ������ ����� + ����
        public void FillEdit()
        {
            // �����
            m_tbUrls.Text = TextFileTools.ReadFile(m_sFilePath);
            
            // ����������
            m_lblUrlsCount.Text = "Lines count :" + TextFileTools.GetLinesCount(m_sFilePath).ToString();
        }
        
        #endregion

        #region ������� �� ������

        // �����������
        private void m_btnCopy_Click(object sender, EventArgs e)
        {
            // �����������
            if (m_lblUrlsCount.Text!="")
                Clipboard.SetText(m_tbUrls.Text);
        }
        
        // ��������
        private void m_btnPaste_Click(object sender, EventArgs e)
        {
            // ��������
            m_tbUrls.Text = Clipboard.GetText();
        }
        
        // ��������� 
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            // ���������
            TextFileTools.WriteFile(m_sFilePath, m_tbUrls.Text);
        }
        // ������� ������
        private void m_btnClose_Click(object sender, EventArgs e)
        {
            // ���������
            Hide();
        }
        
        #endregion

    }
}
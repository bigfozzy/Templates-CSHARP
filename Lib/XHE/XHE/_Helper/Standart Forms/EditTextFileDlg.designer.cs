namespace XHE.Helper.GUI
{
    partial class EditTextFileDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTextFileDlg));
            this.m_tbUrls = new System.Windows.Forms.TextBox();
            this.m_lblUrlsCount = new System.Windows.Forms.Label();
            this.m_btnClose = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnPaste = new System.Windows.Forms.Button();
            this.m_btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_tbUrls
            // 
            resources.ApplyResources(this.m_tbUrls, "m_tbUrls");
            this.m_tbUrls.Name = "m_tbUrls";
            // 
            // m_lblUrlsCount
            // 
            resources.ApplyResources(this.m_lblUrlsCount, "m_lblUrlsCount");
            this.m_lblUrlsCount.Name = "m_lblUrlsCount";
            // 
            // m_btnClose
            // 
            resources.ApplyResources(this.m_btnClose, "m_btnClose");
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnClose.FlatAppearance.BorderSize = 0;
            this.m_btnClose.Image = global::XHE.Properties.Resources.delete2;
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.UseVisualStyleBackColor = true;
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // m_btnSave
            // 
            resources.ApplyResources(this.m_btnSave, "m_btnSave");
            this.m_btnSave.FlatAppearance.BorderSize = 0;
            this.m_btnSave.Image = global::XHE.Properties.Resources.disk_blue;
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnPaste
            // 
            resources.ApplyResources(this.m_btnPaste, "m_btnPaste");
            this.m_btnPaste.FlatAppearance.BorderSize = 0;
            this.m_btnPaste.Name = "m_btnPaste";
            this.m_btnPaste.UseVisualStyleBackColor = true;
            this.m_btnPaste.Click += new System.EventHandler(this.m_btnPaste_Click);
            // 
            // m_btnCopy
            // 
            resources.ApplyResources(this.m_btnCopy, "m_btnCopy");
            this.m_btnCopy.FlatAppearance.BorderSize = 0;
            this.m_btnCopy.Name = "m_btnCopy";
            this.m_btnCopy.UseVisualStyleBackColor = true;
            this.m_btnCopy.Click += new System.EventHandler(this.m_btnCopy_Click);
            // 
            // EditTextFileDlg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnClose);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.m_btnPaste);
            this.Controls.Add(this.m_btnCopy);
            this.Controls.Add(this.m_lblUrlsCount);
            this.Controls.Add(this.m_tbUrls);
            this.Name = "EditTextFileDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ViewSavedUrlsDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_tbUrls;
        private System.Windows.Forms.Label m_lblUrlsCount;
        private System.Windows.Forms.Button m_btnCopy;
        private System.Windows.Forms.Button m_btnPaste;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnClose;
    }
}
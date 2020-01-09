namespace XHE._Helper.Standart_Forms
{
    partial class LoginAndPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginAndPasswordForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_loginTextBox = new System.Windows.Forms.TextBox();
            this.m_passwordTextBox = new System.Windows.Forms.TextBox();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // m_loginTextBox
            // 
            resources.ApplyResources(this.m_loginTextBox, "m_loginTextBox");
            this.m_loginTextBox.Name = "m_loginTextBox";
            // 
            // m_passwordTextBox
            // 
            resources.ApplyResources(this.m_passwordTextBox, "m_passwordTextBox");
            this.m_passwordTextBox.Name = "m_passwordTextBox";
            // 
            // m_btnOk
            // 
            resources.ApplyResources(this.m_btnOk, "m_btnOk");
            this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOk.FlatAppearance.BorderSize = 0;
            this.m_btnOk.Image = global::XHE.Properties.Resources.disk_blue;
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnCancel
            // 
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.FlatAppearance.BorderSize = 0;
            this.m_btnCancel.Image = global::XHE.Properties.Resources.delete2;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // LoginAndPasswordForm
            // 
            this.AcceptButton = this.m_btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_passwordTextBox);
            this.Controls.Add(this.m_loginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginAndPasswordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.EnterLoginAndPasswordDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_loginTextBox;
        private System.Windows.Forms.TextBox m_passwordTextBox;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOk;
    }
}
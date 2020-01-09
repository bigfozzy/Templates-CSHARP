namespace XHE.Helper.GUI
{
    partial class SplashForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.m_pbProgress = new System.Windows.Forms.ProgressBar();
            this.m_Timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(501, 13);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.UseCompatibleTextRendering = true;
            // 
            // m_pbProgress
            // 
            this.m_pbProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(222)))), ((int)(((byte)(224)))));
            this.m_pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pbProgress.ForeColor = System.Drawing.Color.LightBlue;
            this.m_pbProgress.Location = new System.Drawing.Point(0, 246);
            this.m_pbProgress.MarqueeAnimationSpeed = 1;
            this.m_pbProgress.Maximum = 5000;
            this.m_pbProgress.Name = "m_pbProgress";
            this.m_pbProgress.Size = new System.Drawing.Size(501, 13);
            this.m_pbProgress.Step = 50;
            this.m_pbProgress.TabIndex = 0;
            this.m_pbProgress.Click += new System.EventHandler(this.m_pbProgress_Click);
            // 
            // m_Timer
            // 
            this.m_Timer.Tick += new System.EventHandler(this.m_Timer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::XHE.Properties.Resources.about;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 233);
            this.panel1.TabIndex = 2;
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(222)))), ((int)(((byte)(224)))));
            this.label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(0, 195);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(501, 51);
            this.label.TabIndex = 3;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 259);
            this.Controls.Add(this.label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_pbProgress);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " loading ...";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            this.Shown += new System.EventHandler(this.SplashForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Timer m_Timer;
        private System.Windows.Forms.ProgressBar m_pbProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label;
    }
}
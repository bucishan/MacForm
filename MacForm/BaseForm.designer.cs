namespace MacForm
{
    partial class BaseForm
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
            this.btnRestore = new MacForm.Controls.UCPointButton();
            this.btnMin = new MacForm.Controls.UCPointButton();
            this.btnClose = new MacForm.Controls.UCPointButton();
            this.SuspendLayout();
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.Transparent;
            this.btnRestore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(183)))), ((int)(((byte)(85)))));
            this.btnRestore.BorderWidth = 1;
            this.btnRestore.Enabled = false;
            this.btnRestore.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(204)))), ((int)(((byte)(66)))));
            this.btnRestore.FillDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.btnRestore.FillDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(124)))), ((int)(((byte)(23)))));
            this.btnRestore.FillEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(180)))), ((int)(((byte)(52)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.ForeColor = System.Drawing.Color.Transparent;
            this.btnRestore.IconFlagCode = 61660;
            this.btnRestore.IconFlagColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRestore.Location = new System.Drawing.Point(60, 10);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(17, 17);
            this.btnRestore.TabIndex = 0;
            this.btnRestore.Tag = "restore";
            this.btnRestore.Text = "ucPointButton1";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(184)))), ((int)(((byte)(82)))));
            this.btnMin.BorderWidth = 1;
            this.btnMin.Enabled = false;
            this.btnMin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnMin.FillDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.btnMin.FillDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(139)))), ((int)(((byte)(13)))));
            this.btnMin.FillEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(162)))), ((int)(((byte)(44)))));
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.Color.Transparent;
            this.btnMin.IconFlagCode = 61544;
            this.btnMin.IconFlagColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMin.Location = new System.Drawing.Point(35, 10);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(17, 17);
            this.btnMin.TabIndex = 0;
            this.btnMin.Tag = "min";
            this.btnMin.Text = "ucPointButton1";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.Btn_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.btnClose.BorderWidth = 1;
            this.btnClose.Enabled = false;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(79)))), ((int)(((byte)(74)))));
            this.btnClose.FillDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.btnClose.FillDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(54)))), ((int)(((byte)(52)))));
            this.btnClose.FillEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(54)))), ((int)(((byte)(52)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.IconFlagCode = 61453;
            this.btnClose.IconFlagColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(10, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 17);
            this.btnClose.TabIndex = 0;
            this.btnClose.Tag = "close";
            this.btnClose.Text = "ucPointButton1";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.Btn_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(496, 388);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MacForm.Controls.UCPointButton btnClose;
        private MacForm.Controls.UCPointButton btnMin;
        private MacForm.Controls.UCPointButton btnRestore;
    }
}
namespace MyBookshelf
{
    partial class Login
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
            this.LoginTXT = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelPass = new System.Windows.Forms.Label();
            this.PasswordTXT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelLogin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LoginPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginTXT
            // 
            this.LoginTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginTXT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginTXT.Location = new System.Drawing.Point(5, 5);
            this.LoginTXT.Margin = new System.Windows.Forms.Padding(8);
            this.LoginTXT.MaxLength = 20;
            this.LoginTXT.Name = "LoginTXT";
            this.LoginTXT.Size = new System.Drawing.Size(265, 20);
            this.LoginTXT.TabIndex = 0;
            this.LoginTXT.WordWrap = false;
            this.LoginTXT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.LoginTXT.Enter += new System.EventHandler(this.FindEnter);
            this.LoginTXT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTXT_KeyDown);
            this.LoginTXT.Leave += new System.EventHandler(this.FindLeave);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.DarkGreen;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(176, 154);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(108, 37);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Zaloguj";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.DarkGreen;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.Location = new System.Drawing.Point(176, 197);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(108, 37);
            this.RegisterButton.TabIndex = 3;
            this.RegisterButton.TabStop = false;
            this.RegisterButton.Text = "Rejestracja";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.White;
            this.LoginPanel.Controls.Add(this.panel2);
            this.LoginPanel.Controls.Add(this.panelLogin);
            this.LoginPanel.Controls.Add(this.panel1);
            this.LoginPanel.Controls.Add(this.RegisterButton);
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(299, 245);
            this.LoginPanel.TabIndex = 6;
            this.LoginPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LoginPanel_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.LabelPass);
            this.panel2.Controls.Add(this.PasswordTXT);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(12, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 30);
            this.panel2.TabIndex = 1;
            // 
            // LabelPass
            // 
            this.LabelPass.AutoSize = true;
            this.LabelPass.Enabled = false;
            this.LabelPass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelPass.Location = new System.Drawing.Point(3, 5);
            this.LabelPass.Name = "LabelPass";
            this.LabelPass.Size = new System.Drawing.Size(52, 18);
            this.LabelPass.TabIndex = 9;
            this.LabelPass.Text = "Hasło";
            // 
            // PasswordTXT
            // 
            this.PasswordTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTXT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PasswordTXT.Location = new System.Drawing.Point(5, 5);
            this.PasswordTXT.Margin = new System.Windows.Forms.Padding(8);
            this.PasswordTXT.MaxLength = 20;
            this.PasswordTXT.Name = "PasswordTXT";
            this.PasswordTXT.Size = new System.Drawing.Size(265, 20);
            this.PasswordTXT.TabIndex = 1;
            this.PasswordTXT.UseSystemPasswordChar = true;
            this.PasswordTXT.WordWrap = false;
            this.PasswordTXT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.PasswordTXT.Enter += new System.EventHandler(this.FindEnter);
            this.PasswordTXT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTXT_KeyDown);
            this.PasswordTXT.Leave += new System.EventHandler(this.FindLeave);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(0, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 2);
            this.label7.TabIndex = 8;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.Controls.Add(this.labelLogin);
            this.panelLogin.Controls.Add(this.LoginTXT);
            this.panelLogin.Controls.Add(this.label5);
            this.panelLogin.Location = new System.Drawing.Point(12, 67);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(275, 30);
            this.panelLogin.TabIndex = 0;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Enabled = false;
            this.labelLogin.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLogin.Location = new System.Drawing.Point(3, 5);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(52, 18);
            this.labelLogin.TabIndex = 9;
            this.labelLogin.Text = "Login";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(0, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(275, 2);
            this.label5.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 42);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Logowanie";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(143, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Zarejestrowano";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 245);
            this.Controls.Add(this.LoginPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.LoginPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox LoginTXT;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Panel LoginPanel;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LabelPass;
        private System.Windows.Forms.TextBox PasswordTXT;
        private System.Windows.Forms.Label label7;
    }
}


namespace MyBookshelf
{
    partial class Register
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
            this.panelRegister = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelEmailBottom = new System.Windows.Forms.Label();
            this.EmailTXT = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelSname = new System.Windows.Forms.Label();
            this.labelSnameBottom = new System.Windows.Forms.Label();
            this.SNameTXT = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelFname = new System.Windows.Forms.Label();
            this.labelFnameBottom = new System.Windows.Forms.Label();
            this.FNameTXT = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelPassBottom = new System.Windows.Forms.Label();
            this.PasswordTXT = new System.Windows.Forms.TextBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelLoginBottom = new System.Windows.Forms.Label();
            this.LoginTXT = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.panelRegister.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRegister
            // 
            this.panelRegister.BackColor = System.Drawing.Color.White;
            this.panelRegister.Controls.Add(this.panel6);
            this.panelRegister.Controls.Add(this.panel4);
            this.panelRegister.Controls.Add(this.panel5);
            this.panelRegister.Controls.Add(this.panel3);
            this.panelRegister.Controls.Add(this.panelLogin);
            this.panelRegister.Controls.Add(this.panel2);
            this.panelRegister.Controls.Add(this.button1);
            this.panelRegister.Controls.Add(this.RegisterButton);
            this.panelRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegister.Location = new System.Drawing.Point(0, 0);
            this.panelRegister.Name = "panelRegister";
            this.panelRegister.Size = new System.Drawing.Size(299, 347);
            this.panelRegister.TabIndex = 16;
            this.panelRegister.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LoginPanel_MouseClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.labelEmail);
            this.panel6.Controls.Add(this.labelEmailBottom);
            this.panel6.Controls.Add(this.EmailTXT);
            this.panel6.Location = new System.Drawing.Point(12, 211);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(275, 30);
            this.panel6.TabIndex = 4;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Enabled = false;
            this.labelEmail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEmail.Location = new System.Drawing.Point(3, 5);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(53, 18);
            this.labelEmail.TabIndex = 9;
            this.labelEmail.Text = "Email";
            // 
            // labelEmailBottom
            // 
            this.labelEmailBottom.BackColor = System.Drawing.Color.DarkGray;
            this.labelEmailBottom.Location = new System.Drawing.Point(0, 28);
            this.labelEmailBottom.Name = "labelEmailBottom";
            this.labelEmailBottom.Size = new System.Drawing.Size(275, 2);
            this.labelEmailBottom.TabIndex = 8;
            // 
            // EmailTXT
            // 
            this.EmailTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailTXT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EmailTXT.Location = new System.Drawing.Point(5, 5);
            this.EmailTXT.Margin = new System.Windows.Forms.Padding(8);
            this.EmailTXT.MaxLength = 50;
            this.EmailTXT.Name = "EmailTXT";
            this.EmailTXT.Size = new System.Drawing.Size(265, 20);
            this.EmailTXT.TabIndex = 4;
            this.EmailTXT.WordWrap = false;
            this.EmailTXT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.EmailTXT.Enter += new System.EventHandler(this.FindEnter);
            this.EmailTXT.Leave += new System.EventHandler(this.FindLeave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.labelSname);
            this.panel4.Controls.Add(this.labelSnameBottom);
            this.panel4.Controls.Add(this.SNameTXT);
            this.panel4.Location = new System.Drawing.Point(12, 175);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 30);
            this.panel4.TabIndex = 3;
            // 
            // labelSname
            // 
            this.labelSname.AutoSize = true;
            this.labelSname.Enabled = false;
            this.labelSname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSname.Location = new System.Drawing.Point(3, 5);
            this.labelSname.Name = "labelSname";
            this.labelSname.Size = new System.Drawing.Size(85, 18);
            this.labelSname.TabIndex = 9;
            this.labelSname.Text = "Nazwisko";
            // 
            // labelSnameBottom
            // 
            this.labelSnameBottom.BackColor = System.Drawing.Color.DarkGray;
            this.labelSnameBottom.Location = new System.Drawing.Point(0, 28);
            this.labelSnameBottom.Name = "labelSnameBottom";
            this.labelSnameBottom.Size = new System.Drawing.Size(275, 2);
            this.labelSnameBottom.TabIndex = 8;
            // 
            // SNameTXT
            // 
            this.SNameTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SNameTXT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SNameTXT.Location = new System.Drawing.Point(5, 5);
            this.SNameTXT.Margin = new System.Windows.Forms.Padding(8);
            this.SNameTXT.MaxLength = 20;
            this.SNameTXT.Name = "SNameTXT";
            this.SNameTXT.Size = new System.Drawing.Size(265, 20);
            this.SNameTXT.TabIndex = 3;
            this.SNameTXT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.SNameTXT.Enter += new System.EventHandler(this.FindEnter);
            this.SNameTXT.Leave += new System.EventHandler(this.FindLeave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.labelFname);
            this.panel5.Controls.Add(this.labelFnameBottom);
            this.panel5.Controls.Add(this.FNameTXT);
            this.panel5.Location = new System.Drawing.Point(12, 139);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 30);
            this.panel5.TabIndex = 2;
            // 
            // labelFname
            // 
            this.labelFname.AutoSize = true;
            this.labelFname.Enabled = false;
            this.labelFname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFname.Location = new System.Drawing.Point(3, 5);
            this.labelFname.Name = "labelFname";
            this.labelFname.Size = new System.Drawing.Size(45, 18);
            this.labelFname.TabIndex = 9;
            this.labelFname.Text = "Imię";
            // 
            // labelFnameBottom
            // 
            this.labelFnameBottom.BackColor = System.Drawing.Color.DarkGray;
            this.labelFnameBottom.Location = new System.Drawing.Point(0, 28);
            this.labelFnameBottom.Name = "labelFnameBottom";
            this.labelFnameBottom.Size = new System.Drawing.Size(275, 2);
            this.labelFnameBottom.TabIndex = 8;
            // 
            // FNameTXT
            // 
            this.FNameTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FNameTXT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FNameTXT.Location = new System.Drawing.Point(5, 5);
            this.FNameTXT.Margin = new System.Windows.Forms.Padding(8);
            this.FNameTXT.MaxLength = 20;
            this.FNameTXT.Name = "FNameTXT";
            this.FNameTXT.Size = new System.Drawing.Size(265, 20);
            this.FNameTXT.TabIndex = 2;
            this.FNameTXT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.FNameTXT.Enter += new System.EventHandler(this.FindEnter);
            this.FNameTXT.Leave += new System.EventHandler(this.FindLeave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.labelPass);
            this.panel3.Controls.Add(this.labelPassBottom);
            this.panel3.Controls.Add(this.PasswordTXT);
            this.panel3.Location = new System.Drawing.Point(12, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 30);
            this.panel3.TabIndex = 1;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Enabled = false;
            this.labelPass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPass.Location = new System.Drawing.Point(3, 5);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(176, 18);
            this.labelPass.TabIndex = 9;
            this.labelPass.Text = "Hasło (5-20 znaków)";
            // 
            // labelPassBottom
            // 
            this.labelPassBottom.BackColor = System.Drawing.Color.DarkGray;
            this.labelPassBottom.Location = new System.Drawing.Point(0, 28);
            this.labelPassBottom.Name = "labelPassBottom";
            this.labelPassBottom.Size = new System.Drawing.Size(275, 2);
            this.labelPassBottom.TabIndex = 8;
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
            this.PasswordTXT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.PasswordTXT.Enter += new System.EventHandler(this.FindEnter);
            this.PasswordTXT.Leave += new System.EventHandler(this.FindLeave);
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.Controls.Add(this.labelLogin);
            this.panelLogin.Controls.Add(this.labelLoginBottom);
            this.panelLogin.Controls.Add(this.LoginTXT);
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
            this.labelLogin.Size = new System.Drawing.Size(176, 18);
            this.labelLogin.TabIndex = 9;
            this.labelLogin.Text = "Login (4-20 znaków)";
            // 
            // labelLoginBottom
            // 
            this.labelLoginBottom.BackColor = System.Drawing.Color.DarkGray;
            this.labelLoginBottom.Location = new System.Drawing.Point(0, 28);
            this.labelLoginBottom.Name = "labelLoginBottom";
            this.labelLoginBottom.Size = new System.Drawing.Size(275, 2);
            this.labelLoginBottom.TabIndex = 8;
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
            this.LoginTXT.Leave += new System.EventHandler(this.FindLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGreen;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 42);
            this.panel2.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Rejestracja";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(179, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 37);
            this.button1.TabIndex = 7;
            this.button1.TabStop = false;
            this.button1.Text = "Logowanie";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.Color.DarkGreen;
            this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.Location = new System.Drawing.Point(179, 260);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(108, 37);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Zarejestruj";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 347);
            this.Controls.Add(this.panelRegister);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Register";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rejestracja";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panelRegister.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRegister;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox EmailTXT;
        private System.Windows.Forms.TextBox PasswordTXT;
        private System.Windows.Forms.TextBox LoginTXT;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox SNameTXT;
        private System.Windows.Forms.TextBox FNameTXT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelLoginBottom;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelPassBottom;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelEmailBottom;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelSname;
        private System.Windows.Forms.Label labelSnameBottom;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelFname;
        private System.Windows.Forms.Label labelFnameBottom;
    }
}
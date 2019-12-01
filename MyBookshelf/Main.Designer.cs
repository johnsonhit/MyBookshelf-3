namespace MyBookshelf
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.LibrariesButton = new System.Windows.Forms.Button();
            this.BooksButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.MainView = new System.Windows.Forms.DataGridView();
            this.LeftPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainView)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.LeftPanel.Controls.Add(this.SaveButton);
            this.LeftPanel.Controls.Add(this.AddButton);
            this.LeftPanel.Controls.Add(this.ExitButton);
            this.LeftPanel.Controls.Add(this.NameLabel);
            this.LeftPanel.Controls.Add(this.LibrariesButton);
            this.LeftPanel.Controls.Add(this.BooksButton);
            this.LeftPanel.Controls.Add(this.LogoutButton);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(132, 596);
            this.LeftPanel.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.DarkGreen;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(0, 207);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(132, 44);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.DarkGreen;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddButton.ForeColor = System.Drawing.Color.White;
            this.AddButton.Location = new System.Drawing.Point(0, 157);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(132, 44);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Dodaj";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.DarkGreen;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(0, 464);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(132, 34);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Wyjdź";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(129, 54);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "NAME";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LibrariesButton
            // 
            this.LibrariesButton.BackColor = System.Drawing.Color.DarkGreen;
            this.LibrariesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LibrariesButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LibrariesButton.ForeColor = System.Drawing.Color.White;
            this.LibrariesButton.Location = new System.Drawing.Point(0, 107);
            this.LibrariesButton.Name = "LibrariesButton";
            this.LibrariesButton.Size = new System.Drawing.Size(132, 44);
            this.LibrariesButton.TabIndex = 0;
            this.LibrariesButton.Text = "Biblioteki";
            this.LibrariesButton.UseVisualStyleBackColor = false;
            this.LibrariesButton.Click += new System.EventHandler(this.LibrariesButton_Click);
            // 
            // BooksButton
            // 
            this.BooksButton.BackColor = System.Drawing.Color.DarkGreen;
            this.BooksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BooksButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BooksButton.ForeColor = System.Drawing.Color.White;
            this.BooksButton.Location = new System.Drawing.Point(0, 57);
            this.BooksButton.Name = "BooksButton";
            this.BooksButton.Size = new System.Drawing.Size(132, 44);
            this.BooksButton.TabIndex = 1;
            this.BooksButton.Text = "Książki";
            this.BooksButton.UseVisualStyleBackColor = false;
            this.BooksButton.Click += new System.EventHandler(this.BooksButton_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.BackColor = System.Drawing.Color.DarkGreen;
            this.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogoutButton.ForeColor = System.Drawing.Color.White;
            this.LogoutButton.Location = new System.Drawing.Point(0, 424);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(132, 34);
            this.LogoutButton.TabIndex = 0;
            this.LogoutButton.Text = "Wyloguj";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // RightPanel
            // 
            this.RightPanel.AutoScroll = true;
            this.RightPanel.Controls.Add(this.MainView);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(135, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(846, 596);
            this.RightPanel.TabIndex = 1;
            // 
            // MainView
            // 
            this.MainView.AllowUserToResizeColumns = false;
            this.MainView.AllowUserToResizeRows = false;
            this.MainView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MainView.BackgroundColor = System.Drawing.Color.White;
            this.MainView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainView.DefaultCellStyle = dataGridViewCellStyle1;
            this.MainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.MainView.Location = new System.Drawing.Point(0, 0);
            this.MainView.MultiSelect = false;
            this.MainView.Name = "MainView";
            this.MainView.ReadOnly = true;
            this.MainView.RowHeadersVisible = false;
            this.MainView.Size = new System.Drawing.Size(846, 596);
            this.MainView.TabIndex = 0;
            this.MainView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_CellClick);
            this.MainView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_CellContentClick);
            this.MainView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MainView_DataError);
            this.MainView.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_RowLeave);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 596);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.LeftPanel.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button LibrariesButton;
        private System.Windows.Forms.Button BooksButton;
        public System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.DataGridView MainView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button SaveButton;
    }
}
namespace UI
{
	partial class HomeForm
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
            groupsDataGridView = new DataGridView();
            contestsGridView = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            searchContestantsButton = new Button();
            contestantsGridView = new DataGridView();
            logoutButton = new Button();
            registerContestantButton = new Button();
            userLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)groupsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contestsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contestantsGridView).BeginInit();
            SuspendLayout();
            // 
            // groupsDataGridView
            // 
            groupsDataGridView.AllowUserToAddRows = false;
            groupsDataGridView.AllowUserToDeleteRows = false;
            groupsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            groupsDataGridView.Location = new Point(8, 57);
            groupsDataGridView.Margin = new Padding(2);
            groupsDataGridView.MultiSelect = false;
            groupsDataGridView.Name = "groupsDataGridView";
            groupsDataGridView.ReadOnly = true;
            groupsDataGridView.RowHeadersWidth = 62;
            groupsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupsDataGridView.Size = new Size(262, 140);
            groupsDataGridView.TabIndex = 0;
            groupsDataGridView.CellClick += groupsDataGridView_CellClick;
            // 
            // contestsGridView
            // 
            contestsGridView.AllowUserToAddRows = false;
            contestsGridView.AllowUserToDeleteRows = false;
            contestsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contestsGridView.Location = new Point(8, 216);
            contestsGridView.Margin = new Padding(2);
            contestsGridView.MultiSelect = false;
            contestsGridView.Name = "contestsGridView";
            contestsGridView.ReadOnly = true;
            contestsGridView.RowHeadersWidth = 62;
            contestsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contestsGridView.Size = new Size(262, 139);
            contestsGridView.TabIndex = 1;
            contestsGridView.CellClick += contestsGridView_CellClick;
            contestsGridView.DataBindingComplete += contestsGridView_DataBindingComplete;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 40);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Grupe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 199);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "Probe";
            // 
            // searchContestantsButton
            // 
            searchContestantsButton.BackColor = Color.Honeydew;
            searchContestantsButton.FlatStyle = FlatStyle.Flat;
            searchContestantsButton.ForeColor = Color.FromArgb(0, 0, 192);
            searchContestantsButton.Location = new Point(340, 359);
            searchContestantsButton.Margin = new Padding(2);
            searchContestantsButton.Name = "searchContestantsButton";
            searchContestantsButton.Size = new Size(239, 70);
            searchContestantsButton.TabIndex = 4;
            searchContestantsButton.Text = "Cauta participanti";
            searchContestantsButton.UseVisualStyleBackColor = false;
            searchContestantsButton.Click += searchContestantsButton_Click;
            // 
            // contestantsGridView
            // 
            contestantsGridView.AllowUserToAddRows = false;
            contestantsGridView.AllowUserToDeleteRows = false;
            contestantsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contestantsGridView.Location = new Point(290, 57);
            contestantsGridView.Margin = new Padding(2);
            contestantsGridView.MultiSelect = false;
            contestantsGridView.Name = "contestantsGridView";
            contestantsGridView.ReadOnly = true;
            contestantsGridView.RowHeadersWidth = 62;
            contestantsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contestantsGridView.Size = new Size(326, 298);
            contestantsGridView.TabIndex = 5;
            // 
            // logoutButton
            // 
            logoutButton.BackColor = Color.Khaki;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.ForeColor = Color.FromArgb(192, 0, 0);
            logoutButton.Location = new Point(8, 494);
            logoutButton.Margin = new Padding(2);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(100, 41);
            logoutButton.TabIndex = 6;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += logoutButton_Click;
            // 
            // registerContestantButton
            // 
            registerContestantButton.BackColor = Color.Honeydew;
            registerContestantButton.FlatStyle = FlatStyle.Flat;
            registerContestantButton.ForeColor = Color.FromArgb(0, 0, 192);
            registerContestantButton.Location = new Point(38, 359);
            registerContestantButton.Margin = new Padding(2);
            registerContestantButton.Name = "registerContestantButton";
            registerContestantButton.Size = new Size(186, 70);
            registerContestantButton.TabIndex = 7;
            registerContestantButton.Text = "Inscrie participant";
            registerContestantButton.UseVisualStyleBackColor = false;
            registerContestantButton.Click += registerContestantButton_Click;
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Location = new Point(11, 477);
            userLabel.Margin = new Padding(2, 0, 2, 0);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(29, 15);
            userLabel.TabIndex = 8;
            userLabel.Text = "user";
            userLabel.Click += userLabel_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(627, 546);
            Controls.Add(userLabel);
            Controls.Add(registerContestantButton);
            Controls.Add(logoutButton);
            Controls.Add(contestantsGridView);
            Controls.Add(searchContestantsButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(contestsGridView);
            Controls.Add(groupsDataGridView);
            Margin = new Padding(2);
            Name = "HomeForm";
            Text = "HomeForm";
            FormClosing += HomeForm_FormClosing;
            FormClosed += HomeForm_FormClosed;
            Load += HomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)groupsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)contestsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)contestantsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView groupsDataGridView;
		private DataGridView contestsGridView;
		private Label label1;
		private Label label2;
		private Button searchContestantsButton;
		private DataGridView contestantsGridView;
		private Button logoutButton;
		private Button registerContestantButton;
		private Label userLabel;
	}
}
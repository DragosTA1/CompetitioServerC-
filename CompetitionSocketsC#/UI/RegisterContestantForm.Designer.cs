namespace UI
{
	partial class RegisterContestantForm
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
            label3 = new Label();
            registerButton = new Button();
            label2 = new Label();
            label1 = new Label();
            cnpTextBox = new TextBox();
            nameTextBox = new TextBox();
            ageNumericUpDown = new NumericUpDown();
            contestsGridView = new DataGridView();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)ageNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contestsGridView).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 78);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 22;
            label3.Text = "Varsta";
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.Lavender;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.ForeColor = Color.Green;
            registerButton.Location = new Point(15, 178);
            registerButton.Margin = new Padding(2, 2, 2, 2);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(139, 59);
            registerButton.TabIndex = 20;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 126);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 19;
            label2.Text = "CNP";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 30);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 18;
            label1.Text = "Nume";
            // 
            // cnpTextBox
            // 
            cnpTextBox.BackColor = SystemColors.ControlLight;
            cnpTextBox.Location = new Point(15, 143);
            cnpTextBox.Margin = new Padding(2, 2, 2, 2);
            cnpTextBox.Name = "cnpTextBox";
            cnpTextBox.Size = new Size(139, 23);
            cnpTextBox.TabIndex = 17;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.ControlLight;
            nameTextBox.Location = new Point(15, 47);
            nameTextBox.Margin = new Padding(2, 2, 2, 2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(139, 23);
            nameTextBox.TabIndex = 16;
            // 
            // ageNumericUpDown
            // 
            ageNumericUpDown.BackColor = SystemColors.ControlLight;
            ageNumericUpDown.Location = new Point(15, 95);
            ageNumericUpDown.Margin = new Padding(2, 2, 2, 2);
            ageNumericUpDown.Maximum = new decimal(new int[] { 140, 0, 0, 0 });
            ageNumericUpDown.Name = "ageNumericUpDown";
            ageNumericUpDown.Size = new Size(139, 23);
            ageNumericUpDown.TabIndex = 25;
            ageNumericUpDown.ValueChanged += ageNumericUpDown_ValueChanged;
            // 
            // contestsGridView
            // 
            contestsGridView.AllowUserToAddRows = false;
            contestsGridView.AllowUserToDeleteRows = false;
            contestsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contestsGridView.Location = new Point(189, 47);
            contestsGridView.Margin = new Padding(2, 2, 2, 2);
            contestsGridView.Name = "contestsGridView";
            contestsGridView.ReadOnly = true;
            contestsGridView.RowHeadersWidth = 62;
            contestsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contestsGridView.Size = new Size(108, 190);
            contestsGridView.TabIndex = 26;
            contestsGridView.CellContentClick += contestsGridView_CellContentClick;
            contestsGridView.DataBindingComplete += contestsGridView_DataBindingComplete;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(189, 30);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 27;
            label4.Text = "Probe";
            // 
            // RegisterContestantForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(323, 276);
            Controls.Add(label4);
            Controls.Add(contestsGridView);
            Controls.Add(ageNumericUpDown);
            Controls.Add(label3);
            Controls.Add(registerButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cnpTextBox);
            Controls.Add(nameTextBox);
            Margin = new Padding(2, 2, 2, 2);
            Name = "RegisterContestantForm";
            Text = "RegisterContestantForm";
            Load += RegisterContestantForm_Load;
            ((System.ComponentModel.ISupportInitialize)ageNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)contestsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
		private Button registerButton;
		private Label label2;
		private Label label1;
		private TextBox cnpTextBox;
		private TextBox nameTextBox;
		private NumericUpDown ageNumericUpDown;
		private DataGridView contestsGridView;
		private Label label4;
	}
}
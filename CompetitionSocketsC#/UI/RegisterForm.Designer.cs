namespace UI
{
	partial class RegisterForm
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
            label2 = new Label();
            label1 = new Label();
            passwordTextBox = new TextBox();
            userTextBox = new TextBox();
            registerButton = new Button();
            emailTextBox = new TextBox();
            label3 = new Label();
            cityTextBox = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 144);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 9;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 37);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 8;
            label1.Text = "User";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = SystemColors.ControlLight;
            passwordTextBox.Location = new Point(11, 161);
            passwordTextBox.Margin = new Padding(2, 2, 2, 2);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(220, 23);
            passwordTextBox.TabIndex = 7;
            // 
            // userTextBox
            // 
            userTextBox.BackColor = SystemColors.ControlLight;
            userTextBox.Location = new Point(11, 54);
            userTextBox.Margin = new Padding(2, 2, 2, 2);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(220, 23);
            userTextBox.TabIndex = 6;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.Lavender;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.ForeColor = Color.Green;
            registerButton.Location = new Point(11, 247);
            registerButton.Margin = new Padding(2, 2, 2, 2);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(220, 46);
            registerButton.TabIndex = 11;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // emailTextBox
            // 
            emailTextBox.BackColor = SystemColors.ControlLight;
            emailTextBox.Location = new Point(11, 107);
            emailTextBox.Margin = new Padding(2, 2, 2, 2);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(220, 23);
            emailTextBox.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 90);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 13;
            label3.Text = "Email";
            // 
            // cityTextBox
            // 
            cityTextBox.BackColor = SystemColors.ControlLight;
            cityTextBox.Location = new Point(11, 210);
            cityTextBox.Margin = new Padding(2, 2, 2, 2);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(220, 23);
            cityTextBox.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 193);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 15;
            label4.Text = "City";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(244, 330);
            Controls.Add(label4);
            Controls.Add(cityTextBox);
            Controls.Add(label3);
            Controls.Add(emailTextBox);
            Controls.Add(registerButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(userTextBox);
            ForeColor = Color.Black;
            Margin = new Padding(2, 2, 2, 2);
            Name = "RegisterForm";
            Text = "RegisterForm";
            FormClosed += RegisterForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
		private Label label1;
		private TextBox passwordTextBox;
		private TextBox userTextBox;
		private Button registerButton;
		private TextBox emailTextBox;
		private Label label3;
		private TextBox cityTextBox;
		private Label label4;
	}
}
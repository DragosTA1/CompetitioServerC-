namespace UI
{
	partial class LoginForm
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
            userTextBox = new TextBox();
            passwordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            loginButton = new Button();
            registerButton = new Button();
            SuspendLayout();
            // 
            // userTextBox
            // 
            userTextBox.BackColor = SystemColors.ControlLight;
            userTextBox.Location = new Point(28, 87);
            userTextBox.Margin = new Padding(2, 2, 2, 2);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(195, 23);
            userTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = SystemColors.ControlLight;
            passwordTextBox.Location = new Point(28, 149);
            passwordTextBox.Margin = new Padding(2, 2, 2, 2);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(195, 23);
            passwordTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 70);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 2;
            label1.Text = "User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 132);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.Lavender;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Location = new Point(28, 189);
            loginButton.Margin = new Padding(2, 2, 2, 2);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(195, 42);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.Lavender;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.Location = new Point(28, 235);
            registerButton.Margin = new Padding(2, 2, 2, 2);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(195, 48);
            registerButton.TabIndex = 5;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(247, 329);
            Controls.Add(registerButton);
            Controls.Add(loginButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(userTextBox);
            Margin = new Padding(2, 2, 2, 2);
            Name = "LoginForm";
            Text = "LoginForm";
            FormClosed += LoginForm_FormClosed;
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userTextBox;
		private TextBox passwordTextBox;
		private Label label1;
		private Label label2;
		private Button loginButton;
		private Button registerButton;
	}
}
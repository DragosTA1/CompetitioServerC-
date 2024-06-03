using Model;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class LoginForm : Form
    {
        private ClientCtrl Ctrl;
        public LoginForm(ClientCtrl ctrl)
        {
            Ctrl = ctrl;
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (userTextBox.Text.Length == 0 || passwordTextBox.Text.Length == 0)
            {
                MessageBox.Show("Completati campul gol!");
                return;
            }
            try
            {
                Operator op = Ctrl.Login(userTextBox.Text, passwordTextBox.Text);
                HomeForm homeForm = new(op, Ctrl);
                this.Hide();
                if (homeForm.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    userTextBox.Clear();
                    passwordTextBox.Clear();
                }
            }
            catch (CompetitionException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(Ctrl);
            this.Hide();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                registerForm.Close();
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}

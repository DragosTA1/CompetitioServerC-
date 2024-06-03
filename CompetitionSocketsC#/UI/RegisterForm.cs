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
	public partial class RegisterForm : Form
	{
		private ClientCtrl Ctrl;
		public RegisterForm(ClientCtrl clientCtrl)
		{
			Ctrl = clientCtrl;
			InitializeComponent();

		}

		private void registerButton_Click(object sender, EventArgs e)
		{
			string user = userTextBox.Text;
			string email = emailTextBox.Text;
			string password = passwordTextBox.Text;
			string city = cityTextBox.Text;
			if (user.Length == 0 || email.Length == 0 || password.Length == 0 || city.Length == 0)
			{
				MessageBox.Show("Completati campul gol!");
				return;
			}

			Ctrl.AddOperator(user, password, email, city);
			this.Close();
			//this.Hide();
		}

		private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}

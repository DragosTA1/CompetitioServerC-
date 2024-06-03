using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class RegisterContestantForm : Form
    {
        ClientCtrl ClientCtrl { get; set; }
        public RegisterContestantForm(ClientCtrl clientCtrl)
        {
            ClientCtrl = clientCtrl;
            InitializeComponent();
        }
        private int idGroup = -1;
        private List<Contest>? contests;

        private void ageNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Group grp = ClientCtrl.FindGroupByAge(Convert.ToInt32(ageNumericUpDown.Value));
            if (grp != null)
            {
                idGroup = grp.Id;
                contests = ClientCtrl.FindAllContestsByGroup(idGroup);
                contestsGridView.DataSource = contests;
                contestsGridView.Columns["Id"].Visible = false;
                contestsGridView.Columns["Type"].HeaderText = "Lungime (metri)";
                contestsGridView.Columns["ParentGroup"].Visible = false;
            }
        }

        private void RegisterContestantForm_Load(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Completeaza numele!");
                return;
            }

            //if (!ContestantService.ValidateCNP(cnpTextBox.Text))
            //{
            //	MessageBox.Show("Completeaza corect CNP-ul!");
            //	return;
            //}

            if (contestsGridView.SelectedRows.Count == 0 || contestsGridView.SelectedRows.Count > 2)
            {
                MessageBox.Show("Trebuie alese 1 sau 2 probe!");
                return;
            }

            string name = nameTextBox.Text;
            int age = Convert.ToInt32(ageNumericUpDown.Value);
            string cnp = cnpTextBox.Text;

            var contestant = ClientCtrl.AddContestant(name, age, cnp);

            foreach (DataGridViewRow row in contestsGridView.SelectedRows)
            {
                ClientCtrl.AddParticipation(contestant, contests[row.Index]);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void contestsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            contestsGridView.ClearSelection();
        }

        private void contestsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class HomeForm : Form
    {
        private int SelectedContestIDValue = -1;

        public int SelectedGroupIDValue { get; private set; } = -1;
        private Operator CurrentOperator { get; set; }
        private ClientCtrl Ctrl { get; init; }
        public HomeForm(Operator op, ClientCtrl ctrl)
        {
            Ctrl = ctrl;
            InitializeComponent();
            CurrentOperator = op;
            userLabel.Text = op.Username;

            ctrl.UpdateEvent += ObsUpdate;
        }

        private void ObsUpdate(object sender, ObserverEventArgs e)
        {
            if (e.ObserverEvent == ObserverEvent.ParticipationAdded)
            {
                Participation p = (Participation)e.Data;
                if (p.Contest.ParentGroup.Id == SelectedGroupIDValue)
                {
                    groupsDataGridView.BeginInvoke(new UpdateContestsGridViewCallBack(this.PopulateContestsGridView), new object[] { SelectedGroupIDValue });
                    SelectedContestIDValue = -1;
                }
            }
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            groupsDataGridView.DataSource = Ctrl.FindAllGroups();
            groupsDataGridView.Columns["Id"].Visible = false;

            groupsDataGridView.Columns["MinimumAge"].HeaderText = "Varsta minima";
            groupsDataGridView.Columns["MaximumAge"].HeaderText = "Varsta maxima";

        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void groupsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // be careful to how the DTO populates its fields in the table
                SelectedGroupIDValue = (int)groupsDataGridView.Rows[e.RowIndex].Cells[0].Value;
                PopulateContestsGridView(SelectedGroupIDValue);
                SelectedContestIDValue = -1;
            }
        }

        private void PopulateContestsGridView(int groupID)
        {
            contestsGridView.DataSource = Ctrl.FindAllContests(groupID);
            contestsGridView.Columns["Id"].Visible = false;
            contestsGridView.Columns["Type"].HeaderText = "Lungime (metri)";
            contestsGridView.Columns["ParentGroup"].Visible = false;
        }
        public delegate void UpdateContestsGridViewCallBack(int groupID);

        private void searchContestantsButton_Click(object sender, EventArgs e)
        {
            if (SelectedContestIDValue != -1)
            {
                //MessageBox.Show("Selected cell value: " + SelectedContestIDValue.ToString());
                contestantsGridView.DataSource = Ctrl.FindAllContestants(SelectedContestIDValue);
                contestantsGridView.Columns["Id"].Visible = false;
                contestantsGridView.Columns["Name"].HeaderText = "Nume";
                contestantsGridView.Columns["Age"].HeaderText = "Varsta";
                contestantsGridView.Columns["CNP"].Visible = false;
                contestantsGridView.Columns["ParticipationCount"].HeaderText = "Inscrieri";
            }
            else
            {
                MessageBox.Show("Mai intai selectati o proba!");
            }
        }

        private void contestsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedContestIDValue = (int)contestsGridView.Rows[e.RowIndex].Cells[0].Value;
        }

        private void contestsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            contestsGridView.ClearSelection();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Ctrl.Logout(CurrentOperator);
                this.Close();
            }
            catch (CompetitionException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void registerContestantButton_Click(object sender, EventArgs e)
        {
            RegisterContestantForm registerContestantForm = new RegisterContestantForm(this.Ctrl);
            registerContestantForm.ShowDialog();
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Window closing " + e.CloseReason);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Ctrl.Logout(CurrentOperator);
                Ctrl.UpdateEvent -= ObsUpdate;
                Application.Exit();
            }
        }

        private void userLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

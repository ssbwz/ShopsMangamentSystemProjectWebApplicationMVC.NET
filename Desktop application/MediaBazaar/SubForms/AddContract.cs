using MediaBazaar.Logic.Models;
using MediaBazaar.UserControls;

namespace MediaBazaar.SubForms
{
    public partial class AddContract : Form
    {
        private UserControl parent;
        public Contract contract;

        public AddContract(UserControl parent)
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls, this);

            this.parent = parent;

            if (parent is UseControlAddEmployee)
            {
                this.Text = "Add Contract";
                buttonConfirmContract.Text = "Add";
            }
            else if (parent is UCUpdateEmployee) 
            {
                this.Text = "Update Contract";
                buttonConfirmContract.Text = "Update";
            }
        }

        private void checkBoxNoEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoEnd.Checked)
            {
                dateTimePickerEnd.Enabled = false;
            }
            else
            {
                dateTimePickerEnd.Enabled = true;
            }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerEnd.MinDate = dateTimePickerStart.Value;
        }

        private void buttonAddContract_Click(object sender, EventArgs e)
        {
            DateOnly startDate = new DateOnly(dateTimePickerStart.Value.Year, dateTimePickerStart.Value.Month, dateTimePickerStart.Value.Day);
            contract = new Contract(0, startDate, null, numericUpDownFTE.Value, null, 0);
            if (!checkBoxNoEnd.Checked)
            {
                contract.EndDate = new DateOnly(dateTimePickerEnd.Value.Year, dateTimePickerEnd.Value.Month, dateTimePickerEnd.Value.Day);
            }
            this.Hide();
        }

        private void AddContract_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (contract is not null)
                {
                    numericUpDownFTE.Value = contract.FTE;
                    dateTimePickerStart.Value = new DateTime(contract.StartDate.Year, contract.StartDate.Month, contract.StartDate.Day);
                    if (contract.EndDate is null)
                    {
                        checkBoxNoEnd.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        dateTimePickerEnd.Value = new DateTime(contract.EndDate.Value.Year, contract.EndDate.Value.Month, contract.EndDate.Value.Day);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DashboardForm.BiteDetailsForm;
using static DashboardForm.PersonalInfoForm;

namespace DashboardForm
{
    public partial class VaccinationForm : Form
    {
        private Patient currentPatient;
        private BiteDetails biteDetails;

        public VaccinationForm(Patient patient, BiteDetailsForm.BiteDetails bite)
        {
            InitializeComponent();

            // assign parameters to fields
            this.currentPatient = patient;
            this.biteDetails = bite;

            //Vaccination details coloring
            richTextBox1.Text = "Vaccination details";
            richTextBox1.Select(0, 11);
            richTextBox1.SelectionColor = Color.DeepPink;
            richTextBox1.Select(11, 8);
            richTextBox1.SelectionColor = Color.FromArgb(60, 185, 197);
            richTextBox1.Select(0, 0);
        }

        private void VaccinationForm_Load(object sender, EventArgs e)
        {
            cmbDoseNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoseNumber.Items.Clear();
            cmbDoseNumber.Items.AddRange(new string[] { "1st Dose", "2nd Dose", "3rd Dose", "Booster" });
            cmbDoseNumber.SelectedIndex = -1;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            // Optional: add vaccination details later if needed

            // Optionally show summary form
            using (var s = new SummaryForm(currentPatient))
            {
                s.ShowDialog(this);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            // Show BiteDetailsForm (assumes it’s already open)
            foreach (Form f in Application.OpenForms)
            {
                if (f is BiteDetailsForm)
                {
                    f.Show();
                    break;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.Enabled = false;
        }

        private void txtVaccineName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

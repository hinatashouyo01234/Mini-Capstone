using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DashboardForm.PersonalInfoForm;

namespace DashboardForm
{
    public partial class BiteDetailsForm : Form
    {
        Patient currentPatient;  // From Personal Info
        BiteDetails biteDetails; // New class for bite info
        private Patient patient;

        public BiteDetailsForm(Patient patient)
        {
            InitializeComponent();
            currentPatient = patient;

            txtAnimal.KeyPress += txtAnimal_KeyPress;
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.Items.AddRange(new string[] { "Head/Neck", "Arm/Hand", "Leg/Foot", "Body/Torso" });
            cmbLocation.SelectedIndex = -1;


            // Populate ComboBox for bite locations
            cmbLocation.Items.AddRange(new string[] { "Head/Neck", "Arm/Hand", "Leg/Foot", "Body/Torso" });
            cmbLocation.SelectedIndex = -1;

            patient = patient;
            // prefill if existing
            dtIncident.Value = patient.BiteDate ?? DateTime.Now;
            cmbLocation.Text = patient.BiteLocation;
            txtAnimal.Text = patient.AnimalType;

            //Bite details coloring
            richTextBox1.Text = "Bite details";
            richTextBox1.Select(0, 4);
            richTextBox1.SelectionColor = Color.DeepPink;
            richTextBox1.Select(4, 8);
            richTextBox1.SelectionColor = Color.FromArgb(60, 185, 197);
            richTextBox1.Select(0, 0);
        }
        public class BiteDetails
        {
            public DateTime DateOfIncident { get; set; }
            public string AnimalType { get; set; }
            public string BiteLocation { get; set; }
        }

        private void BiteDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // save bite details into current patient
            currentPatient.BiteDate = dtIncident.Value;
            currentPatient.BiteLocation = cmbLocation.Text.Trim();
            currentPatient.AnimalType = txtAnimal.Text.Trim();

            // open Vaccination Details form, pass updated patient
            biteDetails = new BiteDetails
            {
                DateOfIncident = dtIncident.Value,
                BiteLocation = cmbLocation.Text.Trim(),
                AnimalType = txtAnimal.Text.Trim()
            };

            // open Vaccination Details form, pass updated patient and bite details
            VaccinationForm vaccForm = new VaccinationForm(currentPatient, biteDetails);
            vaccForm.Show();

            // hide Bite Details form
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            // Show Bite Details form (assumes it’s already open)
            foreach (Form f in Application.OpenForms)
            {
                if (f is PersonalInfoForm)
                {
                    f.Show();
                    break;
                }
            }
        }

        private void txtAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAnimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters, control keys (like backspace), and space
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.Enabled = false;
        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

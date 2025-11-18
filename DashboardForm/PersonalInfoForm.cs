using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DashboardForm;


namespace DashboardForm
{
    public partial class PersonalInfoForm : Form
    {
        public event Action<Patient> OnPatientSaved;
        private Patient patient;

        public class Patient
        {
            public string FullName { get; set; }
            public string Age { get; set; }
            public string Sex { get; set; }
            public string Address { get; set; }
            public string ContactNumber { get; set; }
        }

        public PersonalInfoForm()
        {
            InitializeComponent();
            this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);

            //Personal info coloring

            richTextBox1.Text = "Personal Information";
            richTextBox1.Select(0, 8);
            richTextBox1.SelectionColor = Color.DeepPink;
            richTextBox1.Select(9, richTextBox1.Text.Length - 9);
            richTextBox1.SelectionColor = Color.FromArgb(60, 185, 197);   
            richTextBox1.Select(0, 0);
        }
        public PersonalInfoForm(Patient p)
        {
            InitializeComponent();

            patient = p;
            txtFullName.Text = patient.FullName;
            txtAge.Text = patient.Age;
            txtContact.Text = patient.ContactNumber;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PersonalInfoForm_Load(object sender, EventArgs e)
        {
            cmbSex.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSex.Items.Clear();
            cmbSex.Items.AddRange(new string[] { "Male", "Female", "Others" });
            cmbSex.SelectedIndex = -1;


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // validation example
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter your full name.");
                txtFullName.Focus();
                return;
            }

            // Validate Age
            if (string.IsNullOrWhiteSpace(txtAge.Text))
            {
                MessageBox.Show("Please enter your age.");
                txtAge.Focus();
                return;
            }

            // Validate Sex
            if (cmbSex.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your sex.");
                cmbSex.Focus();
                return;
            }

            // Validate Address
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter your address.");
                txtAddress.Focus();
                return;
            }

            // Validate Contact Number
            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please enter your contact number.");
                txtContact.Focus();
                return;
            }

            // Optional: Validate contact number format
            if (!Regex.IsMatch(txtContact.Text.Trim(), @"^\d{7,15}$"))
            {
                MessageBox.Show("Contact number must be 7–15 digits.");
                txtContact.Focus();
                return;
            }



            // create patient object
            Patient patient = new Patient()
            {
                FullName = txtFullName.Text.Trim(),
                Age = txtAge.Text.Trim(),
                Sex = cmbSex.Text,
                Address = txtAddress.Text.Trim(),
                ContactNumber = txtContact.Text.Trim()
         
            };
           
            OnPatientSaved?.Invoke(patient);
            this.Hide();


            // open Bite Details form and pass patient info
            BiteDetailsForm biteForm = new BiteDetailsForm(new DashboardForm.Patient
            {
                FullName = patient.FullName,
                Age = patient.Age,
                Sex = patient.Sex,
                Address = patient.Address,
                ContactNumber = patient.ContactNumber
            });
            biteForm.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Your entered data will be erased. Are you sure you want to go back?",
                "Confirm Navigation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Show PatientListForm (assumes it’s already open)
                foreach (Form f in Application.OpenForms)
                {
                    if (f is PatientListForm)
                    {
                        f.Show();
                        break;

                    }
                }

                this.Close();
            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Block the key

            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFullName_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}




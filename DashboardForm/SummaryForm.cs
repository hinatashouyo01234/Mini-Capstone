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
    public partial class SummaryForm : Form
    {
        private Patient currentPatient;
        private Patient patient;

        public SummaryForm(Patient p)
        {
            InitializeComponent();
            patient = p;

            lblSummary.Text =
                $"🧍 Name: {patient.FullName}\n" +
                $"🎂 Age: {patient.Age}\n" +
                $"⚧ Sex: {patient.Sex}\n" +
                $"🏠 Address: {patient.Address}\n" +
                $"📞 Contact: {patient.ContactNumber}\n\n" +
                $"🐾 Bite Location: {patient.BiteLocation}\n" +
                $"📅 Bite Date: {patient.BiteDate?.ToShortDateString() ?? "N/A"}\n" +
                $"🐶 Animal Type: {patient.AnimalType}\n\n" +
                $"📅 Vaccine Date: {patient.VaccineDate?.ToShortDateString() ?? "N/A"}\n" +
                $"💊 Vaccine Name: {patient.VaccineName}\n" +
                $"🔢 Dose Number: {patient.DoseNumber}\n" +
                $"📅 First Dose Date: {patient.FirstDoseDate.ToShortDateString()}\n" +
                $"📅 Next Dose Date: {patient.NextDoseDate.ToShortDateString()}\n\n";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void lblSummary_Click(object sender, EventArgs e)
        {
            // Optional: Add interactivity if needed
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            // No need to reassign lblSummary.Text here — it's already set in the constructor
        }
    }
}


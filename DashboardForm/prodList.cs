using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashboardForm
{
    public partial class productListForm : Form
    {
        public productListForm()
        {
            InitializeComponent();
            richTextBox1.Text = "RhemCare";
            richTextBox1.Select(0, 4);
            richTextBox1.SelectionColor = Color.DeepPink;
            richTextBox1.Select(4, 4);
            richTextBox1.SelectionColor = Color.FromArgb(60, 185, 197);
            richTextBox1.Select(0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            PatientListForm patientList = new PatientListForm();
            patientList.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viewInv viewInv = new viewInv();
            viewInv.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

            // Show DashboardForm (assumes it’s already open)
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form1)
                {
                    f.Show();
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form1)
                {
                    f.Show();
                    break;
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.Enabled = false;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

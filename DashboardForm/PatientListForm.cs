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
    public partial class PatientListForm : Form


    {
        private List<DashboardForm.PersonalInfoForm.Patient> patientList = new List<DashboardForm.PersonalInfoForm.Patient>();

        private int nextPatientId = 1;

        public void AddPatientToGrid(PersonalInfoForm.Patient p)
        {
            var topLevel = new Patient
            {
                Id = nextPatientId++,
                FullName = p.FullName,
                Age = p.Age,
                Sex = p.Sex,
                Address = p.Address,
                ContactNumber = p.ContactNumber
            };

            patients.Add(topLevel);
            bs.ResetBindings(false); // ✅ Refresh the grid
        }



        BindingList<DashboardForm.Patient> patients = new BindingList<DashboardForm.Patient>();
        BindingSource bs = new BindingSource();

        public PatientListForm()
        {
            InitializeComponent();



            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.WindowState = FormWindowState.Maximized;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 99, 188);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersVisible = false;


            richTextBox1.Text = "RhemCare";
            richTextBox1.Select(0, 4);
            richTextBox1.SelectionColor = Color.FromArgb(232, 99, 188);
            richTextBox1.Select(4, 4);
            richTextBox1.SelectionColor = Color.FromArgb(60, 185, 197);
            richTextBox1.Select(0, 0);

            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            bs.DataSource = patients;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns.Clear();

            // ID column
            dataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Name = "Id",
                UseColumnTextForButtonValue = false // ✅ Show the actual ID value
            });

            // Full Name column
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Full Name",
                DataPropertyName = "FullName"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Age",
                DataPropertyName = "Age"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Sex",
                DataPropertyName = "Sex"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Address",
                DataPropertyName = "Address"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Contact Number",
                DataPropertyName = "ContactNumber"
            });

            // Edit button column
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.Name = "Edit";
            editColumn.HeaderText = "Edit";
            editColumn.Text = "Edit";
            editColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editColumn);

            // Delete button column
            dataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });

        }


        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            var form = new DashboardForm.PersonalInfoForm();

            // ✅ Only one event handler
            form.OnPatientSaved += AddPatientToGrid;

            form.Show();
            
        }


        private void PatientListForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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


       
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim().ToLower();

            // 🔹 Temporarily clear the selection
            dataGridView1.ClearSelection();

            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            currencyManager.SuspendBinding(); // 🛑 Pause binding so we can hide rows safely

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells[1].Value?.ToString().ToLower() ?? "";
                row.Visible = name.Contains(searchValue);
            }

            currencyManager.ResumeBinding(); // ✅ Resume binding
        }

        private SummaryForm activeSummaryForm = null;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Id")
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var patient = row.DataBoundItem as Patient;
               
                if (patient == null || string.IsNullOrWhiteSpace(row.Cells["Id"].Value?.ToString()))
                    return;

                if (activeSummaryForm != null && !activeSummaryForm.IsDisposed)
                {
                    activeSummaryForm.BringToFront();
                    return;
                }

                activeSummaryForm = new SummaryForm(patient);
                activeSummaryForm.FormClosed += (s, args) => activeSummaryForm = null;
                activeSummaryForm.Show();


            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            viewInv viewInv = new viewInv();
            viewInv.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnPatient_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            productListForm productListForm = new productListForm();
            productListForm.Show();
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.Enabled = false;
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

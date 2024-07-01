using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class ReportDisplay : Form1
    {
        public ReportDisplay()
        {
            InitializeComponent();
        }

        private void ReportDisplay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Employee_databaseDataSet.employeetable' table. You can move, or remove it, as needed.
            this.employeetableTableAdapter.Fill(this.Employee_databaseDataSet.employeetable);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }
    }
}

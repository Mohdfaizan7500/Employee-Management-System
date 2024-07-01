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
    public partial class Form2 : Form1
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();

            panel1.Parent = pictureBox1;
            panel1.BackColor = Color.Transparent;
                   
                   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            progressBar1.Increment(3);
            label2.Text = progressBar1.Value.ToString() + " %";
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                //MessageBox.Show("Process Completed");
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();

            }
        }
    }
}

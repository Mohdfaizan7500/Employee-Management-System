using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace Employee_Management_System
{
    public partial class Form4 : Form1
    {
        //string numpattern = "^([1-9]\d{10})?$";
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox1;
            panel1.BackColor = Color.Transparent;
            panel2.Parent = pictureBox1;
            panel2.BackColor = Color.Transparent;

            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

            //button5.Parent = pictureBox1;
            //button5.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if(ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if(ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;

            }
            
            else
            {
                e.Handled = true;

            }
        }
        void reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            textBox4.Clear();

        }
        void display()
        {
            dataGridView1.Visible = true;
            OleDbConnection con = new OleDbConnection(cs);

            string query = "select * from employeetable";
            OleDbDataAdapter da = new OleDbDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)==true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1,"Plz Enter ID.");
            }
            else if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox2, "Plz Enter Name.");
            }
            else if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox1.Focus();
                errorProvider3.SetError(this.textBox3, "Plz Enter Number.");
            }
            else if (textBox3.Text.Length != 10)
            {
                textBox3.Focus();
                errorProvider4.SetError(this.textBox3,"Plz Enter 10 Digit Number.");
            }
            else if (comboBox1.SelectedItem == null)
            {
                comboBox1.Focus();
                errorProvider5.SetError(this.comboBox1,"Pls Select Designation.");
            }
            else if (string.IsNullOrEmpty(textBox4.Text)==true)
            {
                textBox4.Focus();
                errorProvider6.SetError(this.textBox3, "Plz Enter Salary");
            }
            else
            {

            
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();

            string query2 = "select * from employeetable where Id=@id";
            OleDbCommand cmd2 = new OleDbCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id",textBox1.Text);
            OleDbDataReader dr = cmd2.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show(textBox1.Text + " ID is already registered.");

                }
                else
                {


                    string query = "insert into employeetable values(@i,@name,@number,@designation,@salary)";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@number", textBox3.Text);
                    cmd.Parameters.AddWithValue("@designation", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@salary", textBox4.Text);

                    int a = cmd.ExecuteNonQuery();

                    if (a > 0)
                    {
                        MessageBox.Show("Recode Save Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        display();
                        reset();

                    }
                    else
                    {
                        MessageBox.Show("Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    con.Close();
                }
            }

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(char.IsDigit(ch)== true)
            {
                e.Handled = false;
            }
            
            else if ( ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display();
            dataGridView1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();

            string query = "update employeetable set id=@id,Name=@name,Number=@number,Designation=@designation,Salary=@salary where Id=@id";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@number", textBox3.Text);
            cmd.Parameters.AddWithValue("@designation", comboBox1.Text);
            cmd.Parameters.AddWithValue("@salary", textBox4.Text);

            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Recode Save Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();
                reset();

            }
            else
            {
                MessageBox.Show("Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();

            string query = "delete from employeetable where Id=@id";
            OleDbCommand cmd = new OleDbCommand(query,con);
            cmd.Parameters.AddWithValue("@id",textBox1.Text);
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                //MessageBox.Show("Recode Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();
                reset();
            }
            else
            {
                MessageBox.Show("Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            string query = "select * from employeetable where Name like @name + '%'";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@name", textBox5.Text.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Visible = true;

            }
            else
            {
                MessageBox.Show("No Recode Found");
                dataGridView1.DataSource = null;
            }
            con.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(cs);
            con.Open();
            string query = "select * from employeetable where Name like @name + '%'";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@name", textBox5.Text.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Recode Found");
                //dataGridView1.DataSource = null;
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ReportDisplay r1 = new ReportDisplay();
            r1.Show();
            this.Hide();


        }
    }
}

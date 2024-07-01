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
    public partial class Form3 : Form1
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form3()
        {
            InitializeComponent();
        }

        Bitmap bmphide = Properties.Resources.hide___Copy;
        Bitmap bmshow = Properties.Resources.visible;

        private void Form3_Load(object sender, EventArgs e)
        {
            button3.Image = bmphide;
            //panel1.Parent = pictureBox1;
            //panel1.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            errorProvider1.Clear();
            errorProvider2.Clear();

            

        }

        private void textBox1_ForeColorChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            if (a == "Email or Number")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
                textBox1.Multiline = false;
                textBox1.Font = new Font("Microsoft Sans Serif", 28, FontStyle.Bold);
                label2.Visible = true;

            }


        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string a = textBox1.Text;

            if (a == "")
            {
                textBox1.Text = "Email or Number";
                textBox1.ForeColor = Color.Silver;
                textBox1.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
                textBox1.Multiline = true;
                label2.Visible = false;


            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            string a = textBox2.Text;

            if (a == "Password")
            {
                textBox2.Clear();
                textBox2.ForeColor = Color.Black;
                textBox2.Multiline = false;
                textBox2.Font = new Font("Microsoft Sans Serif", 28, FontStyle.Bold);
                button3.Visible = true;
                label3.Visible = true;

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            string a = textBox2.Text;

            if (a == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Silver;
                textBox2.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
                textBox2.Multiline = true;
                button3.Visible = false;
                label3.Visible = false;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Image == bmphide)
            {
                button3.Image = bmshow;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                button3.Image = bmphide;
                textBox2.UseSystemPasswordChar = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true  || textBox1.Text == "Email or Number")
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Pls Enter Password");
                

            }
            else if (string.IsNullOrEmpty(textBox1.Text) == true || textBox2.Text == "Password")
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Pls Enter Password");
                //button3.Visible = true;

            }
            else
            {

                OleDbConnection con = new OleDbConnection(cs);
                con.Open();

                string query = "select * from logintable where Email=@user and Password=@pass";
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    //MessageBox.Show("Login Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form4 f4 = new Form4();
                    f4.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Pls Enter Correct Username Or Password.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                con.Close();
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)==true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1,"Pls Enter Email or Number");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Pls Enter Password");
                button3.Visible = true;

            }
            else
            {
                errorProvider2.Clear();
                button3.Visible = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }
    }
}

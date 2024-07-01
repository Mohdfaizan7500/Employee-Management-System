using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.OleDb;

namespace Employee_Management_System
{
    public partial class Form5 : Form1
    {
        string emailpattern = "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9-](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";

        //string passpattern = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";

        public Form5()
        {
            InitializeComponent();
        }

        

        private void Form5_Load(object sender, EventArgs e)
        {
            label2.Parent = panel2;
            label2.BackColor = Color.Transparent;
            //button2.Parent = panel1;
            //button2.BackColor = Color.Transparent;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Pls enter your name");
            }
            else if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Pls enter your email");
            }
            else if (Regex.IsMatch(textBox2.Text, emailpattern) == false)
            {
                textBox2.Focus();
                errorProvider4.SetError(this.textBox2, "Plz Fill Valid Email");

            }
            else if (textBox3.Text == textBox4.Text)
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                OleDbConnection con = new OleDbConnection(cs);
                con.Open();

                string query2 = "select * from logintable where Email=@email";
                OleDbCommand cmd2 = new OleDbCommand(query2,con);
                cmd2.Parameters.AddWithValue("@email",textBox2.Text);
                OleDbDataReader dr = cmd2.ExecuteReader();

                if (dr.HasRows == true)
                {
                    
                    DialogResult result = MessageBox.Show(textBox2.Text + "  \n Email Id is already registered. !");

                    if (result == DialogResult.OK)
                    {
                        textBox2.Clear();
                    }



                }
                else 
                {
                    string query = "insert into logintable values (@name,@email,@pass)";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox3.Text);
                    int a = cmd.ExecuteNonQuery();
                    con.Close();

                    if (a > 0)
                    {
                        MessageBox.Show("Registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Your email is: " + textBox2.Text + "\n\n " + "Your password is: " + textBox3.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form3 f3 = new Form3();
                        f3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Registered Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }


                

                


                //MessageBox.Show("Your are Registered", "Successs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                /*
                textBox1.Clear();
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);
                textBox1.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                textBox1.Text = "Enter your name";

                textBox2.Clear();
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);
                textBox2.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                textBox2.Text = "Enter your email";

                textBox3.Clear();
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);
                textBox3.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                textBox3.Text = "Create password";

                textBox4.Clear();
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
                textBox4.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                textBox4.Text = "Confirm password";
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                */
            }
            else
            {
                MessageBox.Show("Password Mismatch", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                checkBox1.Checked = false;
                //checkBox1.Enabled = false;
            }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true && (textBox1.Text != "" || textBox1.Text !="Enter you name") )
            {
                button1.Enabled = true;
                button1.BackColor = Color.FromArgb(15, 157, 88);
                button1.Text = "Register now";

            }
            else
            {
                button1.Enabled = false;
                button1.BackColor = Color.FromArgb(66, 111, 255);
                button1.Text = "Fill ";


            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)== true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1,"Pls enter your name");
            }
            else
            {
                errorProvider1.Clear();
                label1.Visible = false;

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
            textBox1.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
            label1.Visible = true;

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.ForeColor = Color.Black;
            textBox2.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
            label4.Visible = true;

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Pls enter your email");
            }
            else
            {
                errorProvider2.Clear();
                label4.Visible = false;

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.ForeColor = Color.Black;
            textBox3.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
            textBox3.UseSystemPasswordChar = true;
            label7.Visible = true;

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Create Password");
            }
            else
            {
                errorProvider3.Clear();
                checkBox1.Enabled = true;
                checkBox1.ForeColor = Color.Green;

                label7.Visible = false;


            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox4.ForeColor = Color.Black;
            textBox4.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
            label8.Visible = true;

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Re-enter password");
            }
            else
            {
                errorProvider4.Clear();
                label8.Visible = false;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.FromArgb(224, 224, 224);
            textBox1.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            textBox1.Text = "Enter your name";


            textBox2.Clear();
            textBox2.ForeColor = Color.FromArgb(224, 224, 224);
            textBox2.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            textBox2.Text = "Enter your email";

            textBox3.Clear();
            textBox3.ForeColor = Color.FromArgb(224, 224, 224);
            textBox3.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            textBox3.Text = "Create password";

            textBox4.Clear();
            textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            textBox4.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            textBox4.Text = "Confirm password";
            checkBox1.Checked = false;
            checkBox1.Enabled = false;

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();



        }
    }
}

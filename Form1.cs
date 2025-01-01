using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
namespace QuickChat
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Allow the form to preview key events
            this.KeyDown += Form1_KeyDown; // Attach the KeyDown event
        }
        string constring = "Data Source=DESKTOP-2IK592G\\SQLEXPRESS;Initial Catalog=firsttime;Integrated Security=True";
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
           // ButtonRegister.BaseColor =Color.Turquoise;
           // ButtonLogin.BaseColor = Color.DodgerBlue;
           // panel4.BackColor = Color.Turquoise;
           // panel3.BackColor = Color.DodgerBlue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ButtonLogin.PerformClick();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            Panel2.BringToFront();
          //  ButtonLogin.BaseColor = Color.Turquoise;
          //  ButtonRegister.BaseColor = Color.DodgerBlue;
          //  panel4.BackColor = Color.DodgerBlue;
           // panel3.BackColor = Color.Turquoise;
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

            if (gunaCirclePictureBox2.Image == null)
            {
                MessageBox.Show("Select photo");
            }
            else
            {
                string firstName = firstnameText.Text.Trim();
                string lastName = lastnameText.Text.Trim();

                if (string.IsNullOrEmpty(firstName))
                {
                    errorProvider2.SetError(firstnameText, "Firstname is required");
                    return;
                }
                else
                {
                    errorProvider2.SetError(firstnameText, string.Empty);
                }

                if (string.IsNullOrEmpty(lastName))
                {
                    errorProvider2.SetError(lastnameText, "Lastname is required");
                    return;
                }
                else
                {
                    errorProvider2.SetError(lastnameText, string.Empty);
                }




                if (string.IsNullOrEmpty(emailText.Text.Trim()))
                {
                    errorProvider2.SetError(emailText, "Email is required");
                    return;
                }
                else
                {
                    errorProvider2.SetError(emailText, string.Empty);
                }
                string validEmail = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                 + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]+(\.[-a-z0-9!#$%&'*+/=?^_`{|}~]+)*))@"
                 + @"([a-z0-9][a-z0-9-]*[a-z0-9]\.)+[a-z][a-z-]*[a-z]$";

                if (Regex.IsMatch(emailText.Text, validEmail))
                {
                    errorProvider2.Clear();
                }
                else
                {
                    errorProvider2.SetError(this.emailText, "Please provide valid Mail address");
                    return;
                }


                var input = passwordText.Text;
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMiniMaxChars = new Regex(@".{8,8}");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");



                if (string.IsNullOrEmpty(passwordText.Text.Trim()))
                {
                    errorProvider2.SetError(passwordText, "Password is required");
                    return;
                }
                else
                {
                    errorProvider2.SetError(passwordText, string.Empty);
                }

                if (!hasLowerChar.IsMatch(input))
                {
                    MessageBox.Show("Password should contain At least one lower case letter");
                    return;
                }
                else if (!hasUpperChar.IsMatch(input))
                {
                    MessageBox.Show("Password should contain At least one upper case letter");
                    return;
                }
                else if (!hasMiniMaxChars.IsMatch(input))
                {
                    MessageBox.Show("Password should not be less than or greater than 8 characters");
                    return;
                }
                else if (!hasNumber.IsMatch(input))
                {
                    MessageBox.Show("Password should contain At least one numeric value");
                    return;

                }

                else if (!hasSymbols.IsMatch(input))
                {
                    MessageBox.Show("Password should contain At least one special case characters");
                    return;
                }


                if (string.IsNullOrEmpty(confirmpassordText.Text.Trim()))
                {
                    errorProvider2.SetError(confirmpassordText, "Confirm passWord is required");
                    return;
                }
                else
                {
                    errorProvider2.SetError(confirmpassordText, string.Empty);
                }

                if (passwordText.Text != confirmpassordText.Text)
                {
                    MessageBox.Show("Password Not Equal");
                }
                else
                {
                    SqlConnection con = new SqlConnection(constring);
                    string q = "Insert into Login2(firstname,lastname,email,password,confirmpass,image)values(@firstname,@lastname,@email,@password,@confirmpass,@image)";
                    SqlCommand cmd = new SqlCommand(q, con);
                    MemoryStream me = new MemoryStream();
                    gunaCirclePictureBox2.Image.Save(me, gunaCirclePictureBox2.Image.RawFormat);
                    byte[] imageBytes = me.ToArray();
                    cmd.Parameters.AddWithValue("firstname", firstName);
                    cmd.Parameters.AddWithValue("lastname", lastName);
                    cmd.Parameters.AddWithValue("email", emailText.Text);
                    cmd.Parameters.AddWithValue("password", HashPassword(passwordText.Text));
                    cmd.Parameters.AddWithValue("confirmpass", HashPassword(confirmpassordText.Text));
                    cmd.Parameters.AddWithValue("image", imageBytes);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Registration successfull.....");
                    firstnameText.Clear();
                    lastnameText.Clear();
                    emailText.Clear();
                    passwordText.Clear();
                    confirmpassordText.Clear();
                    gunaCirclePictureBox2.Image = null;
                }
            }
        }
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void gunaCirclePictureBox2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "select image(*Jpg; *.Png; *Gif|*jpg; *.png; *Gif)";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                gunaCirclePictureBox2.Image =Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(zzz.Text.Trim()))
            {
                errorProvider2.SetError(zzz, "Email is required");
                return;
            }
            else
            {
                errorProvider2.SetError(zzz, string.Empty);
            }



            if (string.IsNullOrEmpty(ppp.Text.Trim()))
            {
                errorProvider2.SetError(ppp, "Password is required");
                return;
            }
            else
            {
                errorProvider2.SetError(ppp, string.Empty);
            }
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string hashedPassword = HashPassword(ppp.Text);
            string q = "select * from Login2 WHERE email = @Email AND password = @Password";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@Email", zzz.Text);
            cmd.Parameters.AddWithValue("@Password", hashedPassword);
            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows == true)
            {
                Panel5.BringToFront();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("please check your email and password");
            }
            con.Close();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Guna2CircleProgressBar1.Value < 100)
            {
                Guna2CircleProgressBar1.Value +=6;
            }
            else
            {
                timer1.Stop();
                Form2 f2 = new Form2();
                f2.emailname = zzz.Text;
                this.Hide();
                f2.Show();
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit(); // Ensures any background tasks are stopped
        }

        private void Guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EmailLoginText_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void PasswordLoginText_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void EmailLoginText_TextChanged_1(object sender, EventArgs e)
        {

        }

        //private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        //{

        //}
        private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordText.PasswordChar == '*' && confirmpassordText.PasswordChar == '*')
            {
                passwordText.PasswordChar = '\0';
                confirmpassordText.PasswordChar = '\0';
            }
            else
            {
                passwordText.PasswordChar = '*';
                confirmpassordText.PasswordChar = '*';
            }
        }

        //private void guna2CustomCheckBox2_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        private void guna2CustomCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ppp.PasswordChar == '*')
            {
                ppp.PasswordChar = '\0';

            }
            else
            {
                ppp.PasswordChar = '*';
            }
        }

        private void emailText_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (panel1.Visible) // If Login panel is active
                {
                    gunaButton1_Click_1(sender, e); // Trigger login button click
                }
                else if (Panel2.Visible) // If Register panel is active
                {
                    gunaButton2_Click(sender, e); // Trigger register button click
                }
            }
        }

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        // Trigger the login button click event
        //        gunaButton1_Click_1(sender, e); // Assuming `gunaButton1_Click_1` is your login button's click handler
        //    }
        //}
    }
}

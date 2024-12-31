using QuickChat.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IdentityModel.Selectors;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickChat
{
    public partial class Form2 : Form
    {
       
        public string emailname { set; get; }
        public Form2()
        {
            InitializeComponent();
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
           
            
        }

        string constring = "Data Source=DESKTOP-2IK592G\\SQLEXPRESS;Initial Catalog=firsttime;Integrated Security=True";
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
       
        private void Form2_Load(object sender, EventArgs e)
        {

            Timer timer = new Timer();
            timer.Interval = (10 * 1000); // Set interval to 10 seconds
            timer.Tick += new EventHandler(timer2_Tick);
            timer.Start();


            MessageChat();
            label2.Text = emailname;
            byte[] getimage = new byte[0];
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "select * from Login2 WHERE email = '" + label2.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                // label1.Text = dataReader[0].ToString();
                label8.Text = dataReader["firstname"].ToString();
                guna2TextBox1.Text = dataReader["firstname"].ToString();



                guna2TextBox2.Text = dataReader["lastname"].ToString();



                guna2TextBox3.Text = dataReader["email"].ToString();




                guna2TextBox4.Text = dataReader["password"].ToString();
                byte[] images = (byte[])dataReader["image"];
                if (images == null)
                {
                    gunaCirclePictureBox1.Image = null;
                    gunaCirclePictureBox2.Image = null;

                }
                else
                {
                    MemoryStream me = new MemoryStream(images);
                    gunaCirclePictureBox1.Image = Image.FromStream(me);
                    gunaCirclePictureBox2.Image = Image.FromStream(me);


                }
            }
            con.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool check;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check)
            {

                panel1.Width += 10;
                if (panel1.Size == panel1.MaximumSize)
                {

                    pictureBox1.Left = +200;
                    timer1.Stop();
                    check = false;
                    pictureBox1.Image = Resources.back_barr;

                }
            }
            else
            {
                panel1.Width -= 10;
                if (panel1.Size == panel1.MinimumSize)
                {
                    pictureBox1.Left = 25;
                    timer1.Stop();
                    check = true;
                    pictureBox1.Image = Resources.back_barr2;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == false)
            {
                panel9.Visible = true;
            }
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            if(panel5.Visible == true)
            {
                panel5.Visible = false;
            }
            timer1.Start();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit(); // Ensure all forms and processes are closed
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {   if (panel4.Visible == false) {
                panel9.Visible= true;
            }
            if(panel9.Visible == true)
            {
                panel9.Visible = false;
            }
            if (panel5.Visible == false)
            {
                panel5.Visible = true;
            }
            else
            {
                panel5.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            if (panel4.Visible == false)
            {
                panel4.Visible = true;
            }
            else
            {
                panel4.Visible = false;
            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }





        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    if (check)
        //    {

        //        panel7.Height += 10;
        //        if (panel7.Size == panel7.MaximumSize)
        //        {


        //            timer2.Stop();
        //            check = false;
        //            pictureBox3.Image = Resources.down_arrow;

        //        }
        //    }
        //    else
        //    {
        //        panel7.Height -= 10;
        //        if (panel7.Size == panel7.MinimumSize)
        //        {

        //            timer2.Stop();
        //            check = true;
        //            pictureBox3.Image = Resources.down_arrow2;
        //        }
        //    }

        //}





        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            UserItem();
            if (panel6.Visible == false)
            {
                panel6.Visible = true;
            }
            else
            {
                panel6.Visible = false;
            }
            if(panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            if(panel5.Visible == true)
            {
                panel5.Visible = false;
            }
        }

        private void UserItem()
        {
            flowLayoutPanel2.Controls.Clear();
            SqlDataAdapter adapter;

            adapter = new SqlDataAdapter("select * from Login2", constring);
            DataTable table = new DataTable();

            adapter.Fill(table);
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    UserControl1[] userControls = new UserControl1[table.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            userControls[i] = new UserControl1();
                            MemoryStream stream = new MemoryStream((byte[])row["image"]);
                            userControls[i].Icon = new Bitmap(stream);
                            userControls[i].Title = row["firstname"].ToString();
                            if (userControls[i].Title == guna2TextBox1.Text)
                            {
                                //    // Remove the control from the FlowLayoutPanel if the title matches
                                flowLayoutPanel2.Controls.Remove(userControls[i]);
                            }

                            else
                            {
                                //Add the control to the FlowLayoutPanel if the title doesn't match
                                flowLayoutPanel2.Controls.Add(userControls[i]);
                            }

                            // Attach a click event handler to the control
                            userControls[i].Click += new System.EventHandler(this.userControl12_Load);
                        }
                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
           
        }
        private void MessageChat()
        {
            flowLayoutPanel3.Controls.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Chat", constring);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (guna2TextBox1.Text == row["userone"].ToString() && label7.Text == row["usertwo"].ToString())
                    {
                        var userControl2 = new UserControl2
                        {
                            Dock = DockStyle.Top,
                            Title = row["message"].ToString()
                        };
                        flowLayoutPanel3.Controls.Add(userControl2);
                        flowLayoutPanel3.ScrollControlIntoView(userControl2);
                    }
                    else if (label7.Text == row["userone"].ToString() && guna2TextBox1.Text == row["usertwo"].ToString())
                    {
                        var userControl3 = new UserControl3
                        {
                            Dock = DockStyle.Top,
                            Title = row["message"].ToString(),
                            Icon = gunaCirclePictureBox3.Image
                        };
                        flowLayoutPanel3.Controls.Add(userControl3);
                        flowLayoutPanel3.ScrollControlIntoView(userControl3);
                    }
                }
            }
        }


        private void userControl11_Load(object sender, EventArgs e)
        {
            
        }

        private void userControl12_Load(object sender, EventArgs e)
        {
            if (panel7.Visible == false && panel8.Visible == false && flowLayoutPanel3.Visible == false)
            {
                panel7.Visible = true;
                panel8.Visible = true;
                flowLayoutPanel3.Visible = true;
            }

            UserControl1 control = (UserControl1)sender;
            label7.Text = control.Title;
            gunaCirclePictureBox3.Image = control.Icon;
            MessageChat();
        }
       
        private void gunaButton3_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            string q = "insert into Chat(userone,usertwo,message)values(@userone,@usertwo,@message)";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@userone", guna2TextBox1.Text);
            cmd.Parameters.AddWithValue("@usertwo", label7.Text);
            cmd.Parameters.AddWithValue("@message", mmbox.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

           
            MessageChat();
            mmbox.Clear();


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageChat();
           
        }

        private void mmbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == true && panel8.Visible == true && flowLayoutPanel3.Visible == true)
            {
                panel7.Visible = false;
                panel8.Visible = false;
                flowLayoutPanel3.Visible = false;
            }
        }

        private void GunaButton2_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == false)
            {
                panel9.Visible = true;
            }
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            if (panel4.Visible == true) { 
                panel4.Visible = false;
            }
            if (panel5.Visible == true)
            {
                panel5.Visible = false;
            }
        }
    }
}


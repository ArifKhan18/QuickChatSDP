using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickChat
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; label1.Text = value; }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {

        }

        //void AddHeighttext()
        //{
        //    UserControl2 user= new UserControl2();
        //    user.BringToFront();
        //    label1.Height = Uilist.GetTextHeight(label1) + 10;

        //}
    }

}

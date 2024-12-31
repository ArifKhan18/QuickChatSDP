using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickChat
{
    public partial class UserControl3 : UserControl
    {   
        public UserControl3()
        {
            InitializeComponent();
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; label1.Text = value; }
        }

        private Image _icon;

        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; gunaCirclePictureBox1.Image = value; }
        }
    }
}

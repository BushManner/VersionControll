using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource1.FullName;
            btnAdd.Text = Resource1.Add;
            btnWrite.Text = Resource1.Write;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
            };
            users.Add(u);
            textBox1.Text = "";
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".csv";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            StreamWriter sw = new StreamWriter(sfd.FileName);
            foreach (var item in users)
            {
                sw.WriteLine(item.ID + ";" + item.FullName);
            }
            sw.Close();
        }
    }
}

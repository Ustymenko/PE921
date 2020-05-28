using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _28052020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            //listView1.Items.Add("Аня");
            ListViewItem anna=listView1.Items.Add("Іщук");
            anna.SubItems.Add("Ання");
            anna.SubItems.Add("95");
            anna.SubItems.Add("12");
            anna.ImageIndex = 3;


            // anna.Group = listView1.Groups[1];

            
            string namegr = "PE921";
            anna.Group =listView1.Groups.OfType<ListViewGroup>().Where(g => g.Header == namegr).FirstOrDefault();


        }
    }
}

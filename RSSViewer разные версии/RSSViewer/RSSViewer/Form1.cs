using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;
using System.Globalization;
namespace RSSViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        GroupBox[] grp = new GroupBox[10];
        int i = 0;
        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grp.Length; i++)
            {
                this.Controls.Remove(grp[i]);
            }
            topic[] top = new topic[10];

            for (int i = 0; i < grp.Length; i++)
            {
                top[i] = new topic(200, 250, 220 * i, "Hello", this);
                top[i].Click += new EventHandler(topic_Click);

            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grp.Length; i++)
            {
                this.Controls.Remove(grp[i]);
            }

        }
        private void topic_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked");
        }



    }
    
}

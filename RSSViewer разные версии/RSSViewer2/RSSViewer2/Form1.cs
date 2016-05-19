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
namespace RSSViewer2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        public string adrs = null;
        String[,] rssData = null;
        Panel pan;

        private String[,] GetRssData(string channel)
        {

            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
            System.Net.WebResponse myResponse = myRequest.GetResponse();

            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();
            rssDoc.Load(rssStream);
            System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");
            String[,] tempRssData = new String[100, 3];

            for (int i = 0; i < rssItems.Count; i++)
            {

                System.Xml.XmlNode rssNode;
                rssNode = rssItems.Item(i).SelectSingleNode("title");
                if (rssNode != null)
                {
                    tempRssData[i, 0] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 0] = "";

                }
                rssNode = rssItems.Item(i).SelectSingleNode("description");
                if (rssNode != null)
                {
                    string html = rssNode.InnerText;

                    html = Regex.Replace(html, "<br>", "\n ");
                    html = Regex.Replace(html, "&quot;", "\"");
                    html = Regex.Replace(html, "&lt;", "<");
                    html = Regex.Replace(html, "&gt;", ">");
                    html = Regex.Replace(html, "<[^>]+>", string.Empty);
                    tempRssData[i, 1] = html;
                }
                else
                {
                    tempRssData[i, 1] = "";
                }
                rssNode = rssItems.Item(i).SelectSingleNode("link");
                if (rssNode != null)
                {
                    tempRssData[i, 2] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 2] = "";
                }
            }
            return tempRssData;


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pan = new Panel();

            pan.AutoScroll = true;
            pan.Location = new Point(1, 27);
            pan.Height = this.Height - 28;
            pan.Width = this.Width - 2;
            pan.BackgroundImage = Properties.Resources.bg;
            this.Controls.Add(pan);
            LoadReq rq = new LoadReq(pan);
        }

       

        #region Allow moving of borderless form 
        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        #endregion
        #region Exit button manip
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Recth;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.ext;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Rectcl;
            Application.Exit();
        }
        #endregion
        #region running load screen
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //base.OnKeyDown(e);
            if (e.KeyCode == Keys.N && e.Control)
            {
                LoadReq rq2 = new LoadReq(pan);
                rq2.BringToFront();
                e.Handled = true;
            }

        }
        #endregion












    }
}

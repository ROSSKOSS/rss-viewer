using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
namespace RSSViewer2
{
    class LoadReq : Panel
    {
        Label l;
        TextBox t;
        Button b;
        Panel p;
        Setup s;
        public LoadReq(Panel pnl)
        {
            p = pnl;
            this.Width = 250;
            this.Height = 150;
            this.Location = new Point(25, (pnl.Height / 2) - 127);
            this.BackColor = Color.Transparent;
            this.BackgroundImage = Properties.Resources.Loadbg;
            
            pnl.Controls.Add(this);

            l = new Label();
            l.Location = new Point((this.Width - l.Width) / 2, 10);
            l.Text = "Choose source:";
            l.ForeColor = Color.Black;
            this.Controls.Add(l);

           t = new TextBox();
           t.Width=230;
           t.Location = new Point((this.Width - t.Width) / 2, 40);
           t.Text = "http://bash.im/rss/";
           
           t.ForeColor = Color.Black;
           this.Controls.Add(t);

           b = new Button();
           b.Width = 100;
           b.Location = new Point((this.Width - b.Width)/ 2 , 90);
           b.Text = "Load";
           b.ForeColor = Color.Black;
           this.Controls.Add(b);
           b.Click += new EventHandler(Delete);

        }
        String[,] rssData = null;
       
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

                    //html = Regex.Replace(html, "<br>", "\n");
                    //html = Regex.Replace(html, "&quot;", "\"");
                    //html = Regex.Replace(html, "&lt;", "<");
                    //html = Regex.Replace(html, "&gt;", ">");
                    //html = Regex.Replace(html, "<[^>]+>", string.Empty);
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
        public void Delete(object sender, EventArgs e)
        {
            
            if (t.Text != null)
            {
                
                String[,] rss = GetRssData(t.Text);
                Setup s = new Setup(p, rss);
            }
            else
            {
                MessageBox.Show("SHIT");
            }
            this.Controls.Clear();
            this.Dispose();
            
        }
    }
}

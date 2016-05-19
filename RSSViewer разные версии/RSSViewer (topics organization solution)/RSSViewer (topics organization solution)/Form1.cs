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
namespace RSSViewer__topics_organization_solution_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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

                   // html = Regex.Replace(html, "<br>", "\n");
                   // html = Regex.Replace(html, "&quot;", "\"");
                   // html = Regex.Replace(html, "&lt;", "<");
                   // html = Regex.Replace(html, "&gt;", ">");
                   // html = Regex.Replace(html, "<[^>]+>", string.Empty);
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
            String[,] rss = GetRssData("http://bash.im/rss");
            for (int i = 0; i < 10;i++ )
            {
                webBrowser1.DocumentText = rss[i, 1];
            }
                

        }
    }
}

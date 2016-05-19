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
namespace RSSClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String[,] rssData = null;
        private String[,] GetRssData(string channel)
        {
            progressBar1.ResetText();
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
            System.Net.WebResponse myResponse = myRequest.GetResponse();

            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();
            rssDoc.Load(rssStream);
            System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");
            String[,] tempRssData = new String[100, 3]; 
            progressBar1.Maximum = rssItems.Count;
            for(int i=0; i<rssItems.Count;i++)
            {
                progressBar1.PerformStep();
                System.Xml.XmlNode rssNode;
                rssNode = rssItems.Item(i).SelectSingleNode("title");
                if(rssNode!=null)
                {
                    tempRssData[i, 0] = rssNode.InnerText;
                }
                else
                {
                    tempRssData[i, 0] = "";

                }
                rssNode = rssItems.Item(i).SelectSingleNode("description");
                if(rssNode !=null)
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

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            rssData = GetRssData(textBox1.Text);
            for(int i=0;i<rssData.GetLength(0);i++)
            {
                if(rssData[i,0]!=null)
                {
                    comboBox1.Items.Add(rssData[i, 0]);
                    comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rssData[comboBox1.SelectedIndex,1]!=null)
            {
                textBox2.Text = rssData[comboBox1.SelectedIndex, 1];
            }
            if (rssData[comboBox1.SelectedIndex, 2] != null)
            {
                linkLabel1.Text = "GoTo: "+rssData[comboBox1.SelectedIndex,0];
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(rssData[comboBox1.SelectedIndex,2]!=null)
            {
                System.Diagnostics.Process.Start(rssData[comboBox1.SelectedIndex, 2]);
            }
        }

       
    }
}

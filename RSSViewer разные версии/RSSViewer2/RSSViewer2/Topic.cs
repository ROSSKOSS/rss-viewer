using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace RSSViewer2
{

    class Topic
    {
        protected int height, width, position, posx;
        protected string namet;
        protected string textt;
        protected string autht;
        protected string datet;
        Panel grb;
        Label textl = new Label();
        Label authl = new Label();
        Label datel = new Label();
        Button fav = new Button();
        Panel pnl;
        Form1 f;
        public Topic(int h, int w, int pos, string name, string text, string auth, string date, Panel pan)
        {
            pnl = pan;
            height = h;
            width = w;
            position = pos;
            autht = auth;
            datet = date;
            namet = name;
            textt = text;

            Position p = new Position();
            p.Get(pan, width);
            posx = p.Return();
            grb = new Panel();
            grb.BackColor = Color.Transparent;
            grb.BackgroundImage = Properties.Resources.Topicbg;
            grb.Width = width;
            grb.Height = height;
            
            grb.Location = new Point(posx, pos * height + 10);
            grb.Name = "Topic #" + pos;
            grb.Text = "'" + name + "'" + " " + auth + " " + date;
            pan.Controls.Add(grb);
            textl = new Label();
            p.Get(width, width - 20);
            Position p2 = new Position();
            Label header = new Label();
            header.Location = new Point(5, 7);
            header.Text = name;
            grb.Controls.Add(header);
            p2.Get(height, height - 20);
            textl.Location = new Point(8, 28);
            textl.Width = width - 16;
            textl.Height = height - 35;
            //textl.Multiline = true;
            textl.Text = textt;
            // textl.ReadOnly = true;
            //fav = new Button();
            //fav.Location = new Point(width + 20, pos * height + 45);
            //fav.Text = "Favor";
            //fav.Width = 40;
            //fav.Height = 40;
            //pan.Controls.Add(fav);
            grb.Controls.Add(textl);
        }
        
    }
}

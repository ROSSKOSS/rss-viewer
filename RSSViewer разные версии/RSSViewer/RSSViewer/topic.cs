using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSViewer
{
  public class topic: GroupBox
    {
        int h, w, y;
        GroupBox grp;
        Label txt;
        string name;
        Form1 op;
        public topic(int h, int w,int y, string name, Form1 op)
        {
            name = "NULL";
            grp =new GroupBox();
            grp.Width = w;
            grp.Height = h;
            grp.Location = new Point(9, 30+y);
            grp.Name = name;
            grp.Text = "Topic Title" ;
            grp.Tag = name;
            op.Controls.Add(grp);

            txt = new Label();
            txt.Width = w - 6;
            txt.Height = h - 30;
            txt.Location = new Point(3, 20);
            txt.Name= name;
            txt.BackColor = Color.Red;
            txt.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas id iaculis metus. Morbi nisi velit, convallis sed sapien quis, condimentum dictum felis. Fusce purus lorem, efficitur convallis magna ac, mattis varius neque. Praesent vel massa ut dolor consequat tristique ac sed urna. Vestibulum gravida malesuada justo sed rutrum. Mauris vitae.";
            grp.Controls.Add(txt);
            txt.Click += new EventHandler(topic_Click);
        }
        public void topic_Click(object sender, EventArgs eArgs)
        {

            txt.BackColor = Color.Black;
        }
    

        public void Show()
        {

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace RSSViewer2
{
    class Setup
    {
        Topic[] t;
        int size=0;
        public Setup(Panel pan, String[,] rss)
        {

            Topic[] t = new Topic[rss.GetLength(0)];

            for (int i = 0; i < rss.GetLength(0); i++)
            {
                if (rss[i, 1] != null)
                {
                    size++;
                    t[i] = new Topic(200, 250, i, rss[i,0], rss[i, 1], "Author", "10.09.1996", pan);
                }

            }
        }
         ~Setup()
        {
            
             
        }
    }
}

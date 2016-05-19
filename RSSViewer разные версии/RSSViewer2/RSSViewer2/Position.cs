using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RSSViewer2
{
    class Position
    {
        int xb;
       
        Panel p;
        public Position()
        {
            
        }
        public void Get(Panel pan, int w)
        {
             xb = Convert.ToInt32((pan.Width - w-25) / 2);
        }
          public void Get(int wb, int w)
        {
             xb = Convert.ToInt32((wb - w-25) / 2);
        }
      
        public int Return()
        {
            return xb;
        }
    }
}

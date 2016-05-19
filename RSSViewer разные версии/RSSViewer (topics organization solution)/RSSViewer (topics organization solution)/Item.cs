using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace RSSViewer__topics_organization_solution_
{
    class Item:Panel
    {
        public Item()
        {
            this.Height = 20;
            this.Width = 20;
            this.BackColor = Color.Red;
            this.Name = "i'm the Item.";
        }
    }
}

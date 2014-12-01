using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VideoBookApplication.common.view
{
    public partial class TitlePanel : Panel
    {
        public TitlePanel(String title, Panel parent)
        {
            InitializeComponent();
            this.BackColor = parent.BackColor;
            this.Size = new Size(parent.Size.Width, 50);

            labelTitle.Text = title;
            this.Controls.Add(labelTitle);
        }
    }
}

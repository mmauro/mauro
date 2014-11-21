using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;

namespace VideoBookApplication.common.view
{
    public partial class LogoutPanel : Panel
    {
        private GlobalApplicationObject globalObject;
        private Form parent;
        public LogoutPanel(ref GlobalApplicationObject globalObject, Form parent )
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            initPanel();
        }

        private void initPanel()
        {
            //Panel Settings
            this.BackColor = LayoutManager.getColorPanelLogin();
            this.Size = new Size(parent.Size.Width, 65);

            //Image
            pictureBox1.Location = new Point(5, 8);
            this.Controls.Add(pictureBox1);

            //Label User
            labelUser.Text = "Benvenuto: " + globalObject.user.userName;
            labelUser.Location = new Point(5 + 10 + pictureBox1.Size.Width, 20);
            this.Controls.Add(labelUser);

            //Button Change User
            buttonLogout.Location = new Point(parent.Size.Width - (25 + buttonLogout.Size.Width), 8);
            this.Controls.Add(buttonLogout);
            toolTip1.SetToolTip(buttonLogout, "Cambia Utente");

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            globalObject.destroy();
            StartApp formLogin = new StartApp();
            parent.Visible = false;
            formLogin.ShowDialog();

            //Close Application at this point
            Utility.closeApplication();

        }
    }
}

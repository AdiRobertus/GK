using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK.main
{
    public partial class ChefForm : Core
    {
        public ChefForm()
        {
            InitializeComponent();
        }

        private void ChefForm_Load(object sender, EventArgs e)
        {
            var wel = db.MsEmployee
                .Where(X => X.Position == "chef")
                .FirstOrDefault<MsEmployee>();

            lb_admin.Text = wel.Name;
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            Hide();
            new chef.ViewForm().ShowDialog();
            Show();
        }

        private void btn_password_Click(object sender, EventArgs e)
        {
            Hide();
            new admin.CpForm().ShowDialog();
            Show();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class AdminForm : Core
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            var wel = db.MsEmployee
                .Where(X => X.Position == "admin")
                .FirstOrDefault<MsEmployee>();

            lb_admin.Text = wel.Name;
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            Hide();
            new admin.OrderForm().ShowDialog();
            Show();
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            Hide();
            new admin.EmployeeForm().ShowDialog();
            Show();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            Hide();
            new admin.MenuForm().ShowDialog();
            Show();
        }

        private void btn_member_Click(object sender, EventArgs e)
        {
            Hide();
            new admin.MemberForm().ShowDialog();
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

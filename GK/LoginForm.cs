using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK
{
    public partial class LoginForm : Core
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        bool IsValid()
        {
            if (Controls.IsAnyEmpty())
            {
                MessageBox.Show("Email or password not filled");
                return false;
            }
            return true;
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            var employee = db.MsEmployee
                .FirstOrDefault(X =>
                    tb_email.Text == X.Email &&
                    tb_pass.Text == X.Password
                );

            if (employee == null)
            {
                MessageBox.Show("user not found");
                return;
            }

            Hide();
            switch (employee.Position)
            {
                case "admin": new main.AdminForm().ShowDialog();
                    break;
                case "cashier": new main.CashierForm().ShowDialog();
                    break;
                case "chef": new main.ChefForm().ShowDialog();
                    break;
            }
            Show();
        }
    }
}

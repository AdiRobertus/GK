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
    public partial class CashierForm : Core
    {
        public CashierForm()
        {
            InitializeComponent();
        }

        private void CashierForm_Load(object sender, EventArgs e)
        {
            var wel = db.MsEmployee
                .Where(X => X.Position == "cashier")
                .FirstOrDefault<MsEmployee>();

            lb_admin.Text = wel.Name;
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            Hide();
            new Cashier.PaymentForm().ShowDialog();
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

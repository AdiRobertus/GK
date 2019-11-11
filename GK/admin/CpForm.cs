  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK.admin
{
    public partial class CpForm : Core
    {
        public CpForm()
        {
            InitializeComponent();
        }


        bool IsValid()
        {
            if (Controls.IsAnyEmpty())
            {
                MessageBox.Show("all must be filled");
                return false;
            }

            if (tb_new.Text != tb_confirm.Text)
            {
                MessageBox.Show("password not same");
                return false;
            }

            return true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                return;
            }
            var id = db.MsEmployee
                .Where(X => X.Password == tb_old.Text)
                .Select(X => new
                {
                    X.Password
                }).ToString();

            id = tb_new.Text.ToString();

            db.SaveChanges();
            Controls.ClearFields();
        }
    }
}

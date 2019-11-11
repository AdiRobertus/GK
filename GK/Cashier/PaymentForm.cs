using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK.Cashier
{
    public partial class PaymentForm : Core
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            dataGridView1.DataSource = db.orderDetail
                .Where(X => X.Orderid == comboBox1.Text)
                .Select(X => new
                {
                    X.Id,
                    X.MsMenu.Name,
                    X.Qty,
                    Total = X.MsMenu.Price * X.Qty
                }).ToArray();
            dataGridView1.Columns["Id"].Visible = false;

        }
        private void PaymentForm_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Orderid";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = db.orderDetail
                .Select(X => new {
                    X.Id,
                    X.Orderid
                }).ToArray();

            textBox1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.ToString() == "Credit")
            {
                textBox1.Enabled = true;
            }

            LoadData();
        }
    }
}

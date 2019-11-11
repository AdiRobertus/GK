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
    public partial class OrderForm : Core
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        orderDetail order1;
        orderDetail order2;
        OrderHeader order3;
        MsMenu Menu = new MsMenu();
        List<orderDetail> orders = new List<orderDetail>();

        void LoadDataM()
        {
            dgv1.DataSource = db.MsMenu
                .Select(X => new
                {
                    X.id,
                    X.Name,
                    X.Price,
                    X.Carbo,
                    X.Protein
                }).ToArray();
            dgv1.Columns["id"].Visible = false;
        }

        void LoadDataD()
        {
            dgv2.DataSource = orders
                .Select(X => new {
                    X.Id,
                    X.MsMenu.Name,
                    Qty = int.Parse(tb_qty.Text),
                    X.MsMenu.Carbo,
                    X.MsMenu.Protein,
                    X.MsMenu.Price,
                    Total = X.MsMenu.Price * int.Parse(tb_qty.Text)
                }).ToArray();
            dgv2.Columns["Id"].Visible = false;
        }

        void SetTotal()
        {
            int qty = int.Parse(tb_qty.Text);
            int carbo = orders.Sum(X => X.MsMenu.Carbo * qty);
            int protein = orders.Sum(X => X.MsMenu.Protein * qty);
            int total = orders.Sum(X => X.MsMenu.Price * qty);

            lb_carbo.Text = carbo.ToString();
            lb_protein.Text = protein.ToString();
            lb_total.Text = total.ToString();
        }
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgv1[0, e.RowIndex].Value.ToString());

            order1 = db.orderDetail.Find(id);

            Menu = db.MsMenu.Find(id);
            tb_name.Text = Menu.Name;

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadDataM();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            orders.Add(order1);
            SetTotal();
            LoadDataD();
            order1 = null;
            Controls.ClearFields();
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgv2[0, e.RowIndex].Value.ToString());

            order2 = db.orderDetail.Find(id);

            tb_name.Text = order2.MsMenu.Name;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (order2 == null)
            {
                MessageBox.Show("Select Data first");
                return;
            }
            orders.Remove(order2);

            db.SaveChanges();
            LoadDataD();
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            string id = DateTime.Now.ToString("yyyyMMdd") + "0001";

            order3.Id = id;
            order3.Employeeid = "EM0001";
            order3.Memberid = 1;
            order3.Date = DateTime.Now.Date;

            db.OrderHeader.Add(order3);
            db.SaveChanges();
        }
    }
}

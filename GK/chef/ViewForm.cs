using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK.chef
{
    public partial class ViewForm : Core
    {
        public ViewForm()
        {
            InitializeComponent();
        }
        
        void LoadDataOrder()
        {
            dgvOrder.DataSource = db.orderDetail
                .Where(X => X.Orderid == cb_id.Text.ToString())
                .Select(X => new
                {
                    X.Id,
                    X.MsMenu.Name,
                    X.Qty
                }).ToArray();

            dgvOrder.Columns["Id"].Visible = false;
        }

        void LoadDataOver()
        {
            dgvOv.DataSource = db.orderDetail
                   .Select(X => new {
                       X.Id,
                       X.MsMenu.Name,
                       X.Qty
                   })
                   .ToArray();
        }
        void CbOrder()
        {
            cb_id.DisplayMember = "Orderid";
            cb_id.ValueMember = "Id";
            cb_id.DataSource = db.orderDetail
                .Select(X => new {
                    X.Id,
                    X.Orderid
                }).ToArray();
        }

        void CbOver()
        {
            if(cb_sort.Text == "Id")
            {
                dgvOv.DataSource = db.orderDetail
                    .Select(X => new {
                        X.Id,
                        X.MsMenu.Name,
                        X.Qty
                    })
                    .OrderBy(X => X.Id)
                    .ToArray();
            }

            if (cb_sort.Text == "Nama")
            {
                dgvOv.DataSource = db.orderDetail
                    .Select(X => new {
                        X.Id,
                        X.MsMenu.Name,
                        X.Qty
                    })
                    .OrderBy(X => X.Name)
                    .ToArray();
            }

            if (cb_sort.Text == "Qty")
            {
                dgvOv.DataSource = db.orderDetail
                    .Select(X => new {
                        X.Id,
                        X.MsMenu.Name,
                        X.Qty
                    })
                    .OrderBy(X => X.Qty)
                    .ToArray();
            }
        }
        private void ViewForm_Load(object sender, EventArgs e)
        {
            CbOrder();
            LoadDataOver();
            cb_sort.SelectedItem = "Id";
            var cbx = new DataGridViewComboBoxColumn();

            cbx.HeaderText = "";
            cbx.DisplayMember = "StatusBar";
            cbx.ValueMember = "Id";
            cbx.DataSource = db.orderDetail
                .Select(X => new {
                    X.Id,
                    X.Status
                });
        }

        private void cb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataOrder();
        }

        private void cb_sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbOver();
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            dgvOv.DataSource = db.orderDetail
               .Where(X =>
                   X.MsMenu.Name == tb_search.Text
               )
               .Select(X => new
               {
                   X.Id,
                   X.MsMenu.Name,
                   X.Qty
               }).ToArray();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dgvOv.DataSource = db.orderDetail
              .Where(X =>
                  X.MsMenu.Name == tb_search.Text
              )
              .Select(X => new
              {
                  X.Id,
                  X.MsMenu.Name,
                  X.Qty
              }).ToArray();
        }
    }
}

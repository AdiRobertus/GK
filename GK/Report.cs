using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GK
{
    public partial class Report : Core
    {
        public Report()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            dgv.DataSource = db.orderDetail
                .Where(X => X.OrderHeader.Date.Month.ToString() == cbFrom.Text.ToString() || X.OrderHeader.Date.Month.ToString() == cbTo.Text.ToString())
                .Select(X => new
                {
                    X.Id,
                    X.OrderHeader.Date.Month

                }).ToArray();
        }

        void LoadCbFrom()
        {
            cbFrom.DisplayMember = "Month";
            cbFrom.ValueMember = "Id";
            cbFrom.DataSource = db.orderDetail
                .Select(X => new {
                    X.Id,
                    X.OrderHeader.Date.Month
                }).ToList();
        }

        void LoadCbTo()
        {
            cbTo.DisplayMember = "Month";
            cbTo.ValueMember = "Id";
            cbTo.DataSource = db.orderDetail
                .Select(X => new {
                    X.Id,
                    X.OrderHeader.Date.Month
                }).ToList();
        }
        private void Report_Load(object sender, EventArgs e)
        {
            LoadCbFrom();
        }

        private void btnGenrate_Click(object sender, EventArgs e)
        {
            LoadData();
            chart1.Titles.Add("Income in milion");
            chart1.DataSource = db.orderDetail
                .Select(X => new {
                    X.Id,
                    X.OrderHeader.Date.Month
                });
            chart1.Series["income"].XValueMember = "Month";
            chart1.Series["income"].YValueMembers = "";
        }
    }
}

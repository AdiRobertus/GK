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
    public partial class MemberForm : Core, ICrud<MsMember>
    {
        public MemberForm()
        {
            InitializeComponent();
        }

        public MsMember Data { get; set; }
        public bool IsInserting { get; set; }

        public bool IsValid()
        {
            if (Controls.IsAnyEmpty(tb_search))
            {
                MessageBox.Show("All data must be filled");
                return false;
            }

            if (!tb_email.Text.IsEmail())
            {
                return false;
            }

            return true;
        }

        public void LoadData()
        {
            dgv.DataSource = db.MsMember
                .Select(X => new
                {
                    X.Id,
                    X.Name,
                    X.Email,
                    X.Handphone
                }).ToArray();
        }

        public void NormalMode()
        {
            Controls.ChangeState(false);
            btn_cancel.Enabled = false;
            btn_delete.Enabled = true;
            btn_insert.Enabled = true;
            btn_update.Enabled = true;
            btn_save.Enabled = false;
            Data = null;
        }

        public void SaveData()
        {
            if (!IsValid())
            {
                return;
            }

            if (IsInserting)
            {
                Data = new MsMember();
            }

            Data.Name = tb_name.Text;
            Data.Email = tb_email.Text;
            Data.Handphone = tb_hp.Text;
            Data.JoinDate = DateTime.Now.Date;

            if (IsInserting)
            {
                db.MsMember.Add(Data);
            }

            db.SaveChanges();
            NormalMode();
            LoadData();
            Controls.ClearFields();
        }

        public void SaveMode()
        {
            Controls.ChangeState(true);
            btn_cancel.Enabled = true;
            btn_delete.Enabled = false;
            btn_insert.Enabled = false;
            btn_update.Enabled = false;
            btn_save.Enabled = true;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            LoadData();
            NormalMode();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            IsInserting = true;
            Controls.ClearFields();
            SaveMode();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            IsInserting = false;
            SaveMode();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (Data == null)
            {
                MessageBox.Show("Select Data First");
                return;
            }

            if (MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.MsMember.Remove(Data);
                db.SaveChanges();
                NormalMode();
            }
            LoadData();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            NormalMode();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            try
            {
                int id = int.Parse(dgv[0, e.RowIndex].Value.ToString());

                Data = db.MsMember.Find(id);

                tb_id.Text = Data.Id.ToString();
                tb_name.Text = Data.Name.ToString();
                tb_email.Text = Data.Email.ToString();
                tb_hp.Text = Data.Handphone.ToString();
            }
            catch
            {

            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            dgv.DataSource = db.MsMember
                .Where(X =>
                    X.Id == int.Parse(tb_search.Text) ||
                    X.Name == tb_search.Text ||
                    X.Email == tb_search.Text
                )
                .Select(X => new
                {
                    X.Id,
                    X.Name,
                    X.Email,
                    X.Handphone
                }).ToArray();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (tb_search.Text == "")
            {
                MessageBox.Show("error");
                return;
            }

            dgv.DataSource = db.MsMember
                .Where(X =>
                    X.Id == int.Parse(tb_search.Text) ||
                    X.Name == tb_search.Text ||
                    X.Email == tb_search.Text
                )
                .Select(X => new
                {
                    X.Id,
                    X.Name,
                    X.Email,
                    X.Handphone
                }).ToArray();
        }
    }
}

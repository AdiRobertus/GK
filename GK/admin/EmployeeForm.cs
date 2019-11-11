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
    public partial class EmployeeForm : Core, ICrud<MsEmployee>
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        public MsEmployee Data { get; set; }
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
            dgv.DataSource = db.MsEmployee
                .Select(X => new
                {
                    X.Id,
                    X.Name,
                    X.Email,
                    X.Position
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
                Data = new MsEmployee();
            }

            Data.Id = tb_id.Text;
            Data.Name = tb_name.Text;
            Data.Email = tb_email.Text;
            Data.Handphone = tb_hp.Text;
            Data.Password = "Password";
            Data.Position = cb_position.Text.ToString();

            if (IsInserting)
            {
                db.MsEmployee.Add(Data);
            }

            db.SaveChanges();
            NormalMode();
            Controls.ClearFields();
            LoadData();
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

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            cb_position.DisplayMember = "Position";
            cb_position.ValueMember = "Id";
            cb_position.DataSource = db.MsEmployee
                .Select(X => new
                {
                    X.Id,
                    X.Position
                }).ToArray();

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

            if (MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                db.MsEmployee.Remove(Data);
                db.SaveChanges();
                NormalMode();
            }

            LoadData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            try
            { 
            string id = dgv[0, e.RowIndex].Value.ToString();

            Data = db.MsEmployee.Find(id);

            tb_id.Text = Data.Id.ToString();
            tb_name.Text = Data.Name.ToString();
            tb_email.Text = Data.Email.ToString();
            tb_hp.Text = Data.Handphone.ToString();
            cb_position.DisplayMember = Data.Position.ToString();
            }
            catch
            {

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            NormalMode();
            Controls.ClearFields();
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            dgv.DataSource = db.MsEmployee
                .Where(X =>
                    X.Id == tb_search.Text ||
                    X.Name == tb_search.Text ||
                    X.Email == tb_search.Text ||
                    X.Position == tb_search.Text
                )
                .Select(X => new
                {
                    X.Id,
                    X.Name,
                    X.Email,
                    X.Handphone,
                    X.Position
                }).ToArray();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dgv.DataSource = db.MsEmployee
                .Where(X =>
                    X.Id == tb_search.Text ||
                    X.Name == tb_search.Text ||
                    X.Email == tb_search.Text ||
                    X.Position == tb_search.Text
                )
                .Select(X => new
                {
                    X.Id,
                    X.Name,
                    X.Email,
                    X.Handphone,
                    X.Position
                }).ToArray();
        }
    }
}

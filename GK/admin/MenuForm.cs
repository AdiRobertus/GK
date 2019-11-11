using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK.admin
{
    public partial class MenuForm : Core,ICrud<MsMenu>
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        public MsMenu Data { get; set; }
        public bool IsInserting { get; set; }

        public bool IsValid()
        {
            if (Controls.IsAnyEmpty(tb_search))
            {
                MessageBox.Show("All data must be filled");
                return false;
            }

            if (!tb_price.Text.IsNumber())
            {
                MessageBox.Show("Price must be number");
                return false;
            }

            if (!tb_carbon.Text.IsNumber())
            {
                MessageBox.Show("Carbo must be number");
                return false;
            }

            if (!tb_protein.Text.IsNumber())
            {
                MessageBox.Show("Protein must be number");
                return false;
            }
            return true;
        }

        public void LoadData()
        {
            dgv.DataSource = db.MsMenu
                .Select(X => new
                {
                    X.id,
                    X.Name,
                    X.Price,
                    X.Carbo,
                    X.Protein
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
                Data = new MsMenu();
            }

            Data.id = int.Parse(tb_id.Text);
            Data.Name = tb_name.Text;
            Data.Photo = tb_photo.Text;
            Data.Price = int.Parse(tb_price.Text);
            Data.Carbo = int.Parse(tb_carbon.Text.ToString());
            Data.Protein = int.Parse(tb_price.Text.ToString());

            if (IsInserting)
            {
                db.MsMenu.Add(Data);
            }

            db.SaveChanges();
            LoadData();
            NormalMode();
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
                db.MsMenu.Remove(Data);
                db.SaveChanges();
                NormalMode();
            }
            LoadData();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            LoadData();
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

                Data = db.MsMenu.Find(id);

                tb_id.Text = Data.id.ToString();
                tb_name.Text = Data.Name.ToString();
                tb_price.Text = Data.Price.ToString();
                tb_photo.Text = Data.Photo.ToString();
                tb_protein.Text = Data.Protein.ToString();
                tb_carbon.Text = Data.Carbo.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                tb_photo.Text = Path.GetFileName(opf.FileName);
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
            pictureBox1.Image = null;
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            dgv.DataSource = db.MsMenu
               .Where(X =>
                   X.id == int.Parse(tb_search.Text.ToString()) ||
                   X.Name == tb_search.Text ||
                   X.Price == int.Parse(tb_search.Text) ||
                   X.Carbo == int.Parse(tb_search.Text)
               )
               .Select(X => new
               {
                   X.id,
                   X.Name,
                   X.Price,
                   X.Carbo
               }).ToArray();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dgv.DataSource = db.MsMenu
               .Where(X =>
                   X.id == int.Parse(tb_search.Text.ToString()) ||
                   X.Name == tb_search.Text ||
                   X.Price == int.Parse(tb_search.Text) ||
                   X.Carbo == int.Parse(tb_search.Text)
               )
               .Select(X => new
               {
                   X.id,
                   X.Name,
                   X.Price,
                   X.Carbo
               }).ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btl.Forms
{
    public partial class frmmausac : Form
    {
        DataTable dt;
        public frmmausac()
        {
            InitializeComponent();
        }

        private void frmmausac_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            Load_DataGridView();
            txtmamau.Enabled = false;
            btnluu.Enabled = false;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Mamau, Tenmau FROM tblmausac";
            dt = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = dt;

            //do dl tu bang vao datagridview

            dataGridView1.Columns[0].HeaderText = "Mã màu";
            dataGridView1.Columns[1].HeaderText = "Tên màu";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dataGridView1.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
     MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmamau.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
  MessageBoxIcon.Information);
                return;
            }
           txtmamau.Text = dataGridView1.CurrentRow.Cells["Mamau"].Value.ToString();
           txttenmau.Text = dataGridView1.CurrentRow.Cells["Tenmau"].Value.ToString();
            btnxoa.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
           txtmamau.Enabled = true;
           txttenmau.Focus();
        }
        private void ResetValues()
        {
            txtmamau.Text = "";
            txttenmau.Text = "";


        }

        private void btnluu_Click(object sender, EventArgs e)
        {

            string sql;
            if (txtmamau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmamau.Focus();
                return;
            }
            if (txttenmau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên màu", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenmau.Focus();
                return;
            }
            sql = "SELECT Mamau FROM tblmausac WHERE Mamau=N'" + txtmamau.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã màu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmamau.Focus();
                txttenmau.Text = "";
                return;
            }
            sql = "INSERT INTO tblmausac(Mamau,Tenmau) VALUES(N'" + txtmamau.Text + "',N'" + txttenmau.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;

            btnluu.Enabled = false;
            txtmamau.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtmamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenmau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên màu", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenmau.Focus();
                return;
            }
            sql = "UPDATE tblmausac SET Tenmau=N'" + txttenmau.Text.ToString() + "' WHERE Mamau=N'" + txtmamau.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtmamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblmausac WHERE Mamau=N'" + txtmamau.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();

            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

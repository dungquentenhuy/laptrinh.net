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
    public partial class frmtheloai : Form
    {
        DataTable dt;
        public frmtheloai()
        {
            InitializeComponent();
        }

        private void frmtheloai_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            Load_DataGridView();
            txtmaloai.Enabled = false;
            btnluu.Enabled = false;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Maloai, Tenloai FROM tbltheloai";
            dt = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = dt;

            //do dl tu bang vao datagridview

            dataGridView1.Columns[0].HeaderText = "Mã loại";
            dataGridView1.Columns[1].HeaderText = "Tên loại";
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
                txtmaloai.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
  MessageBoxIcon.Information);
                return;
            }
            txtmaloai.Text = dataGridView1.CurrentRow.Cells["Maloai"].Value.ToString();
            txttenloai.Text = dataGridView1.CurrentRow.Cells["Tenloai"].Value.ToString();
            btnxoa.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmaloai.Enabled = true;
            txttenloai.Focus();

        }
        private void ResetValues()
        {
            txtmaloai.Text = "";
            txttenloai.Text = "";


        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmaloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloai.Focus();
                return;
            }
            if (txttenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloai.Focus();
                return;
            }
            sql = "SELECT Maloai FROM tbltheloai WHERE Maloai=N'" + txtmaloai.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloai.Focus();
                txttenloai.Text = "";
                return;
            }
            sql = "INSERT INTO tbltheloai(Maloai,Tenloai) VALUES(N'" + txtmaloai.Text + "',N'" + txttenloai.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;

            btnluu.Enabled = false;
            txtmaloai.Enabled = false;
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
            if (txtmaloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloai.Focus();
                return;
            }
            sql = "UPDATE tbltheloai SET Tenloai=N'" + txttenloai.Text.ToString() + "' WHERE Maloai=N'" + txtmaloai.Text + "'";
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
            if (txtmaloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tbltheloai WHERE Maloai=N'" + txtmaloai.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }


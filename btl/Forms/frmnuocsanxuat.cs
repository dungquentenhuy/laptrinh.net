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
    public partial class frmnuocsanxuat : Form
    {
        DataTable dt;
        public frmnuocsanxuat()
        {
            InitializeComponent();
        }

        private void frmnuocsanxuat_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            Load_DataGridView();
            txtmanuoc.Enabled = false;
            btnluu.Enabled = false;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Manuoc, Tennuoc FROM tblnuocsanxuat";
            dt = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = dt;

            //do dl tu bang vao datagridview

            dataGridView1.Columns[0].HeaderText = "Mã nước";
            dataGridView1.Columns[1].HeaderText = "Tên nước";
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
                txtmanuoc.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
  MessageBoxIcon.Information);
                return;
            }
            txtmanuoc.Text = dataGridView1.CurrentRow.Cells["Manuoc"].Value.ToString();
            txttennuoc.Text = dataGridView1.CurrentRow.Cells["Tennuoc"].Value.ToString();
            btnxoa.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmanuoc.Enabled = true;
            txttennuoc.Focus();

        }
        private void ResetValues()
        {
            txtmanuoc.Text = "";
            txttennuoc.Text = "";


        }

        private void btnluu_Click(object sender, EventArgs e)
        {

            string sql;
            if (txtmanuoc.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nước", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanuoc.Focus();
                return;
            }
            if (txttennuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nước", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennuoc.Focus();
                return;
            }
            sql = "SELECT Manuoc FROM tblnuocsanxuat WHERE Manuoc=N'" + txtmanuoc.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nước này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanuoc.Focus();
                txttennuoc.Text = "";
                return;
            }
            sql = "INSERT INTO tblnuocsanxuat(Manuoc,Tennuoc) VALUES(N'" + txtmanuoc.Text + "',N'" + txttennuoc.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;

            btnluu.Enabled = false;
            txtmanuoc.Enabled = false;
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
            if (txtmanuoc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttennuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nước", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennuoc.Focus();
                return;
            }
            sql = "UPDATE tblnuocsanxuat SET Tennuoc=N'" + txttennuoc.Text.ToString() + "' WHERE Manuoc=N'" + txtmanuoc.Text + "'";
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
            if (txtmanuoc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblnuocsanxuat WHERE Manuoc=N'" + txtmanuoc.Text + "'";
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
    


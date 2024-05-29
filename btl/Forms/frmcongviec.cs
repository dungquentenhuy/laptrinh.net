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
    public partial class frmcongviec : Form
    {
        DataTable tblCV;
        public frmcongviec()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            txtmacongviec.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblcongviec";
            tblCV = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblCV;
            DataGridView.Columns[0].HeaderText = "Mã công việc";
            DataGridView.Columns[1].HeaderText = "Tên công việc";
            DataGridView.Columns[2].HeaderText = "Lương tháng";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 150;
            DataGridView.Columns[2].Width = 150;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmacongviec.Focus();
                return;
            }
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmacongviec.Text = DataGridView.CurrentRow.Cells["Macv"].Value.ToString();
            txttencongviec.Text = DataGridView.CurrentRow.Cells["Tencv"].Value.ToString();
            txtluongthang.Text = DataGridView.CurrentRow.Cells["Luongthang"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }
        private void ResetValues()
        {
            txtmacongviec.Text = "";
            txttencongviec.Text = "";
            txtluongthang.Text = "";
            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmacongviec.Enabled = true;
            txtmacongviec.Focus();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmacongviec.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmacongviec.Focus();
                return;
            }
            if (txttencongviec.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttencongviec.Focus();
                return;
            }
            if (txtluongthang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lương tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtluongthang.Focus();
                return;
            }
           


            sql = "SELECT macv FROM tblcongviec WHERE Macv=N'" + txtmacongviec.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã công việc này đã có, bạn phải nhập mã khác", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmacongviec.Focus();
                txtmacongviec.Text = "";
                return;
            }
            sql = "INSERT INTO tblcongviec(Macv,Tencv,Luongthang) VALUES(N'" + txtmacongviec.Text.Trim() + "', N'" + txttencongviec.Text.Trim() + "', N'" + txtluongthang.Text.Trim() + "', '" ;
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmacongviec.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmacongviec.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttencongviec.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttencongviec.Focus();
                return;
            }
            if (txtluongthang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lương tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtluongthang.Focus();
                return;
            }
            

            sql = "UPDATE tblcongviec SET  Tencv=N'" + txttencongviec.Text.Trim().ToString() + "',Luongthang=N'" + txtluongthang.Text.Trim().ToString()  + "' WHERE Macv=N'" + txtmacongviec.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmacongviec.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblkhachhang WHERE Makhach=N'" + txtmacongviec.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmacongviec.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class frmtinhtrang : Form
    {
        DataTable dt;
        public frmtinhtrang()
        {
            InitializeComponent();
        }

        private void frmtinhtrang_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            Load_DataGridView();
            txtmatinhtrang.Enabled = false;
            btnluu.Enabled = false;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Matinhtrang, Tentinhtrang FROM tbltinhtrang";
            dt = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = dt;

            //do dl tu bang vao datagridview

            dataGridView1.Columns[0].HeaderText = "Mã tình trạng";
            dataGridView1.Columns[1].HeaderText = "Tên tình trạng";
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
                txtmatinhtrang.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
  MessageBoxIcon.Information);
                return;
            }
            txtmatinhtrang.Text = dataGridView1.CurrentRow.Cells["Matinhtrang"].Value.ToString();
            txttentinhtrang.Text = dataGridView1.CurrentRow.Cells["Tentinhtrang"].Value.ToString();
            btnxoa.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmatinhtrang.Enabled = true;
            txttentinhtrang.Focus();

        }
        private void ResetValues()
        {
            txtmatinhtrang.Text = "";
            txttentinhtrang.Text = "";


        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmatinhtrang.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã tình trạng", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmatinhtrang.Focus();
                return;
            }
            if (txttentinhtrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tình trạng", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentinhtrang.Focus();
                return;
            }
            sql = "SELECT Matinhtrang FROM tbltinhtrang WHERE Matinhtrang=N'" + txtmatinhtrang.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã tình trạng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmatinhtrang.Focus();
                txttentinhtrang.Text = "";
                return;
            }
            sql = "INSERT INTO tbltinhtrang(Matinhtrang,Tentinhtrang) VALUES(N'" + txtmatinhtrang.Text + "',N'" + txttentinhtrang.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;

            btnluu.Enabled = false;
            txtmatinhtrang.Enabled = false;
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
            if (txtmatinhtrang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttentinhtrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tình trạng", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentinhtrang.Focus();
                return;
            }
            sql = "UPDATE tbltinhtrang SET Tentinhtrang=N'" + txttentinhtrang.Text.ToString() + "' WHERE Matinhtrang=N'" + txtmatinhtrang.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (txtmatinhtrang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tbltinhtrang WHERE Matinhtrang=N'" + txtmatinhtrang.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();

            }
        }
    }
    }


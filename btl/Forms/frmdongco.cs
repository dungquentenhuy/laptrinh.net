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
    public partial class frmdongco : Form
    {
        DataTable dt;
        public frmdongco()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
     MessageBoxButtons.OK, MessageBoxIcon.Information);
               txtmadongco.Focus();
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
  MessageBoxIcon.Information);
                return;
            }
         txtmadongco.Text = dataGridView1.CurrentRow.Cells["Madongco"].Value.ToString();
            txttendongco.Text = dataGridView1.CurrentRow.Cells["Tendongco"].Value.ToString();
            btnxoa.Enabled = true;
        }

        private void frmdongco_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            Load_DataGridView();
            txtmadongco.Enabled = false;
            btnluu.Enabled = false;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Madongco, Tendongco FROM tbldongco";
            dt = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = dt;

            //do dl tu bang vao datagridview

            dataGridView1.Columns[0].HeaderText = "Mã động cơ";
            dataGridView1.Columns[1].HeaderText = "Tên động cơ";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dataGridView1.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmadongco.Enabled = true;
            txttendongco.Focus();

        }
        private void ResetValues()
        {
            txtmadongco.Text = "";
          txttendongco.Text = "";


        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmadongco.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã động cơ", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
             txtmadongco.Focus();
                return;
            }
            if (txttendongco.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên động cơ", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
              txttendongco.Focus();
                return;
            }
            sql = "SELECT Madongco FROM tbldongco WHERE Madongco=N'" + txtmadongco.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã động cơ này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              txtmadongco.Focus();
                txttendongco.Text = "";
                return;
            }
            sql = "INSERT INTO tbldongco(Madongco,Tendongco) VALUES(N'" + txtmadongco.Text + "',N'" + txttendongco.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;

            btnluu.Enabled = false;
            txtmadongco.Enabled = false;
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
            if (txtmadongco.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttendongco.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên động cơ", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttendongco.Focus();
                return;
            }
            sql = "UPDATE tbldongco SET Tendongco=N'" + txttendongco.Text.ToString() + "' WHERE Madongco=N'" + txtmadongco.Text + "'";
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
            if (txtmadongco.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tbldongco WHERE Madongco=N'" + txtmadongco.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();

            }
        }
    }
}

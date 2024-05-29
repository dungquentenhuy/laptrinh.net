using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmtheloai f = new Forms.frmtheloai();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }

        private void độngCơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmdongco g = new Forms.frmdongco();
            g.StartPosition = FormStartPosition.CenterScreen;
            g.Show();

        }

        private void màuSắcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmmausac h = new Forms.frmmausac();
            h.StartPosition = FormStartPosition.CenterScreen;
            h.Show();

        }

        private void tìnhTrạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmtinhtrang j = new Forms.frmtinhtrang();
            j.StartPosition = FormStartPosition.CenterScreen;
            j.Show();
        }

        private void nướcSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmnuocsanxuat k = new Forms.frmnuocsanxuat();
            k.StartPosition = FormStartPosition.CenterScreen;
            k.Show();
        }

        private void tìmKiếmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Frmtimkiemsp l = new Forms.Frmtimkiemsp();
            l.StartPosition = FormStartPosition.CenterScreen;
            l.Show();
        }

        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmcongviec z = new Forms.frmcongviec();
            z.StartPosition = FormStartPosition.CenterScreen;
            z.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmkhachhang x = new Forms.frmkhachhang();
            x.StartPosition = FormStartPosition.CenterScreen;
            x.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmnhanvien c = new Forms.frmnhanvien();
            c.StartPosition = FormStartPosition.CenterScreen;
            c.Show();
        }
    }
  }


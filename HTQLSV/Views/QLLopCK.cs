using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQLSV
{
    public partial class QLLopCK : Form
    {
        HTQLSVEntities db = new HTQLSVEntities();
        public QLLopCK()
        {
            InitializeComponent();
        }
        private bool CheckValidate()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (string.IsNullOrEmpty(((TextBox)item).Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void DataBinding()
        {
            txbMaLopCK.DataBindings.Clear();
            txbMaLopCK.DataBindings.Add("Text", dgvLopHocCK.DataSource, "MaLopCK");
            txbTenLop.DataBindings.Clear();
            txbTenLop.DataBindings.Add("Text", dgvLopHocCK.DataSource, "TenLopHoc");
            txbNienKhoa.DataBindings.Clear();
            txbNienKhoa.DataBindings.Add("Text", dgvLopHocCK.DataSource, "NienKhoa");
            cbbKhoa.DataBindings.Clear();
            cbbKhoa.DataBindings.Add("Text", dgvLopHocCK.DataSource, "Khoa");

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {
                var maLopCk = db.LopChinhKhoas.Select(s => s.MaLopCK).ToList().LastOrDefault() + 1;
                int maKhoa = db.Khoas.Where(k => k.TenKhoa == cbbKhoa.Text).Select(k => k.MaKhoa).FirstOrDefault();
                var lopCK = new LopChinhKhoa();
                lopCK.MaLopCK = maLopCk;
                lopCK.TenLopHoc = txbTenLop.Text;
                lopCK.NienKhoa = txbNienKhoa.Text;
                lopCK.MaKhoa = maKhoa;
                db.LopChinhKhoas.Add(lopCK);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                QLLopCK_Load(sender, e);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(CheckValidate())
            {
                var maLopCK = int.Parse(txbMaLopCK.Text);
                var lopCK = db.LopChinhKhoas.Where(c => c.MaLopCK == maLopCK).FirstOrDefault();
                lopCK.TenLopHoc = txbTenLop.Text;
                lopCK.NienKhoa = txbNienKhoa.Text;
                lopCK.MaKhoa = db.Khoas.Where(k => k.TenKhoa == cbbKhoa.Text).Select(k => k.MaKhoa).FirstOrDefault();
                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                QLLopCK_Load(sender, e);
            }
          

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var maLopCK = int.Parse(txbMaLopCK.Text);
            var lopCK = db.LopChinhKhoas.Where(c => c.MaLopCK == maLopCK).FirstOrDefault();
            db.LopChinhKhoas.Remove(lopCK);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công");
            QLLopCK_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();
            this.Hide();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            QLLopCK_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txbMaLopCK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã lớp cần tìm");
                return;
            }
            int maLopCK = int.Parse(txbMaLopCK.Text);
            dgvLopHocCK.DataSource = db.LopChinhKhoas.Where(c => c.MaLopCK == maLopCK).Select(c => new
            {
                MaLopCK = c.MaLopCK,
                TenLopHoc = c.TenLopHoc,
                NienKhoa = c.NienKhoa,
                Khoa = c.Khoa.TenKhoa
            }).ToList();

        }

        private void QLLopCK_Load(object sender, EventArgs e)
        {
            dgvLopHocCK.DataSource = db.LopChinhKhoas.Select(c => new
            {
                MaLopCK = c.MaLopCK,
                TenLopHoc = c.TenLopHoc,
                NienKhoa = c.NienKhoa,
                Khoa = c.Khoa.TenKhoa
            }).ToList();

            cbbKhoa.DataSource = db.Khoas.Select(c => c.TenKhoa).ToList();
        }

        private void dgvLopHocCK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataBinding();
        }
    }
}

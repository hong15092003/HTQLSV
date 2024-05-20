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
    public partial class QLPhongBan : Form
    {
        HTQLSVEntities db = new HTQLSVEntities();
        public QLPhongBan()
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
            txbMaPB.DataBindings.Clear();
            txbMaPB.DataBindings.Add("Text", dgvPhongBan.DataSource, "MaPhongBan");
            txbTenPhongBan.DataBindings.Clear();
            txbTenPhongBan.DataBindings.Add("Text", dgvPhongBan.DataSource, "TenPhongBan");
            txbTruongPhong.DataBindings.Clear();
            txbTruongPhong.DataBindings.Add("Text", dgvPhongBan.DataSource, "TruongPhong");
            txbNhiemVu.DataBindings.Clear();
            txbNhiemVu.DataBindings.Add("Text", dgvPhongBan.DataSource, "NhiemVu");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {
                var maPB = db.PhongBans.Select(s => s.MaPhongBan).ToList().LastOrDefault() + 1;
                var phongBan = new PhongBan();
                phongBan.MaPhongBan = maPB;
                phongBan.TenPhongBan = txbTenPhongBan.Text;
                phongBan.TruongPhong = txbTruongPhong.Text;
                phongBan.NhiemVu = txbNhiemVu.Text;
                db.PhongBans.Add(phongBan);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QLPhongBan_Load(sender, e);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {
                var mapb = Int32.Parse(txbMaPB.Text);
                var phongBan = db.PhongBans.Where(s => s.MaPhongBan == mapb).FirstOrDefault();
                phongBan.TenPhongBan = txbTenPhongBan.Text;
                phongBan.TruongPhong = txbTruongPhong.Text;
                phongBan.NhiemVu = txbNhiemVu.Text;
                db.SaveChanges();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QLPhongBan_Load(sender, e);
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var mapb = Int32.Parse(txbMaPB.Text);
            var phongBan = db.PhongBans.Where(s => s.MaPhongBan == mapb).FirstOrDefault();
            db.PhongBans.Remove(phongBan);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            QLPhongBan_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();
            this.Hide();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            QLPhongBan_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txbMaPB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã phòng ban cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var mapb = Int32.Parse(txbMaPB.Text);
            var phongBan = db.PhongBans.Where(s => s.MaPhongBan == mapb).FirstOrDefault();
            if (phongBan != null)
            {
                dgvPhongBan.DataSource = db.PhongBans.Where(s => s.MaPhongBan == mapb).Select(s => new
                {
                    s.MaPhongBan,
                    s.TenPhongBan,
                    s.TruongPhong,
                    s.NhiemVu
                }).ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhongBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataBinding();
        }

        private void QLPhongBan_Load(object sender, EventArgs e)
        {
            dgvPhongBan.DataSource = db.PhongBans.Select(s => new
            {
                s.MaPhongBan,
                s.TenPhongBan,
                s.TruongPhong,
                s.NhiemVu
            }).ToList();
        }
    }
}

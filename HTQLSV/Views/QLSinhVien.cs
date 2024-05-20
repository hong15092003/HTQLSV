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
    public partial class QLSinhVien : Form

    {
        HTQLSVEntities db = new HTQLSVEntities();
        public QLSinhVien()
        {
            InitializeComponent();
        }
        private void AddBinding()
        {
            txbMSSV.DataBindings.Clear();
            txbMSSV.DataBindings.Add(new Binding("Text", dgvSinhVien.DataSource, "MaSV"));
            txbHoTen.DataBindings.Clear();
            txbHoTen.DataBindings.Add(new Binding("Text", dgvSinhVien.DataSource, "HoTen"));
            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add(new Binding("Text", dgvSinhVien.DataSource, "NgaySinh"));
            cbbGioiTinh.DataBindings.Clear();
            cbbGioiTinh.DataBindings.Add(new Binding("Text", dgvSinhVien.DataSource, "GioiTinh"));
            txbSDT.DataBindings.Clear();
            txbSDT.DataBindings.Add(new Binding("Text", dgvSinhVien.DataSource, "SDT"));
            txbEmail.DataBindings.Clear();
            txbEmail.DataBindings.Add(new Binding("Text", dgvSinhVien.DataSource, "Email"));
            txbQueQuan.DataBindings.Clear();
            txbQueQuan.DataBindings.Add(new Binding("Text", dgvSinhVien.DataSource, "QueQuan"));
            cbbLop.DataBindings.Clear();
            cbbLop.DataBindings.Add(new Binding("Text", dgvSinhVien.DataSource, "LopChinhKhoa"));   
            
        }
        private void Loaddgv()
        {
            var data = db.SinhViens.Select(c => new
            {
                MaSV = c.MaSV,
                HoTen = c.HoTen,
                NgaySinh = c.NgaySinh,
                GioiTinh = c.GioiTinh,
                SDT = c.SDT,
                Email = c.Email,
                QueQuan = c.QueQuan,
                LopChinhKhoa = c.LopChinhKhoa.TenLopHoc,
            });
            dgvSinhVien.DataSource = data.ToList();
        }

        private void QLSinhVien_Load(object sender, EventArgs e)
        {
            
            var gioitinh = new List<string> { "Nam", "Nu", "Khac" };
            var lop = db.LopChinhKhoas.Select(c => c.TenLopHoc).ToList();
            cbbGioiTinh.DataSource = gioitinh;
            cbbLop.DataSource = lop;
            Loaddgv();

        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if(txbHoTen.Text == "" || dtpNgaySinh.Text == "" || cbbGioiTinh.Text == "" || txbSDT.Text == "" || txbEmail.Text == "" || txbQueQuan.Text == "" || cbbLop.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            int MaSV =  db.SinhViens.Select(c => c.MaSV).ToList().LastOrDefault() + 1 ;
            DateTime NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
            int MaLopCK = db.LopChinhKhoas.Where(c => c.TenLopHoc == cbbLop.Text).Select(c => c.MaLopCK).FirstOrDefault();

            var newSV = db.SinhViens.Add(new SinhVien()
            {
                MaSV = MaSV,
                HoTen = txbHoTen.Text,
                NgaySinh = NgaySinh,
                GioiTinh = cbbGioiTinh.Text,
                QueQuan = txbQueQuan.Text,
                SDT = txbSDT.Text,
                Email = txbEmail.Text,
                MaLopCK = MaLopCK,

            });

            db.SaveChanges();

            MessageBox.Show("Them thanh cong");
            Loaddgv();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", buttons);
            if (result == DialogResult.No)
            {
                return;
            }
            int mssv = Int32.Parse(txbMSSV.Text);
            db.SinhViens.Remove(db.SinhViens.Where(s => s.MaSV == mssv).FirstOrDefault());
            db.SaveChanges();
            MessageBox.Show("Xóa thành công");
            Loaddgv();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();
            this.Hide();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Loaddgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
            MessageBoxButtons btn = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show("Tim kiem theo MSSV (Yes), Ten(No). Huy thao tac (Cancel) ?","Thong bao",btn);

            if(result == DialogResult.Yes)
            {
                var mssv = Int32.Parse(txbMSSV.Text);
                var timkiem = db.SinhViens.Where(s => s.MaSV == mssv).Select(c => new
                {
                    MaSV = c.MaSV,
                    HoTen = c.HoTen,
                    NgaySinh = c.NgaySinh,
                    GioiTinh = c.GioiTinh,
                    SDT = c.SDT,
                    Email = c.Email,
                    QueQuan = c.QueQuan,
                    LopChinhKhoa = c.LopChinhKhoa.TenLopHoc,
                });
                dgvSinhVien.DataSource = timkiem.ToList();
                return;
            }
            if(result == DialogResult.No)
            {
                 var timkiem = db.SinhViens.Where(s => s.HoTen.Contains(txbHoTen.Text)).Select(c => new
                {
                    MaSV = c.MaSV,
                    HoTen = c.HoTen,
                    NgaySinh = c.NgaySinh,
                    GioiTinh = c.GioiTinh,
                    SDT = c.SDT,
                    Email = c.Email,
                    QueQuan = c.QueQuan,
                    LopChinhKhoa = c.LopChinhKhoa.TenLopHoc,
                });
                    dgvSinhVien.DataSource = timkiem.ToList();
                return;
            }
            if (result == DialogResult.Cancel) return;
            
            

        }

        private void btnSua_Click(object sender, EventArgs e)
        {   var mssv = Int32.Parse(txbMSSV.Text);
            DateTime NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
            int MaLopCK = db.LopChinhKhoas.Where(c => c.TenLopHoc == cbbLop.Text).Select(c => c.MaLopCK).FirstOrDefault();
            var svUpdate = db.SinhViens.Where(s => s.MaSV == mssv).ToList().LastOrDefault();
            if(svUpdate == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên");
                return;
            }
            {
                svUpdate.HoTen = txbHoTen.Text;
                svUpdate.NgaySinh = NgaySinh;
                svUpdate.GioiTinh = cbbGioiTinh.Text;
                svUpdate.QueQuan = txbQueQuan.Text;
                svUpdate.SDT = txbSDT.Text;
                svUpdate.Email = txbEmail.Text;
                svUpdate.MaLopCK = MaLopCK;
            }
            db.SaveChanges();
            MessageBox.Show("Sửa thành công");
            Loaddgv();
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddBinding();
        }
    }
}

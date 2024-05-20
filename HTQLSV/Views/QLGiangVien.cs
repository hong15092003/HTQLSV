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
    public partial class QLGiangVien : Form

    {
        HTQLSVEntities db = new HTQLSVEntities();
        public QLGiangVien()
        {
            InitializeComponent();
    
        }
        private void AddBinding()
        {
            txbMaGV.DataBindings.Clear();
            txbMaGV.DataBindings.Add(new Binding("Text", dgvGiangVien.DataSource, "MaGV"));
            txbHoTen.DataBindings.Clear();
            txbHoTen.DataBindings.Add(new Binding("Text", dgvGiangVien.DataSource, "HoTen"));
            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add(new Binding("Text", dgvGiangVien.DataSource, "NgaySinh"));
            cbbGioiTinh.DataBindings.Clear();
            cbbGioiTinh.DataBindings.Add(new Binding("Text", dgvGiangVien.DataSource, "GioiTinh"));
            txbSDT.DataBindings.Clear();
            txbSDT.DataBindings.Add(new Binding("Text", dgvGiangVien.DataSource, "SDT"));
            txbEmail.DataBindings.Clear();
            txbEmail.DataBindings.Add(new Binding("Text", dgvGiangVien.DataSource, "Email"));
            txbQueQuan.DataBindings.Clear();
            txbQueQuan.DataBindings.Add(new Binding("Text", dgvGiangVien.DataSource, "QueQuan"));
         
       

        }
        private void Loaddgv()
        {
            var data = db.GiangViens.Select(c => new
            {
                MaGV = c.MaGV,
                HoTen = c.HoTen,
                NgaySinh = c.NgaySinh,
                GioiTinh = c.GioiTinh,
                SDT = c.SDT,
                Email = c.Email,
                QueQuan = c.QueQuan,
          
            });
            dgvGiangVien.DataSource = data.ToList();
        }

        private void QLGiangVien_Load(object sender, EventArgs e)
        {

            var gioitinh = new List<string> { "Nam", "Nu", "Khac" };
            var lop = db.LopChinhKhoas.Select(c => c.TenLopHoc).ToList();
            cbbGioiTinh.DataSource = gioitinh;
            Loaddgv();

        }


        private void btnThem_Click(object sender, EventArgs e)
        {

            if (txbHoTen.Text == "" || dtpNgaySinh.Text == "" || cbbGioiTinh.Text == "" || txbSDT.Text == "" || txbEmail.Text == "" || txbQueQuan.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            int MaGV = db.GiangViens.Select(c => c.MaGV).ToList().LastOrDefault() + 1;
            DateTime NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
          

            var newSV = db.GiangViens.Add(new GiangVien()
            {
                MaGV = MaGV,
                HoTen = txbHoTen.Text,
                NgaySinh = NgaySinh,
                GioiTinh = cbbGioiTinh.Text,
                QueQuan = txbQueQuan.Text,
                SDT = txbSDT.Text,
                Email = txbEmail.Text,
       

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
            int mssv = Int32.Parse(txbMaGV.Text);
            db.GiangViens.Remove(db.GiangViens.Where(s => s.MaGV == mssv).FirstOrDefault());
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
            DialogResult result = MessageBox.Show("Tim kiem theo MSSV (Yes), Ten(No). Huy thao tac (Cancel) ?", "Thong bao", btn);

            if (result == DialogResult.Yes)
            {
                var MaGV = Int32.Parse(txbMaGV.Text);
                var timkiem = db.GiangViens.Where(s => s.MaGV == MaGV).Select(c => new
                {
                    MaGV = c.MaGV,
                    HoTen = c.HoTen,
                    NgaySinh = c.NgaySinh,
                    GioiTinh = c.GioiTinh,
                    SDT = c.SDT,
                    Email = c.Email,
                    QueQuan = c.QueQuan,
                });
                dgvGiangVien.DataSource = timkiem.ToList();
                return;
            }
          
            if (result == DialogResult.No)
            {
                var timkiem = db.GiangViens.Where(s => s.HoTen.Contains(txbHoTen.Text)).Select(c => new
                {
                    MaGV = c.MaGV,
                    HoTen = c.HoTen,
                    NgaySinh = c.NgaySinh,
                    GioiTinh = c.GioiTinh,
                    SDT = c.SDT,
                    Email = c.Email,
                    QueQuan = c.QueQuan,
                });
                dgvGiangVien.DataSource = timkiem.ToList();
                return;
            }
            if (result == DialogResult.Cancel) return;



        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var mssv = Int32.Parse(txbMaGV.Text);
            DateTime NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
            var svUpdate = db.GiangViens.Where(s => s.MaGV == mssv).ToList().LastOrDefault();
            if (svUpdate == null)
            {
                MessageBox.Show("Khong tim thay giang vien");
                return;
            }
            {
                svUpdate.HoTen = txbHoTen.Text;
                svUpdate.NgaySinh = NgaySinh;
                svUpdate.GioiTinh = cbbGioiTinh.Text;
                svUpdate.QueQuan = txbQueQuan.Text;
                svUpdate.SDT = txbSDT.Text;
                svUpdate.Email = txbEmail.Text;
         
            }
            db.SaveChanges();
            MessageBox.Show("Sửa thành công");
            Loaddgv();
        }

        private void dgvGiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddBinding();
        }

     
    }
}

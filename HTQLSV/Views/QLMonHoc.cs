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
    public partial class QLMonHoc : Form
    {
        HTQLSVEntities db = new HTQLSVEntities();
        public QLMonHoc()
        {
            InitializeComponent();
        }

        private bool CheckValidate()
        {
            if ( txbTenMonHoc.Text == "" || txbSoTC.Text == "" || textSoTietTH.Text == "" || txbSoTietLT.Text == "" || cbbKhoa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return false;
            }
            return true;
        }

       private void DataBinding()
        {
            txbMaMH.DataBindings.Clear();
            txbMaMH.DataBindings.Add("Text", dgvMonHoc.DataSource, "MaMonHoc");
            txbTenMonHoc.DataBindings.Clear();
            txbTenMonHoc.DataBindings.Add("Text", dgvMonHoc.DataSource, "TenMonHoc");
            txbSoTC.DataBindings.Clear();
            txbSoTC.DataBindings.Add("Text", dgvMonHoc.DataSource, "SoTC");
            textSoTietTH.DataBindings.Clear();
            textSoTietTH.DataBindings.Add("Text", dgvMonHoc.DataSource, "SoTietTH");
            txbSoTietLT.DataBindings.Clear();
            txbSoTietLT.DataBindings.Add("Text", dgvMonHoc.DataSource, "SoTietLT");
            cbbKhoa.DataBindings.Clear();
            cbbKhoa.DataBindings.Add("Text", dgvMonHoc.DataSource, "Khoa");

        }

      

        private void QLMonHoc_Load(object sender, EventArgs e)
        {
            var data = db.MonHocs.Select(c => new
            {
                MaMonHoc = c.MaMonHoc,
                TenMonHoc = c.TenMonHoc,
                SoTC = c.SoTC,
                SoTietTH = c.SoTietTH,
                SoTietLT = c.SoTietLT,
                Khoa = c.Khoa.TenKhoa
            });

            dgvMonHoc.DataSource = data.ToList();

            cbbKhoa.DataSource = db.Khoas.Select(k => k.TenKhoa).ToList();
        

        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();
            this.Hide();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            MessageBoxButtons btn = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show("Tim kiem theo MaMH (Yes), Ten(No). Huy thao tac (Cancel) ?", "Thong bao", btn);

            if (result == DialogResult.Yes)
            {
                var maMH = Int32.Parse(txbMaMH.Text);
                var timkiem = db.MonHocs.Where(s => s.MaMonHoc == maMH).Select(c => new
                {
                    MaMonHoc = c.MaMonHoc,
                    TenMonHoc = c.TenMonHoc,
                    SoTC = c.SoTC,
                    SoTietTH = c.SoTietTH,
                    SoTietLT = c.SoTietLT,
                    Khoa = c.Khoa.TenKhoa
                   
                });
                dgvMonHoc.DataSource = timkiem.ToList();
                return;
            }
            if (result == DialogResult.No)
            {
                var timkiem = db.MonHocs.Where(s => s.TenMonHoc.Contains(txbTenMonHoc.Text)).Select(c => new
                {
                    MaMonHoc = c.MaMonHoc,
                    TenMonHoc = c.TenMonHoc,
                    SoTC = c.SoTC,
                    SoTietTH = c.SoTietTH,
                    SoTietLT = c.SoTietLT,
                    Khoa = c.Khoa.TenKhoa
                });
                dgvMonHoc.DataSource = timkiem.ToList();
                return;
            }
            if (result == DialogResult.Cancel) return;

           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
         
            if (CheckValidate())
            {
                var mamh = Int32.Parse(txbMaMH.Text);
                var monhoc = db.MonHocs.Where(s => s.MaMonHoc == mamh).FirstOrDefault();
                monhoc.TenMonHoc = txbTenMonHoc.Text;
                monhoc.SoTC = Int32.Parse(txbSoTC.Text);
                monhoc.SoTietTH = Int32.Parse(textSoTietTH.Text);
                monhoc.SoTietLT = Int32.Parse(txbSoTietLT.Text);
                monhoc.Khoa = db.Khoas.Where(k => k.TenKhoa == cbbKhoa.Text).FirstOrDefault();
                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                QLMonHoc_Load(sender, e);
            }   

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            QLMonHoc_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var mamh = Int32.Parse(txbMaMH.Text);
            var monhoc = db.MonHocs.Where(s => s.MaMonHoc == mamh).FirstOrDefault();
            db.MonHocs.Remove(monhoc);
            db.SaveChanges();
            MessageBox.Show("Xóa thành công");
            QLMonHoc_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var mamh = db.MonHocs.Select(s => s.MaMonHoc).ToList().LastOrDefault() + 1;
            if (CheckValidate())
            {
                MonHoc monhoc = new MonHoc();
                monhoc.MaMonHoc = mamh;
                monhoc.TenMonHoc = txbTenMonHoc.Text;
                monhoc.SoTC = Int32.Parse(txbSoTC.Text);
                monhoc.SoTietTH = Int32.Parse(textSoTietTH.Text);
                monhoc.SoTietLT = Int32.Parse(txbSoTietLT.Text);
                monhoc.Khoa = db.Khoas.Where(k => k.TenKhoa == cbbKhoa.Text).FirstOrDefault();
                db.MonHocs.Add(monhoc);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                QLMonHoc_Load(sender, e);
            }
        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataBinding();
        }

    }
}

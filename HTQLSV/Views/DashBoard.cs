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
    public partial class DashBoard : Form
    {
        HTQLSVEntities db = new HTQLSVEntities();
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            // Load data to DataGridView
            var data = db.SinhViens.Select(c => new
            {
                MaSV = c.MaSV,
                HoTen = c.HoTen,
                NgaySinh = c.NgaySinh,
                GioiTinh = c.GioiTinh,
                LopChinhKhoa = c.LopChinhKhoa.TenLopHoc,
                Khoa = c.LopChinhKhoa.Khoa.TenKhoa,

               
            });
            dgvDashBoard.DataSource = data.ToList();
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            QLKhoa qlkhoa = new QLKhoa();
            qlkhoa.Show();
            this.Hide();
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            QLPhongBan qLPhongBan = new QLPhongBan();
            qLPhongBan.Show();
            this.Hide();
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            QLMonHoc qlmh = new QLMonHoc();
            qlmh.Show();
            this.Hide();

        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            QLGiangVien qlgv = new QLGiangVien();
            qlgv.Show();
            this.Hide();
        }

        private void btnLopCK_Click(object sender, EventArgs e)
        {
            QLLopCK qllopck = new QLLopCK();
            qllopck.Show();
            this.Hide();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            QLSinhVien qlsv = new QLSinhVien();
            qlsv.Show();
           this.Hide();
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {

        }

        private void btnDayHoc_Click(object sender, EventArgs e)
        {
            QLDayHoc qldh = new QLDayHoc();
            qldh.Show();
            this.Hide();
        }

        private void btnHocPhi_Click(object sender, EventArgs e)
        {

        }

        private void btnHocPhan_Click(object sender, EventArgs e)
        {
            QLHocPhan qlhp = new QLHocPhan();
            qlhp.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        { 
            this.Hide();
        }
    }
}

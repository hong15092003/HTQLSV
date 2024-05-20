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
    public partial class QLHocPhan : Form
    {
        HTQLSVEntities db = new HTQLSVEntities();
        public QLHocPhan()
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

        private void QLHocPhan_Load(object sender, EventArgs e)
        {
            var groupedData = db.HocPhans
            .GroupBy(hp => hp.SinhVien.LopChinhKhoa.MaLopCK)
        .Select(g => new
        {
            MaLopCK = g.Key,
            HocPhans = g.Select(hp => new
            {
                hp.MaHocPhan,
                hp.MonHoc.TenMonHoc,
                hp.SoTiet,
                hp.ThoiGian
            }).ToList()
        }).ToList();

            dgvHocPhan.DataSource = groupedData;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void dgvHocPhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

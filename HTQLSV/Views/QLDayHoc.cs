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
    public partial class QLDayHoc : Form
    {
        HTQLSVEntities db = new HTQLSVEntities();
        public QLDayHoc()
        {
            InitializeComponent();
        }

     

        private void QLDayHoc_Load(object sender, EventArgs e)
        {
            dgvDayHoc.DataSource = db.DayHocs.Select(c => new
            {
             
            }).ToList();   
        }

        private void dgvHocPhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301EfProject
{
    public partial class FrmGuide : Form
    {
        public FrmGuide()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TblGuide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblGuide guide = new TblGuide();
            guide.GuideName = txtName.Text;
            guide.GuideSurName = txtSurName.Text;
            db.TblGuide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber eklendi");
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removedValue = db.TblGuide.Find(id);
            db.TblGuide.Remove(removedValue);
            db.SaveChanges();
            MessageBox.Show("Rehber kaydı silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = db.TblGuide.Find(id);
            updatedValue.GuideName = txtName.Text;
            updatedValue.GuideSurName= txtSurName.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber kaydı güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.TblGuide.Where(x=>x.GuideId == id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}

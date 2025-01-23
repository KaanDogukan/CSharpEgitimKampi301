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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TblLocation.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.TblGuide.Select(x => new
            {
                FullName = x.GuideName+" "+x.GuideSurName, x.GuideId
            }).ToList();

            comGuide.DisplayMember = "FullName";
            comGuide.ValueMember = "GuideId";
            comGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblLocation location = new TblLocation();
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Capasity = byte.Parse(nudCapasity.Value.ToString());
            location.Price = decimal.Parse(textPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(comGuide.SelectedValue.ToString());
            db.TblLocation.Add(location);
            db.SaveChanges();
            MessageBox.Show("Lokasyon verisi ekleme başaralı");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtLocationId.Text);
            var deletedValue = db.TblLocation.Find(id);
            db.TblLocation.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("seyahat rotasi silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtLocationId.Text);
            var updatedValue = db.TblLocation.Find(id);
            updatedValue.City = txtCity.Text;
            updatedValue.Country = txtCountry.Text;
            updatedValue.Price = decimal.Parse(textPrice.Text);
            updatedValue.DayNight = txtDayNight.Text;
            updatedValue.GuideId = int.Parse(comGuide.SelectedValue.ToString());
            updatedValue.Capasity = byte.Parse(nudCapasity.Value.ToString());
            db.SaveChanges();
            MessageBox.Show("Lokasyon Güncellendi");

        }
    }
}

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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            var localCount = db.TblLocation.Count().ToString();

            lblCount.Text = localCount;

            lblCpacity.Text = db.TblLocation.Sum(x=>x.Capasity).ToString();

            lblGuideCount.Text = db.TblLocation.Count().ToString();

            lblAvrCapacity.Text = db.TblLocation.Average(x => x.Capasity)?.ToString("F2") ?? "0.00";

            lblSumPrice.Text = (db.TblLocation.Sum(x => x.Price) ?? 0).ToString("F2") + " ₺";

            var lastCountryId = db.TblLocation.Max(x => x.LocationId);

            lblLastCountry.Text = db.TblLocation.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCapadociaTourCapacity.Text = db.TblLocation.Where(x => x.City == "Kapadokya").Select(y => y.Capasity).FirstOrDefault().ToString();

            lblItalyTourAverage.Text = db.TblLocation.Where(x => x.Country == "Italya").Average(y => y.Capasity).ToString();

            lblRomaRehber.Text = db.TblLocation.Where(x => x.City == "Roma").Select(y=>y.TblGuide.GuideName+" "+y.TblGuide.GuideSurName).FirstOrDefault().ToString();

            var maxCapasity = db.TblLocation.Max(x => x.Capasity);
            lblMaxCapcity.Text = db.TblLocation.Where(x => x.Capasity==maxCapasity).Select(y=>y.City).FirstOrDefault().ToString();

            var maxPrice = db.TblLocation.Max(x => x.Price);
            lblMaxPrice.Text = db.TblLocation.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var guideIdAyse = db.TblGuide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurName== "Çınar").Select(y=>y.GuideId).FirstOrDefault();
            lblAyseLocCount.Text = db.TblLocation.Where(x=>x.GuideId==guideIdAyse).Count().ToString();


        } 
    }
}

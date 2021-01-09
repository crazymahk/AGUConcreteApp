using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capstoneProject
{
    public partial class Cost : Form
    {
        public Cost()
        {

            InitializeComponent();

            //Cement water ve diğer değişkenleri result kısmından çağırmak
            // çağırdıklarım çarpılacak giivi

        }

        private void DrawPieChart(double cementP, double caP, double faP, double waterP)
        {

            priceChart.Series.Clear();
            priceChart.Legends.Clear();
            priceChart.Legends.Add("Cost of Concrete");
            priceChart.Legends[0].Alignment = StringAlignment.Center;
            priceChart.Legends[0].BorderColor = Color.Black;
            string seriesname = "Cost of Concrete ";
            priceChart.Series.Add(seriesname);
            //set the chart-type to "Pie"
            priceChart.Series[seriesname].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;


            double tempTotal = cementP + faP + caP + waterP;
            //Add some datapoint waterPs so the series. in this case you can pass the values to this method
            priceChart.Series[seriesname].Points.AddXY("Cement" + " " + (cementP * Session.cement / 1000).ToString("0.00") + " ₺", (cementP * Session.cement / 1000));
            priceChart.Series[seriesname].Points.AddXY("Fine Agg." + " " + (faP * Session.ssdWeightFA / 1000).ToString("0.00") + " ₺", (faP * Session.ssdWeightFA / 1000));
            priceChart.Series[seriesname].Points.AddXY("Coarse Agg." + " " + (caP * Session.ssdWeightCA / 1000).ToString("0.00") + " ₺", (caP * Session.ssdWeightCA / 1000));
            priceChart.Series[seriesname].Points.AddXY("Water" + " " + (waterP * Session.ssdWeightOfWater / 1000).ToString("0.00") + " ₺", (waterP * Session.ssdWeightOfWater / 1000));
        }



        private void btnCostCalculate_Click(object sender, EventArgs e)
        {

            if (!(String.IsNullOrEmpty(txtCementPrice.Text) || String.IsNullOrEmpty(txtFAPrice.Text) || String.IsNullOrEmpty(txtCAPrice.Text) || String.IsNullOrEmpty(txtWaterPrice.Text) ))
            {

                Session.CementPrice = Convert.ToDouble(txtCementPrice.Text);
                Session.FAPrice = Convert.ToDouble(txtFAPrice.Text);
                Session.CAPrice = Convert.ToDouble(txtCAPrice.Text);
                Session.WaterPrice = Convert.ToDouble(txtWaterPrice.Text);
                Double cost = (Session.CementPrice * Session.cement / 1000) + (Session.FAPrice * Session.ssdWeightFA / 1000) + (Session.CAPrice * Session.ssdWeightCA / 1000) + (Session.WaterPrice * Session.ssdWeightOfWater / 1000);



                if (cost == 0)
                {
                    MessageBox.Show("Please firstly complete design part :)", "Cost Estimation");
                }

                else
                {
                    DrawPieChart(Convert.ToDouble(txtCementPrice.Text), Convert.ToDouble(txtCAPrice.Text),
                 Convert.ToDouble(txtFAPrice.Text), Convert.ToDouble(txtWaterPrice.Text));

                    costLabel.Text = "The total cost is  " + cost.ToString("0.00") + " ₺";
                    MessageBox.Show("The total cost is  " + cost.ToString("0.00") + " ₺", "Cost Estimation");
                    capstoneProject.User.Default.isCostCalculated = true;
                }

            }

            else
            {
                MessageBox.Show("Please write all ingredient price", "Cost Estimation");
            }







        }






    }
}

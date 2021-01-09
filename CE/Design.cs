using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

//screenshot requires
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;


namespace capstoneProject
{
    public partial class Design : Form
    {
        
        public Design()
        {
            InitializeComponent();
            Session.activePageName = "Design";
            Session.activeTabIndex = "0";
        }
        private void Design_Load(object sender, EventArgs e)
        {

            //// Devre
            User.Default.isCostCalculated = false;
            sens = capstoneProject.User.Default.sens;
            if (sens == 0)
                sens = 2;
            global::capstoneProject.User.Default.sens = sens;

            fillDataTable();
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            this.tabControl.SelectedIndex = 0;


            Cost cost = new Cost() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tabCost.Controls.Clear();
            tabCost.Controls.Add(cost);
            cost.Show();

        }
        private int sens;
        //checking options for bar value
        bool ctrlAirStatus = false, ctrlAirDetail = false, ctrlStrength = false, ctrlMaxAggSize = false, ctrlSlump = false;
        bool ctrlFM = false, ctrlBDCA = false, ctrlCCCalculate = false, ctrlCCCalculateF = false, ctrlResultTable = false;
        int maxAggSize = 0, slump = 0;
        //TABLO BURADAN OLUŞTURULDU
        private void fillDataTable()
        {
            data.Rows.Clear();
            #region data
            string[,] rows = {
                { "63", "100", "100", "100","100" },
                { "50", "100", "100", "100","100" },
                { "37.5", "100", "100", "100","100" },
                { "25", "100", "100", "100","100" },
                { "19", "100", "100", "100","100" },
                { "12.5", "64.9", "100", "100","100" },
                { "9.5", "10.6", "56.4", "99.9","100" },
                { "4.75", "3.6", "3.5", "93.2","99.1" },
                { "2.36", "2.5", "1.5", "66.1","97.9" },
                { "1.18", "1.9", "1.2", "45.3","94.9" },
                { "0.6", "1.6", "1", "32.8","79.3" },
                { "0.3", "1.3", "0.8", "22.2","17.9" },
                { "0.15", "1", "0.6", "14.3","1.7" },
                { "0.075", "0.4", "0.1", "5.3","0.5" },
            };
            #endregion
            maxAggSize = cbMaxAggregaSize.SelectedIndex;
            if (maxAggSize == -1)
                maxAggSize = 0;
            data.RowTemplate.Height = 330 / (14 - maxAggSize);
            float fontSize = 11.75F;
            fontSize += maxAggSize * 1.25F;
            data.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Palatino Linotype", fontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

            //creating data dable with default values
            for (int i = maxAggSize; i < 14; i++)
            {
                int index = 0;
                string[] temp = new string[7];
                for (int j = 0; j < 5; j++)
                {
                    temp[index] = rows[i, j];
                    index++;
                }
                temp[5] = "100";

                temp[6] = (Math.Sqrt(Convert.ToDouble(rows[i, 0]) / Convert.ToDouble(rows[maxAggSize, 0])) * 100).ToString(".00");
                data.Rows.Add(temp);
            }
            data.AllowUserToResizeRows = false;
            data.AllowUserToOrderColumns = false;
            data.AllowUserToDeleteRows = false;
        }

        //Fine burdan tutulacak
        double tutulacakDeger = 0.0;
        public void calculateCoarseFiness()
        {
            if (!(String.IsNullOrEmpty(txtFC1SSD.Text) && String.IsNullOrEmpty(txtFC1AC.Text) && String.IsNullOrEmpty(txtFC1CWC.Text)))
            {
                if (!(String.IsNullOrEmpty(txtFC2SSD.Text) && String.IsNullOrEmpty(txtFC2AC.Text) && String.IsNullOrEmpty(txtFC2CWC.Text)))
                {
                    if (!ctrlCCCalculateF)
                    {
                        txtFCCSSD.Text = ((a3i * Convert.ToDouble(txtFC1SSD.Text.Replace(',', '.')) + a4i * Convert.ToDouble(txtFC2SSD.Text.Replace(',', '.'))) / (a4i + a3i)).ToString();
                        txtFCCAC.Text = ((a3i * Convert.ToDouble(txtFC1AC.Text.Replace(',', '.')) + a4i * Convert.ToDouble(txtFC2AC.Text.Replace(',', '.'))) / (a4i + a3i)).ToString();
                        txtFCCCWC.Text = ((a3i * Convert.ToDouble(txtFC1CWC.Text.Replace(',', '.')) + a4i * Convert.ToDouble(txtFC2CWC.Text.Replace(',', '.'))) / (a4i + a3i)).ToString();
                        Session.finness = cbFiness.SelectedIndex;
                        ctrlCCCalculateF = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill all coarse values.");
            }
        }
        public void calculateCoarse()
        {
            //YAPILACAK iflerle boş string kontrolü
            if (!(String.IsNullOrEmpty(txtC1BSG.Text) && String.IsNullOrEmpty(txtC1AC.Text) && String.IsNullOrEmpty(txtC1TMC.Text) && String.IsNullOrEmpty(txtC1UWDR.Text)))
            {
                if (!(String.IsNullOrEmpty(txtC2BSG.Text) && String.IsNullOrEmpty(txtC2AC.Text) && String.IsNullOrEmpty(txtC2TMC.Text) && String.IsNullOrEmpty(txtC2UWDR.Text)))
                {


                    if (!ctrlCCCalculate)
                    {
                        txtCCBSG.Text = ((a1i * Convert.ToDouble(txtC1BSG.Text.Replace(',', '.')) + a2i * Convert.ToDouble(txtC2BSG.Text.Replace(',', '.'))) / (a1i + a2i)).ToString();
                        txtCCUWDR.Text = ((a1i * Convert.ToDouble(txtC1UWDR.Text.Replace(',', '.')) + a2i * Convert.ToDouble(txtC2UWDR.Text.Replace(',', '.'))) / (a1i + a2i)).ToString();
                        txtCCAC.Text = ((a1i * Convert.ToDouble(txtC1AC.Text.Replace(',', '.')) + a2i * Convert.ToDouble(txtC2AC.Text.Replace(',', '.'))) / (a1i + a2i)).ToString();
                        txtCCTMC.Text = ((a1i * Convert.ToDouble(txtC1TMC.Text.Replace(',', '.')) + a2i * Convert.ToDouble(txtC2TMC.Text.Replace(',', '.'))) / (a1i + a2i)).ToString();
                        ctrlCCCalculate = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill all coarse values.");
            }


        }
        #region Calculations
        double max = 10000000;
        private bool compare(double current)
        {
            if (current < max)
            {
                max = current;
                return true;
            }
            else
            {
                return false;
            }
        }
        int a1i = 0, a2i = 0, a3i = 0, a4i = 0;
        double sum = 0.0, total = 0.0;
        double a1, a2, a3, a4, combined, ideal;
       
        private void calculate()
        {
            for (int i = 2; i <= 94; i += 2)
            {
                for (int j = 2; j <= 96 - i; j += 2)
                {
                    for (int k = 2; k <= 98 - i - j; k += 2)
                    {
                        int m = 100 - k - j - i;
                        sum = 0;
                        for (int row = 0; row < 13 - maxAggSize; row++)
                        {
                            string strA1 = data.Rows[row].Cells[1].Value.ToString().Replace(',', '.');
                            string strA2 = data.Rows[row].Cells[2].Value.ToString().Replace(',', '.');
                            string strA3 = data.Rows[row].Cells[3].Value.ToString().Replace(',', '.');
                            string strA4 = data.Rows[row].Cells[4].Value.ToString().Replace(',', '.');
                            a1 = Convert.ToDouble(strA1);
                            a2 = Convert.ToDouble(strA2);
                            a3 = Convert.ToDouble(strA3);
                            a4 = Convert.ToDouble(strA4);
                            ideal = Convert.ToDouble(data.Rows[row].Cells[6].Value.ToString().Replace(',', '.'));

                            combined = ((a1 * i / 100) + (a2 * j / 100) + (a3 * k / 100) + (a4 * m / 100));
                            data.Rows[row].Cells[5].Value = combined.ToString(".00");
                            sum += Math.Abs(ideal - combined);
                        }
                        if (compare(sum))
                        {
                            a1i = i;
                            a2i = j;
                            a3i = k;
                            a4i = m;
                            total = sum;
                        }
                    }
                }
            }
            Session.value1 = a1i;
            Session.value2 = a2i;
            Session.value3 = a3i;
            Session.value4 = a4i;

            Console.WriteLine("Done");

        } //fuller method 
        #endregion
        #region dataTableValidating

        private string pattern = @"^(0*100{1,1}\.?((?<=\.)0*)?%?$)|(^0*\d{0,2}\.?((?<=\.)\d*)?%?)$";

        private void data_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            data.EditingControl.KeyPress -= EditingControl_KeyPress;
            data.EditingControl.KeyPress += EditingControl_KeyPress;
        }

        private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                Control editingControl = (Control)sender;
                if (!Regex.IsMatch(editingControl.Text + e.KeyChar, pattern))
                    e.Handled = true;
            }
        }
        #endregion
        
        private void createResultChart()
        {
            double[] RCmaxAggArray = new double[14 - maxAggSize];
            double[] RCcoarse1 = new double[14 - maxAggSize];
            double[] RCcoarse2 = new double[14 - maxAggSize];
            double[] RCfine1 = new double[14 - maxAggSize];
            double[] RCfine2 = new double[14 - maxAggSize];
            double[] RCcombined = new double[14 - maxAggSize];
            double[] RCideal = new double[14 - maxAggSize];
            resultChart.Series.Clear();

            double combinedFinal = ((a1 * a1i / 100) + (a2 * a2i / 100) + (a3 * a3i / 100) + (a4 * a4i / 100));
            int count = 0;
            foreach (DataGridViewRow row in data.Rows)
            {
                string size = row.Cells[0].Value.ToString();
                string c1 = row.Cells[1].Value.ToString();
                string c2 = row.Cells[2].Value.ToString();
                string f1 = row.Cells[3].Value.ToString();
                string f2 = row.Cells[4].Value.ToString();
                string combi = row.Cells[5].Value.ToString();
                string ideal = row.Cells[6].Value.ToString();

                RCmaxAggArray[count] = Convert.ToDouble(size);
                RCcoarse1[count] = Convert.ToDouble(c1);
                RCcoarse2[count] = Convert.ToDouble(c2);
                RCfine1[count] = Convert.ToDouble(f1);
                RCfine2[count] = Convert.ToDouble(f2);
                RCcombined[count] = ((Convert.ToDouble(row.Cells[1].Value) * a1i / 100) + (Convert.ToDouble(row.Cells[2].Value) * a2i / 100) + (Convert.ToDouble(row.Cells[3].Value) * a3i / 100) + (Convert.ToDouble(row.Cells[4].Value) * a4i / 100));
                RCideal[count] = Convert.ToDouble(ideal);
                count++;
            }

            Series coarse1 = new Series() { Color = Color.Red, LegendText = "Coarse 1", ChartType = SeriesChartType.Line, BorderWidth = 1 };
            Series coarse2 = new Series() { Color = Color.Blue, LegendText = "Coarse 2", ChartType = SeriesChartType.Line, BorderWidth = 1 };
            Series fine1 = new Series() { Color = Color.Green, LegendText = "Fine 1", ChartType = SeriesChartType.Line, BorderWidth = 1 };
            Series fine2 = new Series() { Color = Color.Brown, LegendText = "Fine 2", ChartType = SeriesChartType.Line, BorderWidth = 1 };
            Series idealLine = new Series() { Color = Color.Teal, LegendText = "Ideal", ChartType = SeriesChartType.Line, BorderWidth = 4 };
            Series combinedLine = new Series() { Color = Color.DarkOrange, LegendText = "Combined", ChartType = SeriesChartType.Line, BorderWidth = 4 };

            coarse1.Points.Clear();
            foreach (double x in RCcoarse1)
            {
                coarse1.Points.Add(x);
            }
            foreach (double x in RCcoarse2)
            {
                coarse2.Points.Add(x);
            }
            foreach (double x in RCfine1)
            {
                fine1.Points.Add(x);
            }
            foreach (double x in RCfine2)
            {
                fine2.Points.Add(x);
            }
            foreach (double x in RCideal)
            {
                idealLine.Points.Add(x);
            }
            foreach (double x in RCcombined)
            {
                combinedLine.Points.Add(x);
                Console.WriteLine(x);
            }

            resultChart.ResetAutoValues();
            resultChart.Series.Add(coarse1);
            resultChart.Series.Add(coarse2);
            resultChart.Series.Add(fine1);
            resultChart.Series.Add(fine2);
            resultChart.Series.Add(combinedLine);
            resultChart.Series.Add(idealLine);




            //BURASI FINENESS DEĞERİ
            tutulacakDeger = RCcombined[RCcombined.Length - 7];


            resultChart.ChartAreas[0].Axes[0].IsStartedFromZero = true;

            double temppp2 = 0.5;
            int temppp = 0;
            foreach (double x in RCmaxAggArray)
            {
                string tooltip = "Coarse 1:\t" + RCcoarse1[temppp].ToString() + " %";
                tooltip += "\nCoarse 2:\t" + RCcoarse2[temppp].ToString() + " %";
                tooltip += "\nFine 1:\t\t" + RCfine1[temppp].ToString() + " %";
                tooltip += "\nFine 2:\t\t" + RCfine2[temppp].ToString() + " %";
                tooltip += "\nCombined:\t" + RCcombined[temppp].ToString() + " %";
                tooltip += "\nIdeal:\t\t" + RCideal[temppp].ToString() + " %";

                CustomLabel cl = new CustomLabel()
                {
                    FromPosition = temppp2,
                    ToPosition = (temppp2 + 1),
                    GridTicks = GridTickTypes.All,
                    Text = x.ToString(),
                    ToolTip = tooltip,
                    ForeColor = Color.Black,
                };
                resultChart.Refresh();
                resultChart.ChartAreas[0].Axes[0].CustomLabels.Add(cl);
                resultChart.ResetAutoValues();

                temppp2++;
                temppp++;
            }
        }
        private void createRetainedChart()
        {
            double[] RCmaxAggArray = new double[14 - maxAggSize];
            double[] RCcoarse1 = new double[14 - maxAggSize];
            double[] RCcoarse2 = new double[14 - maxAggSize];
            double[] RCfine1 = new double[14 - maxAggSize];
            double[] RCfine2 = new double[14 - maxAggSize];
            double[] RCcombined = new double[14 - maxAggSize];
            double[] RCideal = new double[14 - maxAggSize];

            double combinedFinal = ((a1 * a1i / 100) + (a2 * a2i / 100) + (a3 * a3i / 100) + (a4 * a4i / 100));
            int count = 0;
            foreach (DataGridViewRow row in data.Rows)
            {
                string size = row.Cells[0].Value.ToString();
                string c1 = row.Cells[1].Value.ToString();
                string c2 = row.Cells[2].Value.ToString();
                string f1 = row.Cells[3].Value.ToString();
                string f2 = row.Cells[4].Value.ToString();
                string combi = row.Cells[5].Value.ToString();
                string ideal = row.Cells[6].Value.ToString();

                RCmaxAggArray[count] = Convert.ToDouble(size);
                RCcoarse1[count] = Convert.ToDouble(c1);
                RCcoarse2[count] = Convert.ToDouble(c2);
                RCfine1[count] = Convert.ToDouble(f1);
                RCfine2[count] = Convert.ToDouble(f2);
                RCcombined[count] = ((Convert.ToDouble(row.Cells[1].Value) * a1i / 100) + (Convert.ToDouble(row.Cells[2].Value) * a2i / 100) + (Convert.ToDouble(row.Cells[3].Value) * a3i / 100) + (Convert.ToDouble(row.Cells[4].Value) * a4i / 100));
                RCideal[count] = Convert.ToDouble(ideal);
                count++;
            }
            chartRetained.Series.Clear();
            Series coarse1 = new Series() { Color = Color.Red, LegendText = "Coarse 1", ChartType = SeriesChartType.Line, BorderWidth = 1 };
            Series coarse2 = new Series() { Color = Color.Blue, LegendText = "Coarse 2", ChartType = SeriesChartType.Line, BorderWidth = 1 };
            Series fine1 = new Series() { Color = Color.Green, LegendText = "Fine 1", ChartType = SeriesChartType.Line, BorderWidth = 1 };
            Series fine2 = new Series() { Color = Color.Brown, LegendText = "Fine 2", ChartType = SeriesChartType.Line, BorderWidth = 1 };
            Series idealLine = new Series() { Color = Color.Teal, LegendText = "Ideal", ChartType = SeriesChartType.Line, BorderWidth = 4 };
            Series combinedLine = new Series() { Color = Color.DarkOrange, LegendText = "Combined", ChartType = SeriesChartType.Line, BorderWidth = 4 };


            coarse1.Points.Clear();
            //coarse1.Points.Add(x);
            //coarse2.Points.Add(x);
            //fine1.Points.Add(x);
            //fine2.Points.Add(x);
            //idealLine.Points.Add(x);
            //combinedLine.Points.Add(x);

            for (int i = 1; i < RCcoarse1.Length; i++)
            {
                coarse1.Points.Add(returnDiff(RCcoarse1, i));
            }
            for (int i = 1; i < RCcoarse2.Length; i++)
            {
                coarse2.Points.Add(returnDiff(RCcoarse2, i));
            }
            for (int i = 1; i < RCfine1.Length; i++)
            {
                fine1.Points.Add(returnDiff(RCfine1, i));
            }
            for (int i = 1; i < RCfine2.Length; i++)
            {
                fine2.Points.Add(returnDiff(RCfine2, i));
            }
            for (int i = 1; i < RCcombined.Length; i++)
            {
                combinedLine.Points.Add(returnDiff(RCcombined, i));
            }
            for (int i = 1; i < RCideal.Length; i++)
            {
                idealLine.Points.Add(returnDiff(RCideal, i));
            }

            chartRetained.ResetAutoValues();
            chartRetained.Series.Add(coarse1);
            chartRetained.Series.Add(coarse2);
            chartRetained.Series.Add(fine1);
            chartRetained.Series.Add(fine2);
            chartRetained.Series.Add(combinedLine);
            chartRetained.Series.Add(idealLine);
            chartRetained.ChartAreas[0].Axes[0].IsStartedFromZero = true;



            double temppp2 = -0.5;
            int temppp = 0;
            foreach (double x in RCmaxAggArray)
            {
                string tooltip = "Aggregate Size";


                CustomLabel cl = new CustomLabel()
                {
                    FromPosition = temppp2,
                    ToPosition = (temppp2 + 1),
                    GridTicks = GridTickTypes.All,
                    Text = x.ToString(),
                    ToolTip = tooltip,
                    ForeColor = Color.Black,
                };
                chartRetained.Refresh();
                chartRetained.ChartAreas[0].Axes[0].CustomLabels.Add(cl);
                chartRetained.ResetAutoValues();

                temppp2++;
                temppp++;
            }
        }
        public double returnDiff(double[] data, int index)
        {
            if (index + 1 == data.Length)
                return data[index];
            return data[index - 1] - data[index];
        }
        #region result
        private void fillResultDataTable()
        {
            dataResult.Rows.Clear();
            string[,] table = {
                { "Cement", "100", "100", "100","100" },
                { "Water", "100", "100", "100","100" },
                { "Aggregate F1", "100", "100", "100","100" },
                { "Aggregate F2", "100", "100", "100","100" },
                { "Aggregate C1", "64.9", "100", "100","100" },
                { "Aggregate C2", "64.9", "100", "100","100" },
                { "Air", "10.6", "56.4", "99,9","100" },
                { "TOTAL", "3.6", "3.5", "93.2","99.1" },
                { "----", "----", "----", "---","----" },
                { "Comb Fine(S1+S2)", "64.9", "100", "100","100" },
                { "Comb Coarse(S3+S4)", "64.9", "100", "100","100" },

            };
            //creating data dable with default values
            for (int i = 0; i < 11; i++)
            {
                int index = 0;
                string[] temp = new string[5];
                for (int j = 0; j < 5; j++)
                {
                    if (j == 0)
                        temp[index] = table[i, j];
                    else
                    {
                        switch (i)
                        {
                            #region Cement
                            case 0:
                                if (index == 1)
                                {
                                    temp[index] = Session.volumeOfCement.ToString("0.###");
                                }
                                if (index == 2)
                                {
                                    temp[index] = Session.cement.ToString("0.###");
                                }
                                if (index == 3)
                                {
                                    temp[index] = Session.cement.ToString("0.###");
                                }
                                if (index == 4)
                                {
                                    temp[index] = Session.cement.ToString("0.###");
                                }
                                break;
                            #endregion
                            #region Water
                            case 1:
                                if (index == 1)
                                {
                                    temp[index] = Session.volumeOfWater.ToString("0.###");
                                }
                                if (index == 2)
                                {
                                    temp[index] = Session.ssdWeightOfWater.ToString("0.###");
                                }
                                if (index == 3)
                                {
                                    temp[index] = Session.dryWeightOfWater.ToString("0.###");
                                }
                                if (index == 4)
                                {
                                    temp[index] = Session.curWeightOfWater.ToString("0.###");
                                }
                                break;
                            #endregion
                            #region Fine Aggregate
                            case 2:
                                if (index == 1)
                                {

                                    temp[index] = (Session.volumeOfFineAggregate * Session.value3 / (Session.value3 + Session.value4)).ToString("0.###");
                                }
                                if (index == 2)
                                {

                                    temp[index] = (Session.ssdWeightFA * Session.value3 / (Session.value3 + Session.value4)).ToString("0.###");
                                }
                                if (index == 3)
                                {
                                    temp[index] = (Session.dryWeightFA * Session.value3 / (Session.value3 + Session.value4)).ToString("0.###");
                                }
                                if (index == 4)
                                {
                                    temp[index] = (Session.curWeightFA * Session.value3 / (Session.value3 + Session.value4)).ToString("0.###");
                                }
                                break;
                            case 3:
                                if (index == 1)
                                {
                                    temp[index] = (Session.volumeOfFineAggregate * Session.value4 / (Session.value3 + Session.value4)).ToString("0.###");
                                }
                                if (index == 2)
                                {
                                    temp[index] = (Session.ssdWeightFA * Session.value4 / (Session.value3 + Session.value4)).ToString("0.###");
                                }
                                if (index == 3)
                                {
                                    temp[index] = (Session.dryWeightFA * Session.value4 / (Session.value3 + Session.value4)).ToString("0.###");
                                }
                                if (index == 4)
                                {
                                    temp[index] = (Session.curWeightFA * Session.value4 / (Session.value3 + Session.value4)).ToString("0.###");
                                }
                                break;
                            #endregion
                            #region Coarse Aggregate
                            case 4:
                                if (index == 1)
                                {
                                    temp[index] = (Session.volumeOfCourseAggregate * Session.value1 / (Session.value1 + Session.value2)).ToString("0.###");
                                }
                                if (index == 2)
                                {
                                    temp[index] = (Session.ssdWeightCA * Session.value1 / (Session.value1 + Session.value2)).ToString("0.###");
                                }
                                if (index == 3)
                                {
                                    temp[index] = (Session.dryWeightCA * Session.value1 / (Session.value1 + Session.value2)).ToString("0.###");
                                }
                                if (index == 4)
                                {
                                    temp[index] = (Session.curWeightCA * Session.value1 / (Session.value1 + Session.value2)).ToString("0.###");
                                }
                                break;
                            case 5:
                                if (index == 1)
                                {
                                    temp[index] = (Session.volumeOfCourseAggregate * Session.value2 / (Session.value1 + Session.value2)).ToString("0.###");
                                }
                                if (index == 2)
                                {
                                    temp[index] = (Session.ssdWeightCA * Session.value2 / (Session.value1 + Session.value2)).ToString("0.###");
                                }
                                if (index == 3)
                                {
                                    temp[index] = (Session.dryWeightCA * Session.value2 / (Session.value1 + Session.value2)).ToString("0.###");
                                }
                                if (index == 4)
                                {
                                    temp[index] = (Session.curWeightCA * Session.value2 / (Session.value1 + Session.value2)).ToString("0.###");
                                }
                                break;
                            #endregion
                            #region Air
                            case 6:
                                if (index == 1)
                                {
                                    temp[index] = Session.volumeOfEntAir.ToString("0.###");
                                }
                                if (index == 2)
                                {
                                    temp[index] = "0";
                                }
                                if (index == 3)
                                {
                                    temp[index] = "0";
                                }
                                if (index == 4)
                                {
                                    temp[index] = "0";
                                }
                                break;
                            #endregion
                            #region TOTAL
                            case 7:
                                if (index == 1)
                                {
                                    temp[index] = (Session.volumeOfCement + Session.volumeOfCourseAggregate + Session.volumeOfEntAir + Session.volumeOfFineAggregate + Session.volumeOfWater).ToString("0.###"); ;
                                }
                                if (index == 2)
                                {
                                    temp[index] = Session.ingredientSum.ToString("0.###");
                                }
                                if (index == 3)
                                {
                                    temp[index] = Session.ingredientSum.ToString("0.###");
                                }
                                if (index == 4)
                                {
                                    temp[index] = Session.ingredientSum.ToString("0.###");
                                }
                                break;
                            #endregion

                            #region boşlu
                            case 8:
                                if (index == 1)
                                {
                                    temp[index] = "----";
                                }
                                if (index == 2)
                                {
                                    temp[index] = "----";
                                }
                                if (index == 3)
                                {
                                    temp[index] = "----";
                                }
                                if (index == 4)
                                {
                                    temp[index] = "----";
                                }
                                break;
                            #endregion
                            #region Comb Fine Aggregate
                            case 9:
                                if (index == 1)
                                {
                                    temp[index] = Session.volumeOfFineAggregate.ToString("0.###");
                                }
                                if (index == 2)
                                {
                                    temp[index] = Session.ssdWeightFA.ToString("0.###");
                                }
                                if (index == 3)
                                {
                                    temp[index] = Session.dryWeightFA.ToString("0.###");
                                }
                                if (index == 4)
                                {
                                    temp[index] = Session.curWeightFA.ToString("0.###");
                                }
                                break;
                            #endregion
                            #region Coomarse Aggregate
                            case 10:
                                if (index == 1)
                                {
                                    temp[index] = Session.volumeOfCourseAggregate.ToString("0.###");
                                }
                                if (index == 2)
                                {
                                    temp[index] = Session.ssdWeightCA.ToString("0.###");
                                }
                                if (index == 3)
                                {
                                    temp[index] = Session.dryWeightCA.ToString("0.###");
                                }
                                if (index == 4)
                                {
                                    temp[index] = Session.curWeightCA.ToString("0.###");
                                }
                                break;
                                #endregion

                        }
                    }
                    index++;
                }
                dataResult.Rows.Add(temp);
            }
            dataResult.AllowUserToResizeRows = false;
            dataResult.AllowUserToOrderColumns = false;
            dataResult.AllowUserToDeleteRows = false;
        }
        int water = 1234;
        double waterCementRatio = 1234;

        double cement = 1234;
        double volumeOfCement = 1234;

        double ssdWeightOfWater = 1234;
        double dryWeightOfWater = 1234;
        double curWeightOfWater = 1234;
        double volumeOfWater = 1234.0000;

        double volumeOfFineAggregate = 1234;
        double ssdWeightFA = 1234;
        double dryWeightFA = 1234;
        double curWeightFA = 1234;

        double volumeOfCourseAggregate = 1234;
        double dryWeightCA = 1234;
        double ssdWeightCA = 1234;
        double curWeightCA = 1234;
        private void resultChart_Click(object sender, EventArgs e)
        {

        }

        double volumeOfEntAir = 1234;
        double entrappedAir = 1234;
        double ingredientSum = 1234;
        double totalResult = 1234;

        private void showResult()
        {
            maxAggSize = cbMaxAggregaSize.SelectedIndex;
            slump = cbSlump.SelectedIndex;
            int airDetail = cbAirDetail.SelectedIndex;

            if (rdAirStatusYes.Checked) //air entrained
            {
                int[,] waterArray = {
                {181,175,168,160,150,142,122 },
                {202,193,184,175,165,157,133 },
                {216,205,197,184,174,166,154 } };
                water = waterArray[slump, 6 - maxAggSize];

                double[,] entrappedAirArr = {
                {4.5, 4, 3.5, 3, 2.5, 2, 1.5 },
                {6, 5.5, 5, 4.5, 4.5, 4, 3.5 },
                {7.5, 7, 6, 6, 5.5, 5, 4.5}};
                entrappedAir = entrappedAirArr[airDetail, 6 - maxAggSize];

                double[] waterCementRatioArr = { .39, .45, .52, .6, .7 };
                if (cbStrength.SelectedIndex != 0)
                    waterCementRatio = waterCementRatioArr[cbStrength.SelectedIndex - 1];
            }
            else //non-air entrained
            {
                int[,] waterArray = {
                {207,199,190,179,166,154,130},
                {228,216,205,193,181,169,145 },
                {243,228,216,202,190,178,160 } };
                water = waterArray[slump, 6 - maxAggSize];

                double[] entrappedAirArr = { 3, 2.5, 2, 1.5, 1, 0.5, 0.3 };
                entrappedAir = entrappedAirArr[6 - maxAggSize];

                double[] waterCementRatioArr = { .42, .47, .54, .61, .69, .79 };
                waterCementRatio = waterCementRatioArr[cbStrength.SelectedIndex];
            }

            // cement ağırlığı bu
            cement = water / waterCementRatio;

            //CA hacim
            double[,] volumeCA = {
                { .50, .48, .46, .44 },
                { .59, .57, .55, .53 },
                { .66, .64, .62, .60 },
                { .71, .69, .67, .65 },
                { .75, .73, .71, .69 },
                { .78, .76, .74, .72 },
                { .82, .80, .78, .76 } };

            volumeOfCement = cement / 3150;
            double temp = 1000.00;
            volumeOfWater = water / temp;

            volumeOfEntAir = entrappedAir / 100;
            if (!ctrlFM)
                volumeOfCourseAggregate = volumeCA[6 - maxAggSize, 1];
            else
                volumeOfCourseAggregate = volumeCA[6 - maxAggSize, cbFiness.SelectedIndex];

            dryWeightCA = Convert.ToDouble(txtCCUWDR.Text.Replace(',', '.')) * volumeOfCourseAggregate;
            ssdWeightCA = ((Convert.ToDouble(txtCCAC.Text.Replace(',', '.')) / 100) + 1) * dryWeightCA;

            double volumeOfCourseAggregate2 = ssdWeightCA / (1000 * Convert.ToDouble(txtCCBSG.Text.Replace(',', '.')));
            curWeightCA = dryWeightCA * (1 + Convert.ToDouble(txtCCTMC.Text.Replace(',', '.')) / 100);

            volumeOfFineAggregate = 1 - (volumeOfCement + volumeOfCourseAggregate2 + volumeOfWater + volumeOfEntAir);

            ssdWeightFA = 1000 * Convert.ToDouble(txtFCCSSD.Text.Replace(',', '.')) * volumeOfFineAggregate;
            dryWeightFA = ssdWeightFA / (1 + Convert.ToDouble(txtFCCAC.Text.Replace(',', '.')) / 100);
            curWeightFA = dryWeightFA * (Convert.ToDouble(txtFCCCWC.Text.Replace(',', '.')) / 100 + 1);
            ssdWeightOfWater = water;

            ingredientSum = cement + ssdWeightCA + ssdWeightFA + ssdWeightOfWater;
            totalResult = volumeOfCement + volumeOfCourseAggregate + volumeOfEntAir + volumeOfFineAggregate + volumeOfWater;

            dryWeightOfWater = ingredientSum - (cement + dryWeightCA + dryWeightFA);
            curWeightOfWater = ingredientSum - (cement + curWeightCA + curWeightFA);


            Session.water = water;
            Session.waterCementRatio = waterCementRatio;
            Session.cement = cement;
            Session.volumeOfCement = volumeOfCement;
            Session.ssdWeightOfWater = ssdWeightOfWater;
            Session.dryWeightOfWater = dryWeightOfWater;
            Session.curWeightOfWater = curWeightOfWater;
            Session.volumeOfWater = volumeOfWater;
            Session.volumeOfFineAggregate = volumeOfFineAggregate;
            Session.ssdWeightFA = ssdWeightFA;
            Session.dryWeightFA = dryWeightFA;
            Session.curWeightFA = curWeightFA;
            Session.volumeOfCourseAggregate = volumeOfCourseAggregate2;
            Session.dryWeightCA = dryWeightCA;
            Session.ssdWeightCA = ssdWeightCA;
            Session.curWeightCA = curWeightCA;
            Session.volumeOfEntAir = volumeOfEntAir;
            Session.entrappedAir = entrappedAir;
            Session.ingredientSum = ingredientSum;
            Session.totalResult = totalResult;

            fillResultDataTable();
            ctrlResultTable = true;
        }
        #endregion

        private void btnNext_Click(object sender, EventArgs e)
        {
            #region nextSwitch

            switch (Session.activeTabIndex)
            {
                case "0":

                    if (ctrlAirStatus && ctrlStrength && ctrlMaxAggSize && ctrlSlump)
                    {
                        if (rdAirStatusYes.Checked)
                        {
                            if (ctrlAirDetail)
                            {
                                if (cbStrength.SelectedIndex == 0)
                                {

                                    MessageBox.Show("You can't select 40 MPa strenght and Air Entrained together");
                                }
                                else
                                {
                                    bar.Value = 25;
                                    this.tabControl.SelectedIndex = 1;
                                    Session.activeTabIndex = "1";
                                    textPageNumber.Text = "2";
                                    btnPrevious.Enabled = true;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Please fill all labels.");
                                return;
                            }
                        }
                        else
                        {
                            this.tabControl.SelectedIndex = 1;
                            Session.activeTabIndex = "1";
                            textPageNumber.Text = "2";
                            btnPrevious.Enabled = true;
                        }
                    }
                    else
                        MessageBox.Show("Please fill all labels.");
                    break;
                case "1":
                    calculate();
                    this.tabControl.SelectedIndex = 2;
                    Session.activeTabIndex = "2";
                    textPageNumber.Text = "3";
                    bar.Value = 35;
                    //MessageBox.Show("A1=" + a1i.ToString() + "\nA2=" + a2i.ToString() + "\nA3=" + a3i.ToString() + "\nA4=" + a4i.ToString() + "\nSum=" + total, "Iteration Counts");

                    break;
                case "2":
                    if (ctrlC1AC && ctrlC1BSG && ctrlC1TMC && ctrlC1UWDR && ctrlC2AC && ctrlC2BSG && ctrlC2TMC && ctrlC2UWDR)
                        if (ctrlCCCalculate)
                        {
                            bar.Value = 70;
                            this.tabControl.SelectedIndex = 3;
                            Session.activeTabIndex = "3";
                            textPageNumber.Text = "4";
                        }
                        else
                        {
                            calculateCoarse();

                        }

                    else
                        MessageBox.Show("Please fill all the labels.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "3":
                    if (ctrlFC1AC && ctrlFC1CWC && ctrlFC1SSD && ctrlFC2AC && ctrlFC2CWC && ctrlFC2SSD)
                        if (ctrlCCCalculateF)
                        {
                            bar.Value = 99;
                            this.tabControl.SelectedIndex = 4;
                            Session.activeTabIndex = "4";
                            textPageNumber.Text = "5";
                            //redirecting to result
                            pnlNavBar.Visible = true;
                            bar.Visible = false;
                            textPageNumber.Visible = false;
                            btnNext.Visible = false;
                            btnPrevious.Visible = false;
                           
                            showResult();
                            createProperties();
                            createResultChart();
                            createRetainedChart();
                        }
                        else
                        {
                            calculateCoarseFiness();
                           
                            btnNext.Text = "FINISH";

                        }

                    else
                        MessageBox.Show("Please fill all the labels.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;


            }


            #endregion
        }
        // Resul Table Butonu 
        private void buttonResult_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedIndex = 4;
            showResult();
        }

        // Percent Passing Butonu 
        private void btnPassAnalysis_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedIndex = 5;
            createResultChart();

        }

        // Percent Reatin Butonu 
        private void btnRetainedCurve_Click(object sender, EventArgs e)
        {
            //createResultChart2();
            this.tabControl.SelectedIndex = 6;
            createRetainedChart();


        }

        // Percent Propertiex Butonu 
        private void btnProperData_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedIndex = 7;
            createProperties();
        }
        private void createProperties()
        {

            strengthValue.Text = cbStrength.SelectedItem.ToString() + " MPa";

            if (rdAirStatusYes.Checked)
            { labelAriValue.Text = "Air Entrained"; }

            else { labelAriValue.Text = "Non-Air Entrained"; }

            labelMaxaggrsize.Text = cbMaxAggregaSize.SelectedItem.ToString() + " mm";
            labelSlump.Text = cbSlump.SelectedItem.ToString() + " mm";

            c1pers.Text = a1i.ToString(".00") + " %";
            c2pers.Text = a2i.ToString(".00") + " %";
            f1pers.Text = a3i.ToString(".00") + " %";
            f2pers.Text = a4i.ToString(".00") + " %";
            labelssdc1.Text = txtC1BSG.Text;
            labelssdc2.Text = txtC2BSG.Text;
            labeluwdc1.Text = txtC1UWDR.Text + " kg/m3";
            labeluwdc2.Text = txtC2UWDR.Text + " kg/m3";
            labelac1.Text = txtC1AC.Text + " %";
            labelac2.Text = txtC2AC.Text + " %";
            labeltmc1.Text = txtC1TMC.Text + " %";
            labeltmc2.Text = txtC2TMC.Text + " %";
            labelssdf1.Text = txtFC1SSD.Text;
            labelssdf2.Text = txtFC2SSD.Text;
            labelabf1.Text = txtFC1AC.Text + " %";
            labelacf2.Text = txtFC2AC.Text + " %";
            labelcwcf1.Text = txtFC1CWC.Text + " %";
            labelcwcf2.Text = txtFC2CWC.Text + " %";
            labelfin.Text = cbFiness.SelectedItem.ToString();
            tutulmusDeger.Text = tutulacakDeger.ToString()+" %";
           
            double tutulacakDeger2 = 100 - tutulacakDeger;
            tutulmusDeger2.Text = tutulacakDeger2.ToString() + " %";
        }
        // Percent PassingButonu 
        private void btnCost_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedIndex = 8;
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (User.Default.isCostCalculated)
                bntPrintCost.Enabled = true;

            this.tabControl.SelectedIndex = 9;
            
        }
        private string deskTopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
     
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            #region prevSwitch
            switch (Session.activeTabIndex)
            {

                case "1":
                    textPageNumber.Text = "1";
                    this.tabControl.SelectedIndex = 0;
                    Session.activeTabIndex = "0";
                    btnPrevious.Enabled = false;
                    break;
                case "2":
                    textPageNumber.Text = "2";
                    this.tabControl.SelectedIndex = 1;
                    Session.activeTabIndex = "1";
                    break;
                case "3":
                    textPageNumber.Text = "3";
                    this.tabControl.SelectedIndex = 2;
                    Session.activeTabIndex = "2";
                    ctrlCCCalculate = false;
                    btnNext.Text = "NEXT";
                    break;
                case "4":
                    textPageNumber.Text = "4";
                    btnNext.Text = "NEXT";
                    this.tabControl.SelectedIndex = 3;
                    Session.activeTabIndex = "3";
                    ctrlCCCalculateF = false;

                    break;
                case "5":
                    textPageNumber.Text = "4";
                    btnNext.Text = "NEXT";
                    this.tabControl.SelectedIndex = 4;
                    Session.activeTabIndex = "4";
                    break;
                case "6":
                    textPageNumber.Text = "4";
                    btnNext.Text = "NEXT";
                    this.tabControl.SelectedIndex = 4;
                    Session.activeTabIndex = "4";
                    break;
            }
            #endregion
        }
        private void data_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            data.Columns[0].Frozen = true;
            data.Columns[5].Frozen = true;
            data.Columns[6].Frozen = true;

            if (data.CurrentCell.ColumnIndex == 0 || data.CurrentCell.ColumnIndex == 5 || data.CurrentCell.ColumnIndex == 6)
            {
                data.Columns[0].ReadOnly = true;
                data.Columns[5].ReadOnly = true;
                data.Columns[6].ReadOnly = true;
            }
        }
        private void data_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(data.CurrentCell.Value.ToString()))

                    //Her satırda hesaplamasını kapattık
                    //  calculate();

                    if (data.CurrentCell.ColumnIndex == 0 || data.CurrentCell.ColumnIndex == 5 || data.CurrentCell.ColumnIndex == 6)
                    {
                        data.Columns[0].Frozen = true;
                        data.Columns[5].Frozen = true;
                        data.Columns[6].Frozen = true;
                        data.Columns[0].ReadOnly = true;
                        data.Columns[5].ReadOnly = true;
                        data.Columns[6].ReadOnly = true;
                    }
                //else
                //    data.CurrentCell.Value = "0";

            }
            catch (Exception ex)
            {
                Console.WriteLine("HATAHATA" + ex.Message);
            }
        }

        ///bazı kodlar buraya

        //cost        
        private void printbutonu1_Click(object sender, EventArgs e)
        {
            PrintDocument myPrintDocument1 = new PrintDocument();
            PrintDialog myPrintDialog1 = new PrintDialog();

            myPrintDocument1.DocumentName = "ReportCost-" + DateTime.Today.ToString();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printPageCost);

            PaperSize ps = new PaperSize("reportCustom", 790, 390);
            myPrintDocument1.DefaultPageSettings.PaperSize = ps;

            myPrintDialog1.Document = myPrintDocument1;
            if (myPrintDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrintDocument1.Print();
            }
            myPrintDialog1.Dispose();
        }
        private void printPageCost(object sender, PrintPageEventArgs e)
        {
            try
            {
                Control pnlCost = tabCost;
                Bitmap bmpCost = new Bitmap(pnlCost.Width, pnlCost.Height);
                using (bmpCost)
                {
                    pnlCost.DrawToBitmap(bmpCost, new Rectangle(0, 0, bmpCost.Width, bmpCost.Height));
                    e.Graphics.DrawImage(bmpCost, 0, 0);
                    e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                    bmpCost.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //result table
        private void printPageResult(object sender, PrintPageEventArgs e)
        {
            try
            {
                Control pnlResult = tabResult;
                Bitmap bmpResult = new Bitmap(pnlResult.Width, pnlResult.Height);
                using (bmpResult)
                {
                    pnlResult.DrawToBitmap(bmpResult, new Rectangle(0, 0, bmpResult.Width, bmpResult.Height));
                    e.Graphics.DrawImage(bmpResult, 0, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void bntPrintResult_Click(object sender, EventArgs e)
        {
            PrintDocument myPrintDocument1 = new PrintDocument();
            PrintDialog myPrintDialog1 = new PrintDialog();

            myPrintDocument1.DocumentName = "ReportResultTable" + DateTime.Today.ToString();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printPageResult);

            PaperSize ps = new PaperSize("reportCustom", 790, 390);
            myPrintDocument1.DefaultPageSettings.PaperSize = ps;

            myPrintDialog1.Document = myPrintDocument1;
            if (myPrintDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrintDocument1.Print();
            }
            myPrintDialog1.Dispose();
        }

        //passing
        private void printPagePassing(object sender, PrintPageEventArgs e)
        {
            try
            {
                Control pnlPassing = tabPassing;
                Bitmap bmpPassing = new Bitmap(pnlPassing.Width, pnlPassing.Height);
                using (bmpPassing)
                {
                    pnlPassing.DrawToBitmap(bmpPassing, new Rectangle(0, 0, bmpPassing.Width, bmpPassing.Height));
                    e.Graphics.DrawImage(bmpPassing, 0, 0);
                    e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                    bmpPassing.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void bntPrintPassing_Click(object sender, EventArgs e)
        {
            

            PrintDocument myPrintDocument1 = new PrintDocument();
            PrintDialog myPrintDialog1 = new PrintDialog();

            myPrintDocument1.DocumentName = "ReportPassing-" + DateTime.Today.ToString();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printPagePassing);

            PaperSize ps = new PaperSize("reportCustom", 790, 390);
            myPrintDocument1.DefaultPageSettings.PaperSize = ps;

            myPrintDialog1.Document = myPrintDocument1;
            if (myPrintDialog1.ShowDialog() == DialogResult.OK)
            {
                
                myPrintDocument1.Print();
            }
            myPrintDialog1.Dispose();
        }

        //retained
        private void bntPrintRetained_Click(object sender, EventArgs e)
        {

            PrintDocument myPrintDocument1 = new PrintDocument();
            PrintDialog myPrintDialog1 = new PrintDialog();

            myPrintDocument1.DocumentName = "ReportRetained-" + DateTime.Today.ToString();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printPageRetained);

            PaperSize ps = new PaperSize("reportCustom", 790, 390);
            myPrintDocument1.DefaultPageSettings.PaperSize = ps;

            myPrintDialog1.Document = myPrintDocument1;
            if (myPrintDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrintDocument1.Print();
            }
            myPrintDialog1.Dispose();
        }
        private void printPageRetained(object sender, PrintPageEventArgs e)
        {
            try
            {
                Control pnlRetained = tabRetained;
                Bitmap bmpRetained = new Bitmap(pnlRetained.Width, pnlRetained.Height);
                using (bmpRetained)
                {
                    pnlRetained.DrawToBitmap(bmpRetained, new Rectangle(0, 0, bmpRetained.Width, bmpRetained.Height));
                    e.Graphics.DrawImage(bmpRetained, 0, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //properties
        private void bntPrintProperties_Click(object sender, EventArgs e)
        {

            PrintDocument myPrintDocument1 = new PrintDocument();
            PrintDialog myPrintDialog1 = new PrintDialog();

            myPrintDocument1.DocumentName = "ReportProperties-" + DateTime.Today.ToString();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printPageProperties);

            PaperSize ps = new PaperSize("reportCustom", 790, 390);
            myPrintDocument1.DefaultPageSettings.PaperSize = ps;

            myPrintDialog1.Document = myPrintDocument1;
            if (myPrintDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrintDocument1.Print();
            }
            myPrintDialog1.Dispose();
        }
        private void printPageProperties(object sender, PrintPageEventArgs e)
        {
            try
            {
                Control pnlProperties = tabSieveData;
                Bitmap bmpProperties = new Bitmap(pnlProperties.Width, pnlProperties.Height);
                using (bmpProperties)
                {
                    pnlProperties.DrawToBitmap(bmpProperties, new Rectangle(0, 0, bmpProperties.Width, bmpProperties.Height));
                    e.Graphics.DrawImage(bmpProperties, 0, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        ////

        #region BarControls
        private void cbAirDetail_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!ctrlAirDetail)
                bar.Value += 4;
            ctrlAirDetail = true;
        }
        private void rdAirStatusYes_CheckedChanged(object sender, EventArgs e)
        {
            if (!ctrlAirStatus)
                bar.Value += 4;
            ctrlAirStatus = true;
            cbAirDetail.Visible = true;
        }
        private void rdAirStatusNo_CheckedChanged(object sender, EventArgs e)
        {
            if (!ctrlAirStatus)
                bar.Value += 4;
            ctrlAirStatus = true;
            cbAirDetail.Visible = false;
        }
        private void cbStrength_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!ctrlStrength)
                bar.Value += 4;
            ctrlStrength = true;
        }
        private void cbMaxAggregaSize_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!ctrlMaxAggSize)
                bar.Value += 4;
            ctrlMaxAggSize = true;
            fillDataTable();
        }

        private void sieveData_Click(object sender, EventArgs e)
        {

        }

        private void cbFiness_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!ctrlFM)
            {
                bar.Value += 4;
                ctrlFM = true;
            }
        }
        private void cbSlump_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!ctrlSlump)
                bar.Value += 4;
            ctrlSlump = true;
        }

        bool ctrlC1AC = false, ctrlC1BSG = false, ctrlC1TMC = false, ctrlC1UWDR = false,
             ctrlC2AC = false, ctrlC2BSG = false, ctrlC2TMC = false, ctrlC2UWDR = false;

        bool ctrlFC1AC = false, ctrlFC1CWC = false, ctrlFC1SSD = false,
             ctrlFC2AC = false, ctrlFC2CWC = false, ctrlFC2SSD = false;
        private void txtC1BSG_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlC1BSG)
            {
                bar.Value += 4;
                ctrlC1BSG = true;
            }
        }
        private void txtC2BSG_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlC2BSG)
                bar.Value += 4;
            ctrlC2BSG = true;
        }
        private void txtC1UWDR_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlC1UWDR)
                bar.Value += 4;
            ctrlC1UWDR = true;
        }
        private void txtC2UWDR_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlC2UWDR)
                bar.Value += 4;
            ctrlC2UWDR = true;
        }
        private void txtC1AC_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlC1AC)
                bar.Value += 4;
            ctrlC1AC = true;
        }
        private void txtC2AC_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlC2AC)
                bar.Value += 4;
            ctrlC2AC = true;
        }
        private void txtC1TMC_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlC1TMC)
                bar.Value += 4;
            ctrlC1TMC = true;
        }
        private void txtC2TMC_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlC2TMC)
                bar.Value += 4;
            ctrlC2TMC = true;
        }
        private void txtFC1SSD_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlFC1SSD)
                bar.Value += 4;
            ctrlFC1SSD = true;
        }
        private void txtFC2SSD_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlFC2SSD)
            {
                bar.Value += 4;
                ctrlFC2SSD = true;
            }
        }
        private void txtFC1AC_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlFC1AC)
            {
                bar.Value += 4;
                ctrlFC1AC = true;
            }
        }
        private void txtFC2AC_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlFC2AC)
            {
                bar.Value += 4;
                ctrlFC2AC = true;
            }
        }
        private void txtFC1CWC_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlFC1CWC)
            {
                bar.Value += 4;
                ctrlFC1CWC = true;
            }
        }
        private void txtFC2CWC_TextChanged(object sender, EventArgs e)
        {
            if (!ctrlFC2CWC)
            {
                bar.Value += 4;
                ctrlFC2CWC = true;
            }
        }
        #endregion
    }
}

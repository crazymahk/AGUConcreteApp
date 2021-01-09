namespace capstoneProject
{
    partial class Cost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCement = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCostCalculate = new System.Windows.Forms.Button();
            this.txtWaterPrice = new System.Windows.Forms.MaskedTextBox();
            this.txtCAPrice = new System.Windows.Forms.MaskedTextBox();
            this.txtFAPrice = new System.Windows.Forms.MaskedTextBox();
            this.txtCementPrice = new System.Windows.Forms.MaskedTextBox();
            this.priceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.costLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.priceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cost Estimation";
            // 
            // txtCement
            // 
            this.txtCement.AutoSize = true;
            this.txtCement.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCement.ForeColor = System.Drawing.SystemColors.Window;
            this.txtCement.Location = new System.Drawing.Point(8, 81);
            this.txtCement.Name = "txtCement";
            this.txtCement.Size = new System.Drawing.Size(188, 24);
            this.txtCement.TabIndex = 3;
            this.txtCement.Text = "Cement Price (Tone) ₺";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(8, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fine Aggregate (Tone) ₺";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(8, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Coarse Aggregate (Tone) ₺";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(8, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Water Price (m³) ₺";
            // 
            // btnCostCalculate
            // 
            this.btnCostCalculate.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCostCalculate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCostCalculate.Location = new System.Drawing.Point(12, 285);
            this.btnCostCalculate.Name = "btnCostCalculate";
            this.btnCostCalculate.Size = new System.Drawing.Size(175, 34);
            this.btnCostCalculate.TabIndex = 11;
            this.btnCostCalculate.Text = "Cost Calculation";
            this.btnCostCalculate.UseVisualStyleBackColor = true;
            this.btnCostCalculate.Click += new System.EventHandler(this.btnCostCalculate_Click);
            // 
            // txtWaterPrice
            // 
            this.txtWaterPrice.Location = new System.Drawing.Point(12, 258);
            this.txtWaterPrice.Name = "txtWaterPrice";
            this.txtWaterPrice.Size = new System.Drawing.Size(175, 20);
            this.txtWaterPrice.TabIndex = 24;
            // 
            // txtCAPrice
            // 
            this.txtCAPrice.Location = new System.Drawing.Point(12, 208);
            this.txtCAPrice.Name = "txtCAPrice";
            this.txtCAPrice.Size = new System.Drawing.Size(175, 20);
            this.txtCAPrice.TabIndex = 23;
            // 
            // txtFAPrice
            // 
            this.txtFAPrice.Location = new System.Drawing.Point(12, 158);
            this.txtFAPrice.Name = "txtFAPrice";
            this.txtFAPrice.Size = new System.Drawing.Size(175, 20);
            this.txtFAPrice.TabIndex = 22;
            // 
            // txtCementPrice
            // 
            this.txtCementPrice.Location = new System.Drawing.Point(12, 108);
            this.txtCementPrice.Name = "txtCementPrice";
            this.txtCementPrice.Size = new System.Drawing.Size(175, 20);
            this.txtCementPrice.TabIndex = 21;
            // 
            // priceChart
            // 
            this.priceChart.BackColor = System.Drawing.Color.Transparent;
            this.priceChart.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea1.Name = "ChartArea1";
            this.priceChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.priceChart.Legends.Add(legend1);
            this.priceChart.Location = new System.Drawing.Point(232, 12);
            this.priceChart.Name = "priceChart";
            this.priceChart.Size = new System.Drawing.Size(524, 344);
            this.priceChart.TabIndex = 25;
            this.priceChart.Text = "chart1";
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.costLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.costLabel.Location = new System.Drawing.Point(15, 332);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(137, 24);
            this.costLabel.TabIndex = 26;
            this.costLabel.Text = "Total Cost is 0 ₺";
            // 
            // Cost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(768, 368);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.priceChart);
            this.Controls.Add(this.txtWaterPrice);
            this.Controls.Add(this.txtCAPrice);
            this.Controls.Add(this.txtFAPrice);
            this.Controls.Add(this.txtCementPrice);
            this.Controls.Add(this.btnCostCalculate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCement);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(768, 368);
            this.MinimumSize = new System.Drawing.Size(768, 368);
            this.Name = "Cost";
            this.Text = "cost";
            ((System.ComponentModel.ISupportInitialize)(this.priceChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtCement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCostCalculate;
        private System.Windows.Forms.MaskedTextBox txtWaterPrice;
        private System.Windows.Forms.MaskedTextBox txtCAPrice;
        private System.Windows.Forms.MaskedTextBox txtFAPrice;
        private System.Windows.Forms.MaskedTextBox txtCementPrice;
        private System.Windows.Forms.DataVisualization.Charting.Chart priceChart;
        private System.Windows.Forms.Label costLabel;
    }
}
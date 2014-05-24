namespace PhysicalSimulator
{
    partial class Reportes
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.c1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lmedia = new System.Windows.Forms.Label();
            this.lmax = new System.Windows.Forms.Label();
            this.lmin = new System.Windows.Forms.Label();
            this.lminy = new System.Windows.Forms.Label();
            this.lmaxy = new System.Windows.Forms.Label();
            this.lmy = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1
            // 
            chartArea1.Name = "ChartArea1";
            this.c1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.c1.Legends.Add(legend1);
            this.c1.Location = new System.Drawing.Point(12, 25);
            this.c1.Name = "c1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.c1.Series.Add(series1);
            this.c1.Size = new System.Drawing.Size(606, 543);
            this.c1.TabIndex = 0;
            this.c1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 603);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 82);
            this.button1.TabIndex = 1;
            this.button1.Text = "Siguiente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 603);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Velocidad X Media:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 638);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Velocidad X Máxima:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 672);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Velocidad X Mínima:";
            // 
            // lmedia
            // 
            this.lmedia.AutoSize = true;
            this.lmedia.Location = new System.Drawing.Point(169, 603);
            this.lmedia.Name = "lmedia";
            this.lmedia.Size = new System.Drawing.Size(35, 13);
            this.lmedia.TabIndex = 5;
            this.lmedia.Text = "label4";
            // 
            // lmax
            // 
            this.lmax.AutoSize = true;
            this.lmax.Location = new System.Drawing.Point(169, 638);
            this.lmax.Name = "lmax";
            this.lmax.Size = new System.Drawing.Size(35, 13);
            this.lmax.TabIndex = 6;
            this.lmax.Text = "label4";
            // 
            // lmin
            // 
            this.lmin.AutoSize = true;
            this.lmin.Location = new System.Drawing.Point(169, 672);
            this.lmin.Name = "lmin";
            this.lmin.Size = new System.Drawing.Size(35, 13);
            this.lmin.TabIndex = 7;
            this.lmin.Text = "label4";
            // 
            // lminy
            // 
            this.lminy.AutoSize = true;
            this.lminy.Location = new System.Drawing.Point(399, 672);
            this.lminy.Name = "lminy";
            this.lminy.Size = new System.Drawing.Size(35, 13);
            this.lminy.TabIndex = 13;
            this.lminy.Text = "label4";
            // 
            // lmaxy
            // 
            this.lmaxy.AutoSize = true;
            this.lmaxy.Location = new System.Drawing.Point(399, 638);
            this.lmaxy.Name = "lmaxy";
            this.lmaxy.Size = new System.Drawing.Size(35, 13);
            this.lmaxy.TabIndex = 12;
            this.lmaxy.Text = "label4";
            // 
            // lmy
            // 
            this.lmy.AutoSize = true;
            this.lmy.Location = new System.Drawing.Point(399, 603);
            this.lmy.Name = "lmy";
            this.lmy.Size = new System.Drawing.Size(35, 13);
            this.lmy.TabIndex = 11;
            this.lmy.Text = "label4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 672);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Velocidad Y Mínima:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 638);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Velocidad Y Máxima:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 603);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Velocidad Y Media:";
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 718);
            this.Controls.Add(this.lminy);
            this.Controls.Add(this.lmaxy);
            this.Controls.Add(this.lmy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lmin);
            this.Controls.Add(this.lmax);
            this.Controls.Add(this.lmedia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.c1);
            this.Name = "Reportes";
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.c1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart c1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lmedia;
        private System.Windows.Forms.Label lmax;
        private System.Windows.Forms.Label lmin;
        private System.Windows.Forms.Label lminy;
        private System.Windows.Forms.Label lmaxy;
        private System.Windows.Forms.Label lmy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
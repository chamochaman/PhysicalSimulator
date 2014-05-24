using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhysicalSimulator
{
    public partial class Reportes : Form
    {
        public List<Dictionary<float, List<float>>> History;
        public List<string> series;
        public List<string> titles;
        public List<string> labels;
        public int i;

        public Reportes(List<Dictionary<float, List<float>>> history)
        {
            series = new List<string>() { "Velocidad X", "Velocidad Y", "Aceleracion X", "Aceleracion Y" };
            titles = new List<string>() { "Velocidad vs Tiempo", "Aceleración vs Tiempo" };
            labels = new List<string>() { "Velocidad X Media:", "Velocidad X Máxima:",
            "Velocidad X Mínima:", "Velocidad Y Media:", "Velocidad Y Máxima:", "Velocidad Y Mínima:",
            "Aceleración X Media:", "Aceleración X Máxima:",
            "Aceleración X Mínima:", "Aceleración Y Media:", "Aceleración Y Máxima:", "Aceleración Y Mínima:"};

            i = 0;
            this.History = history;
            InitializeComponent();
            showReport();
        }

        private void showReport()
        {
            c1.Series.Clear();
            c1.Titles.Clear();
            c1.Series.Add(series[i * 2]);
            c1.Series.Add(series[i * 2 + 1]);
            c1.Titles.Add(titles[i]);

            var serie = History[i + 1];
            int t = 0;
            foreach (var item in serie)
            {
                c1.Series[0].Points.AddXY(shortDecimal(item.Key), item.Value[0]);
                c1.Series[1].Points.AddXY(shortDecimal(item.Key), item.Value[1]);
                t++;
            }

            label1.Text = labels[i * 3 + 0];
            label2.Text = labels[i * 3 + 1];
            label3.Text = labels[i * 3 + 2];
            label9.Text = labels[i * 3 + 3];
            label8.Text = labels[i * 3 + 4];
            label7.Text = labels[i * 3 + 5];


            if (serie.Count > 0)
            {
                lmax.Text = serie.Values.Last()[0].ToString();
                lmin.Text = serie[0][0].ToString();
                lmedia.Text = (serie.Values.Last()[0] / 2).ToString();
                lmaxy.Text = serie.Values.Last()[1].ToString();
                lminy.Text = serie[0][1].ToString();
                lmy.Text = (serie.Values.Last()[1] / 2).ToString();
            }
            else
            {
                lmax.Text = (0).ToString();
                lmin.Text = (0).ToString();
                lmedia.Text = (0).ToString();
                lmaxy.Text = (0).ToString();
                lminy.Text = (0).ToString();
                lmy.Text = (0).ToString();
            }
        }

        private double shortDecimal(float number)
        {
            string snumber = number.ToString();
            /*var splited = snumber.Split('.');
            string finalnumber = splited[0];
            if(splited.Length == 2)
                finalnumber += splited[1][0] + splited[1][1];*/
            return double.Parse(snumber);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = (i + 1) % 2;
            showReport();
        }
    }
}

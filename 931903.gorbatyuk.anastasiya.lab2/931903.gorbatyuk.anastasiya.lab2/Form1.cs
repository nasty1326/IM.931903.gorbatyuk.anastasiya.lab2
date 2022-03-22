using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _931903.gorbatyuk.anastasiya.lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        const double k = 0.1;
        Random random = new Random();
        double rateDollar, rateEuro;
        int days;
        bool swit = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            rateEuro = rateEuro * (1 + k * (random.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(days, rateEuro);

            rateDollar = rateDollar * (1 + k * (random.NextDouble() - 0.5));
            chart1.Series[1].Points.AddXY(days, rateDollar);
        }

        private void btPredict_Click(object sender, EventArgs e)
        {
            if (swit)
            {
                timer1.Stop();
            }
            else
            {
                rateEuro = (double)edRateE.Value;
                rateDollar = (double)edRateD.Value;
                days = (int)chart1.ChartAreas[0].AxisX.Minimum;


                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(0, rateEuro);

                chart1.Series[1].Points.Clear();
                chart1.Series[1].Points.AddXY(0, rateDollar);

                timer1.Start();
            }
            swit = !swit;
        }

    
    }
}

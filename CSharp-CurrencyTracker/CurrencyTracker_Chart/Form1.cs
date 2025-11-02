using System;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DovizTakipChartApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Series.Clear();
        }

        private async void btnGetRates_Click(object sender, EventArgs e)
        {
            string url = "https://api.exchangerate.host/latest?base=TRY";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync(url);
                    var data = JsonDocument.Parse(response);
                    var rates = data.RootElement.GetProperty("rates");

                    double usd = 1 / rates.GetProperty("USD").GetDouble();
                    double eur = 1 / rates.GetProperty("EUR").GetDouble();
                    double gbp = 1 / rates.GetProperty("GBP").GetDouble();

                    chart1.Series.Clear();
                    Series series = new Series("Döviz Kurları");
                    series.ChartType = SeriesChartType.Column;
                    series.Points.AddXY("USD", usd);
                    series.Points.AddXY("EUR", eur);
                    series.Points.AddXY("GBP", gbp);

                    chart1.Series.Add(series);

                    lblInfo.Text = $"Son Güncelleme: {DateTime.Now:dd.MM.yyyy HH:mm}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri alınamadı: {ex.Message}");
                }
            }
        }
    }
}
using System;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

namespace DovizTakipApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

                    lblUSD.Text = $"USD: {1 / rates.GetProperty("USD").GetDouble():0.00} TL";
                    lblEUR.Text = $"EUR: {1 / rates.GetProperty("EUR").GetDouble():0.00} TL";
                    lblGBP.Text = $"GBP: {1 / rates.GetProperty("GBP").GetDouble():0.00} TL";
                    lblDate.Text = $"Son Güncelleme: {DateTime.Now:dd.MM.yyyy HH:mm}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veri alınamadı: {ex.Message}");
                }
            }
        }
    }
}
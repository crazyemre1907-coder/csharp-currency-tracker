using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== DÖVİZ TAKİP UYGULAMASI ===");
        Console.WriteLine("USD, EUR, GBP kurlarını görmek için bir tuşa basın...");
        Console.ReadKey();

        await GetExchangeRates();
    }

    static async Task GetExchangeRates()
    {
        string url = "https://api.exchangerate.host/latest?base=TRY";
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                var data = JsonDocument.Parse(json);
                var rates = data.RootElement.GetProperty("rates");

                Console.WriteLine("\n=== GÜNCEL KURLAR ===");
                Console.WriteLine($"USD: {1 / rates.GetProperty("USD").GetDouble():0.00} TL");
                Console.WriteLine($"EUR: {1 / rates.GetProperty("EUR").GetDouble():0.00} TL");
                Console.WriteLine($"GBP: {1 / rates.GetProperty("GBP").GetDouble():0.00} TL");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
        }
    }
}
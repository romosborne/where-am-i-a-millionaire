using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using where_am_i_a_millionaire.Models;

namespace where_am_i_a_millionaire.Services
{
    public class ExchangeService : IExchangeService
    {

        private bool isLoaded = false;

        // Rates are in relation to EUR
        private Dictionary<string, double> rates;

        public ExchangeService()
        {

        }

        private async Task GetData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.exchangeratesapi.io/latest");
            var retObj = JsonConvert.DeserializeObject<ExchangeResponse>(await response.Content.ReadAsStringAsync());
            rates = retObj.Rates;

            isLoaded = true;
        }

        public async Task<List<Something>> GetEquivalents(double amount, string currency)
        {
            if (!isLoaded) await GetData();

            // Convert amount to euros
            if (!string.Equals(currency, "EUR")){
                amount = amount / rates[currency];
            }

            // Get all the other currencies
            return rates.Select(kvp => new Something(){
                Currency = kvp.Key,
                Amount = amount * kvp.Value
            }).Append(new Something() {
                Currency = "EUR",
                Amount = amount
            }).ToList();
        }
    }
}
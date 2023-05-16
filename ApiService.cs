using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Crypt
{
    public class ApiService
    {
        private class ApiResponse
        {
            [JsonProperty("data")]
            [JsonConverter(typeof(CryptoCurrencyConverter))]
            public object Data { get; set; }
        }

        private class CryptoCurrencyConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(CryptoCurrency);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    // Deserialize as a list of CryptoCurrency objects
                    return serializer.Deserialize<List<CryptoCurrency>>(reader);
                }
                else
                {
                    // Deserialize as a single CryptoCurrency object
                    return serializer.Deserialize<CryptoCurrency>(reader);
                }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }


        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<CryptoCurrency>> GetTopCurrencies()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.coincap.io/v2/assets");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var stringData = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(stringData);
            if (apiResponse?.Data is List<CryptoCurrency> currencies)
                return currencies;
            else if (apiResponse?.Data is CryptoCurrency singleCurrency)
                return new List<CryptoCurrency> { singleCurrency };
            else
                return null;
        }

        public static async Task<CryptoCurrency> GetCurrencyById(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.coincap.io/v2/assets/" + id);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var stringData = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(stringData);
            if (apiResponse?.Data is List<CryptoCurrency> currencies && currencies.Count > 0)
                return currencies[0];
            else if (apiResponse?.Data is CryptoCurrency singleCurrency)
                return singleCurrency;
            else
                return null;
        }
    }
}

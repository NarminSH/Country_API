using System.Data;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

HttpClient client = new();
List<Country> countries = new List<Country>();

var phoneResponse = client.GetAsync("http://country.io/phone.json").Result;
var nameResponse = client.GetAsync("http://country.io/names.json").Result;
var isoResponse = client.GetAsync("http://country.io/iso3.json").Result;
var continentResponse = client.GetAsync("http://country.io/continent.json").Result;
var currencyResponse = client.GetAsync("http://country.io/currency.json").Result;
var capitalResponse = client.GetAsync("http://country.io/capital.json").Result;

var jsonResponse1 = phoneResponse.Content.ReadAsStringAsync().Result;
var jsonResponse2 = nameResponse.Content.ReadAsStringAsync().Result;
var jsonResponse3 = isoResponse.Content.ReadAsStringAsync().Result;
var jsonResponse4 = continentResponse.Content.ReadAsStringAsync().Result;
var jsonResponse5 = currencyResponse.Content.ReadAsStringAsync().Result;
var jsonResponse6 = capitalResponse.Content.ReadAsStringAsync().Result;

var phone = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse1);
var name = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse2);
var iso = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse3);
var continent = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse4);
var currency = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse5);
var capital = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse6);

Console.WriteLine();
for (int i = 0; i < phone.Count; i++)
{

    var obj = new Country
    {
        Name = name.Values.ToList()[i],
        Continent = iso.Values.ToList()[i],
        Currency = continent.Values.ToList()[i],
        ISO = currency.Values.ToList()[i],
        Capital = capital.Values.ToList()[i],
        Phone = phone.Values.ToList()[i],
        Code = phone.Keys.ToList()[i]
    };
    countries.Add(obj);
}



foreach (var item in countries)
{
    Console.WriteLine($"Phone: {item.Phone}");
    Console.WriteLine($"Name: {item.Name}");
    Console.WriteLine($"Continent: {item.Continent}");
    Console.WriteLine($"ISO: {item.ISO}");
    Console.WriteLine($"Capital: {item.Capital}");
    Console.WriteLine($"Code: {item.Code}");
    Console.WriteLine($"Currency: {item.Currency}");
    Console.WriteLine("_____________________________________");
}



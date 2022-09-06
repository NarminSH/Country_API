using System.Data;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using HttpClient client = new();

await GetData(client);

static async Task GetData(HttpClient client)
{
    List<Country> countries = new List<Country>();
    using HttpResponseMessage phoneResponse = await client.GetAsync("http://country.io/phone.json");
    using HttpResponseMessage nameResponse = await client.GetAsync("http://country.io/names.json");
    using HttpResponseMessage isoResponse = await client.GetAsync("http://country.io/iso3.json");
    using HttpResponseMessage continentResponse = await client.GetAsync("http://country.io/continent.json");
    using HttpResponseMessage currencyResponse = await client.GetAsync("http://country.io/currency.json");
    using HttpResponseMessage capitalResponse = await client.GetAsync("http://country.io/capital.json");

    phoneResponse.EnsureSuccessStatusCode();
    nameResponse.EnsureSuccessStatusCode();
    isoResponse.EnsureSuccessStatusCode();
    continentResponse.EnsureSuccessStatusCode();
    currencyResponse.EnsureSuccessStatusCode();
    capitalResponse.EnsureSuccessStatusCode();

    var jsonResponse1 = phoneResponse.Content.ReadAsStringAsync().Result;
    var jsonResponse2 = nameResponse.Content.ReadAsStringAsync().Result;
    var jsonResponse3 = isoResponse.Content.ReadAsStringAsync().Result;
    var jsonResponse4 = continentResponse.Content.ReadAsStringAsync().Result;
    var jsonResponse5 = currencyResponse.Content.ReadAsStringAsync().Result;
    var jsonResponse6 = capitalResponse.Content.ReadAsStringAsync().Result;

    var phone = JObject.Parse(jsonResponse1);
    var name = JsonConvert.DeserializeObject(jsonResponse2);
    var iso = JsonConvert.DeserializeObject(jsonResponse3);
    var continent = JsonConvert.DeserializeObject(jsonResponse4);
    var currency = JsonConvert.DeserializeObject(jsonResponse5);
    var capital = JsonConvert.DeserializeObject(jsonResponse6);


    for (int i = 0; i < phone.Count; i++)
    {
        var obj = new Country
        {
            Phone = new List<DataPair>(),
            Name = new List<DataPair>(),
            Continent = new List<DataPair>(),
            Currency = new List<DataPair>(),
            ISO = new List<DataPair>()
        };

        foreach (var item in phone)
        {
            obj.Phone.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
            obj.ISO.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
            obj.Name.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
            obj.Currency.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
            obj.Continent.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
        }
        countries.Add(obj);

    }
    foreach (var item in countries)
    {
        Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", item.Phone, item.ISO, item.Capital, item.Currency, item.Continent, item.Name);
    }

}

/*
var rawObj = JObject.Parse(phoneResponse);
Console.WriteLine(rawObj);


var obj2 = new Country
{
    Phone = new List<DataPair>()
};
foreach (var item in rawObj)
{
    obj2.Phone.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
}

//    var obj = JsonConvert.DeserializeObject<SomeData>(json);
//    Console.WriteLine($"{phoneResponse}\n");
//    Console.WriteLine(phoneResponse);
*/
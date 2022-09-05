using System.Data;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using HttpClient phone = new()
{
    BaseAddress = new Uri("http://country.io/phone.json"),
};

await GetData(phone);



static async Task GetData(HttpClient client)
{
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

    var jsonResponse1 = await phoneResponse.Content.ReadAsStringAsync();

    List<string> nameList = jsonResponse1.Split(',').ToList();

    var jsonResponse2 = await nameResponse.Content.ReadAsStringAsync();
    List<string> nameList2 = jsonResponse2.Split(',').ToList();
    

    var jsonResponse3 = await isoResponse.Content.ReadAsStringAsync();
    List<string> nameList3 = jsonResponse3.Split(',').ToList();

    var jsonResponse4 = await continentResponse.Content.ReadAsStringAsync();
    List<string> nameList4 = jsonResponse4.Split(',').ToList();

    var jsonResponse5 = await currencyResponse.Content.ReadAsStringAsync();
    List<string> nameList5 = jsonResponse5.Split(',').ToList();

    var jsonResponse6 = await capitalResponse.Content.ReadAsStringAsync();
    List<string> nameList6 = jsonResponse6.Split(',').ToList();
    var new1 = nameList.Zip(nameList2);
    var new2 = new1.Zip(nameList3);
    var new3 = new2.Zip(nameList4);
    var new4 = new3.Zip(nameList5);

    foreach (var item in new4)
    {
        Console.WriteLine(item);
    }


    //for (int i = 0; i < new4.Count(); i++)
    //{
    //    var obj = new Country
    //    {
    //        Phone = new List<DataPair>(),
    //        Name = new List<DataPair>(),
    //        Continent = new List<DataPair>(),
    //        Currency = new List<DataPair>(),
    //        ISO = new List<DataPair>()
    //    };

    //    foreach (var item in new4)
    //    {
    //        obj.Phone.Add(new DataPair() { Value = item.First });
    //        obj.ISO.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
    //        obj.Name.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
    //        obj.Currency.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
    //        obj.Continent.Add(new DataPair() { Key = item.Key, Value = item.Value.ToString() });
    //    }
    //    objects.Add(obj);
    //    foreach (var item in objects)
    //    {
    //        foreach (var pair in item.Phone)
    //        {
    //            Console.WriteLine($"Name={pair.Value}");
    //        }
    //        foreach (var pair in item.Name)
    //        {
    //            Console.WriteLine($"Name={pair.Value}");
    //        }

    //    }
    //}

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
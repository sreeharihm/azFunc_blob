// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;

Console.WriteLine("Hello, World!");

var client = new HttpClient();
var response = await client.GetAsync("http://api.weatherapi.com/v1/history.json?key=8fe4ec4be85641bdae871017242507&q=Stockholm&dt=2024-08-01");
string responseBody = await response.Content.ReadAsStringAsync();
Console.WriteLine(responseBody);


using DataLoader.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

IConfiguration iconfiguration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var servicesConfig = iconfiguration.GetSection("Services");

var authenticationServicesConfig =  servicesConfig.GetSection("Authentication");
var authenticationServicesHost = authenticationServicesConfig["Host"];
var authenticationServicesPort = authenticationServicesConfig["Port"];

var vehicleServicesConfig = servicesConfig.GetSection("Vehicle");
var vehicleServicesHost = vehicleServicesConfig["Host"];
var vehicleServicesPort = vehicleServicesConfig["Port"];

var quotaServicesConfig = servicesConfig.GetSection("Quota");
var quotaServicesHost = quotaServicesConfig["Host"];
var quotaServicesPort = quotaServicesConfig["Port"];

var authenticationHTTPClient = new HttpClient();
authenticationHTTPClient.BaseAddress = new Uri($"http://{authenticationServicesHost}:{authenticationServicesPort}");

var vehicleHTTPClient = new HttpClient();
vehicleHTTPClient.BaseAddress = new Uri($"http://{vehicleServicesHost}:{vehicleServicesPort}");

var quotaHTTPClient = new HttpClient();
quotaHTTPClient.BaseAddress = new Uri($"http://{quotaServicesHost}:{quotaServicesPort}");

postAuthentication("tewyb23", "2022-09-22","Nimal", authenticationHTTPClient);
postQuota("tewyb23", 12, 10, quotaHTTPClient);
postVehicle("tewyb23", "2022-09-22", "er56", vehicleHTTPClient);

void postAuthentication(string vehicleRegistrationNumber,string registeredDate,string Name,HttpClient httpClient)
{
    var rand = new Random();
    AuthenticationModel authenticationModel;
    authenticationModel = new AuthenticationModel
    {
        vehicleRegistrationNumber= vehicleRegistrationNumber,
        registeredDate= registeredDate,
        Name= Name
    };

    var res = httpClient.PostAsJsonAsync("authentication", authenticationModel).Result;
}

void postQuota(string vehicleRegistrationNumber, double maxQuota, double remainingQuota, HttpClient httpClient)
{
    var rand = new Random();
    QuotaModel quotaModel;
    quotaModel = new QuotaModel
    {
        vehicleRegistrationNumber = vehicleRegistrationNumber,
        maxQuota = maxQuota,
        remainingQuota = remainingQuota
    };
    var res = httpClient.PostAsJsonAsync("quota", quotaModel).Result;

}

void postVehicle(string vehicleRegistrationNumber, string registeredDate, string chassisNumber, HttpClient httpClient)
{
    var rand = new Random();
    VehicleModel vehicleModel;
    vehicleModel = new VehicleModel
    {
        vehicleRegistrationNumber = vehicleRegistrationNumber,
        registeredDate = registeredDate,
        chassisNumber = chassisNumber
    };
    var res = httpClient.PostAsJsonAsync("vehicles", vehicleModel).Result;

}
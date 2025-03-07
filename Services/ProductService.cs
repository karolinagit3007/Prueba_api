using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using EjemploMVC_MAT.Models;

namespace EjemploMVC_MAT.Services;

public class CardService
{
    private readonly HttpClient _httpClient;

    public CardService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CardModel>> GetBlueEyesCardsAsync()
    {
        string apiUrl = "https://db.ygoprodeck.com/api/v7/cardinfo.php?archetype=Blue-Eyes";
        var response = await _httpClient.GetStringAsync(apiUrl);
        var jsonResponse = JsonConvert.DeserializeObject<ApiResponse>(response);
        
        return jsonResponse?.Data ?? new List<CardModel>();
    }

    public async Task<CardModel> GetCardByIdAsync(int id)
    {
        string apiUrl = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?id={id}";
        var response = await _httpClient.GetStringAsync(apiUrl);
        var jsonResponse = JsonConvert.DeserializeObject<ApiResponse>(response);

        return jsonResponse?.Data?.FirstOrDefault();
    }
}

public class ApiResponse
{
    public List<CardModel> Data { get; set; }
}

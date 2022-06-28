﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TestClient
{
    public interface IWeatherForecastClient
    {
        Task<IEnumerable<WeatherForecast>> GetAsync();
    }

    public class WeatherForecastClient : IWeatherForecastClient
    {
        private readonly HttpClient _client;

        public WeatherForecastClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<WeatherForecast>>("/weatherforecast");
        }
    }
}
// SPDX-License-Identifier: MIT
// Copyright ©2021 Marc King

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace LogicSeed.LostHarbor.Pages
{
  public class FetchDataBase : ComponentBase
  {
    [Inject] protected HttpClient Http { get; set; }

    protected WeatherForecast[] Forecasts { get; private set; }

    protected override async Task OnInitializedAsync()
    {
      Forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }

    public class WeatherForecast
    {
      public DateTime Date { get; set; }

      public int TemperatureC { get; set; }

      public string Summary { get; set; }

      public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
  }
}

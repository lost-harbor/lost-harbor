// SPDX-License-Identifier: MIT
// Copyright ©2021 Marc King

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LogicSeed.LostHarbor.Core;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LogicSeed.LostHarbor
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var test = new Class1();
      test.Test();

      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp => new HttpClient
      {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
      });

      await builder.Build().RunAsync();
    }
  }
}

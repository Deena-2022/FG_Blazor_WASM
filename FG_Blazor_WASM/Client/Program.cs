using FG_Blazor_WASM.Client.services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace FG_Blazor_WASM.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzI5NTQxQDMyMzAyZTMzMmUzMEsva2ZvVC9WZXdrT3h4ZXdHRGduWWtWZzhway9RUE1BZXFtTFhhM2V5RzA9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);            
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddScoped<ILeadRepository,LeadRepository>();

            builder.Services.AddSingleton<JsonSerializerOptions>(new JsonSerializerOptions()
            {
                AllowTrailingCommas = true,
             
            });
            await builder.Build().RunAsync();
        }

    }
}

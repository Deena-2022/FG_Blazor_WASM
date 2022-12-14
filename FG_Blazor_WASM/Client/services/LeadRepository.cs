using FG_Blazor_WASM.Client.Pagination;
using FG_Blazor_WASM.Shared.Model;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Client.services
{
    public class LeadRepository : ILeadRepository
    {
        private readonly HttpClient _client;

        public LeadRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<PagingResponse<Leads>> GetProducts(ProductParameters productParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = productParameters.PageNumber.ToString()
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("api/Leads", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            JsonSerializerOptions optionsCopy = new(options);
            var pagingResponse = new PagingResponse<Leads>
            {
                Items = JsonSerializer.Deserialize<List<Leads>>(content, options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), options)
            };
            return pagingResponse;
        }
    }
}

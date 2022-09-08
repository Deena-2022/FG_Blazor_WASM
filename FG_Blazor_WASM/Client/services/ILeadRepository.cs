using FG_Blazor_WASM.Client.Pagination;
using FG_Blazor_WASM.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Client.services
{
    interface ILeadRepository
    {
        Task<PagingResponse<Leads>> GetProducts(ProductParameters productParameters);
    }
}

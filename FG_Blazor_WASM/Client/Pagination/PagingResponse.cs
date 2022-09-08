using FG_Blazor_WASM.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Client.Pagination
{
    public class PagingResponse<T> where T : class
    {
    
        public List<T> Items { get; set; }
        public MetaData MetaData { get; set; }
    }
}
    
using FG_Blazor_WASM.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Server.Services

{
   public interface ILeadServices
{
        Task<PagedList<Leads>> GetProducts(ProductParameters productParameters);
        public void Update(Leads user);

        public Leads GetById(int id);

        public void Delete(int id);
    }
}

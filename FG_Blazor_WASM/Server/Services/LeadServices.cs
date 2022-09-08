
using FG_Blazor_WASM.Server.Context;
using FG_Blazor_WASM.Server.Services;
using FG_Blazor_WASM.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Server.Services
{
    public class LeadServices : ILeadServices
    {
        private readonly FGDbContext _context;

        public LeadServices(FGDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Leads user = _context.Lead.Find(id);

            if (user != null)
            {
                _context.Lead.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

       

        public Leads GetById(int id)
        {
            Leads user = _context.Lead.Find(id);

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<PagedList<Leads>> GetProducts(ProductParameters productParameters)
        {
            var products = await _context.Lead.ToListAsync();
            return PagedList<Leads>
                .ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
        }

        public void Update(Leads user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}

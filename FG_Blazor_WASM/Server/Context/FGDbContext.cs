
using FG_Blazor_WASM.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Server.Context
{
    public class FGDbContext:DbContext
{
        public FGDbContext()
        {

        }
        public FGDbContext(DbContextOptions<FGDbContext>options):base(options)
        {

        }
        public DbSet<Leads> Lead { get; set; }
        public DbSet<User> tbl_User { get; set; }

    }
}

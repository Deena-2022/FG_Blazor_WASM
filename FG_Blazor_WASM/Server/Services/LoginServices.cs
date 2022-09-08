using FG_Blazor_WASM.Server.Context;
using FG_Blazor_WASM.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Server.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly FGDbContext context;

        public LoginServices(FGDbContext context)
        {
            this.context = context;
        }
        public IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression)
        {
            return this.context.tbl_User.Where(expression);
        }
    }
}

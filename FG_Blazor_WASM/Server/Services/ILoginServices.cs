using FG_Blazor_WASM.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FG_Blazor_WASM.Server.Services
{
    public interface ILoginServices
    {
        IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression);
    }
}

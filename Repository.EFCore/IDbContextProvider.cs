using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EFCore
{
    public interface IDbContextProvider<out TDbContext>
     where TDbContext : DbContext
    {
        TDbContext GetDbContext();

    }
}

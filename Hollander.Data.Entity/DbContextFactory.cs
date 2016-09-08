using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hollander.Data.Entity
{
    public class DbContextFactory : IDbContextFactory
    {
        public TDbContext Create<TDbContext>()
            where TDbContext : System.Data.Entity.DbContext, new()
        {
            return new TDbContext();
        }

        public TDbContext Create<TDbContext>(DbConnection connection, bool contextOwnsConnection, Func<DbConnection, bool, TDbContext> creator)
            where TDbContext : System.Data.Entity.DbContext
        {
            return creator(connection, contextOwnsConnection);
        }
    }
}
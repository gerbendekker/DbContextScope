using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hollander.Data.Entity
{
    public partial interface IDbContextFactory
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TDbContext">The type of the database context.</typeparam>
        /// <returns></returns>
        TDbContext Create<TDbContext>()
            where TDbContext : DbContext, new();

        /// <summary>
        /// </summary>
        /// <typeparam name="TDbContext">The type of the database context.</typeparam>
        /// <param name="connection"></param>
        /// <param name="contextOwnsConnection">if set to <c>true</c> [context owns connection].</param>
        /// <param name="creator"></param>
        /// <returns></returns>
        TDbContext Create<TDbContext>(DbConnection connection, bool contextOwnsConnection, Func<DbConnection, bool, TDbContext> creator)
            where TDbContext : System.Data.Entity.DbContext;
    }
}
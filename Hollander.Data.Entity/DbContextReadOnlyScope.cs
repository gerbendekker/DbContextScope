/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Data;

namespace Mehdime.Entity
{
    public class DbContextReadOnlyScope : IDbContextReadOnlyScope
    {
        private DbContextScope _internalScope;

        public IDbContextCollection DbContexts { get { return _internalScope.DbContexts; } }

        public DbContextReadOnlyScope(IAmbientDbContextFactory dbContextFactory = null)
            : this(joiningOption: DbContextScopeOption.JoinExisting, isolationLevel: null, dbContextFactory: dbContextFactory)
        {}

        public DbContextReadOnlyScope(IsolationLevel isolationLevel, IAmbientDbContextFactory dbContextFactory = null)
            : this(joiningOption: DbContextScopeOption.ForceCreateNew, isolationLevel: isolationLevel, dbContextFactory: dbContextFactory)
        { }

        public DbContextReadOnlyScope(DbContextScopeOption joiningOption, IsolationLevel? isolationLevel, IAmbientDbContextFactory dbContextFactory = null)
        {
            _internalScope = new DbContextScope(joiningOption: joiningOption, readOnly: true, isolationLevel: isolationLevel, dbContextFactory: dbContextFactory);
        }

        public void Dispose()
        {
            _internalScope.Dispose();
        }
    }
}
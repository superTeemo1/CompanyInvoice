using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyInovicesEF
{
    public class DbContextFactory
    {
        private static volatile DbContextFactory _dbContextFactory;
        private static readonly object SyncRoot = new Object();
        public DbContext Context;
        public static DbContextFactory Instance
        {
            get
            {
                if (_dbContextFactory == null)
                {
                    lock (SyncRoot)
                    {
                        if (_dbContextFactory == null)
                        {
                            _dbContextFactory = new DbContextFactory();
                        }
                    }
                }
                return _dbContextFactory;
            }
        }
        public DbContext GetOrCreateContext()
        {
            if (this.Context == null)
            {
                this.Context = new DbContext(ConfigurationManager.AppSettings["DefaultConnectionString"]);
            }
            return this.Context;
        }
    }
}

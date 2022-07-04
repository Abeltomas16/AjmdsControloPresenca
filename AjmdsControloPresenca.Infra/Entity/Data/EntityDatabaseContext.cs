using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjmdsControloPresenca.Infra.Entity.Data
{
    public class EntityDatabaseContext:DbContext
    {
        public EntityDatabaseContext():base("ConnectionStringSQL")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    }
}

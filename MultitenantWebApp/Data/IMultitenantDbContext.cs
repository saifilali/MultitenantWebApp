using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.Data
{
    public interface IMultitenantDbContext
    {
        public int TenantId { get; }
    }
}

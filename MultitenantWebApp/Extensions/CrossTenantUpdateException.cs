using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.Extensions
{
    public class CrossTenantUpdateException : ApplicationException
    {
        public IList<int> TenantIds { get; private set; }

        public CrossTenantUpdateException(IList<int> tenantIds)
        {
            TenantIds = tenantIds;
        }
    }
}

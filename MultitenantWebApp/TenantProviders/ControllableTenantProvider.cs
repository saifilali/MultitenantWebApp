using MultitenantWebApp.Extensions;
using MultitenantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.TenantProviders
{
    public class ControllableTenantProvider : ITenantProvider
    {
        public Tenant Tenant { get; set; }

        public Tenant GetTenant()
        {
            return Tenant;
        }
    }
}

using MultitenantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.Extensions
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
        Tenant[] ListTenants();
    }
}

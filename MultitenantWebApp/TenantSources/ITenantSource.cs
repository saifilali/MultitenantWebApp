using MultitenantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.Services
{
    public interface ITenantSource
    {
        Tenant[] ListTenants();
    }
}

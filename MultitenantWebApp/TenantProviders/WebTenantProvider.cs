using Microsoft.AspNetCore.Http;
using MultitenantWebApp.Extensions;
using MultitenantWebApp.Models;
using MultitenantWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.TenantProviders
{
    public class WebTenantProvider : ITenantProvider
    {
        private readonly ITenantSource _tenantSource;
        private readonly string _host;

        public WebTenantProvider(ITenantSource tenantSource, IHttpContextAccessor accessor)
        {
            _tenantSource = tenantSource;
            _host = accessor.HttpContext.Request.Host.ToString();
        }

        public Tenant GetTenant()
        {
            var tenants = _tenantSource.ListTenants();

            return tenants
                    .Where(t => t.Host.ToLower() == _host.ToLower())
                    .FirstOrDefault();
        }
    }
}

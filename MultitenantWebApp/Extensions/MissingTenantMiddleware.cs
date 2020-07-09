using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.Extensions
{
    public class MissingTenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _missingTenantUrl;

        public MissingTenantMiddleware(RequestDelegate next, string missingTenantUrl)
        {
            _next = next;
            _missingTenantUrl = missingTenantUrl;
        }

        public async Task Invoke(HttpContext httpContext, ITenantProvider provider)
        {
            if(provider.GetTenant() == null)
            {
                httpContext.Response.Redirect(_missingTenantUrl);
                return;
            }

            await _next.Invoke(httpContext);
        }
    }
}

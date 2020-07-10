using MultitenantWebApp.Models;
using MultitenantWebApp.Services;
using Newtonsoft.Json;
using System.IO;

namespace MultitenantWebApp.TenantSources
{
    public class FileTenantSource : ITenantSource
    {
        public Tenant[] ListTenants()
        {
            var tenants = File.ReadAllText("tenants.json");

            return JsonConvert.DeserializeObject<Tenant[]>(tenants);
        }
    }
}
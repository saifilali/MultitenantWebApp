using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MultitenantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantWebApp.Data
{
    public class DynamicModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            var castedContext = context as IMultitenantDbContext;
            if (castedContext == null)
            {
                throw new Exception("Unknown DBContext type");
            }

            return new { castedContext.TenantId };
        }
    }
}
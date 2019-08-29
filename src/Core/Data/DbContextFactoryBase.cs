using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Krola.Core.Data
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        public TContext Create()
        {
            var optionsBuilder = DbContextOptionsBuilderFactory<TContext>.Create();

            return CreateNewInstance(optionsBuilder.Options);
        }

        public TContext CreateDbContext(string[] args)
        {
            return Create();
        }
    }
}



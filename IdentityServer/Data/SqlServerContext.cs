using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
    public class SqlServerContext : IdentityUserContext<IdentityUser<Guid>, Guid>
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }
    }
}
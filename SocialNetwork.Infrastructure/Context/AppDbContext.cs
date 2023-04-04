using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SocialNetwork.Domain.Entites;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace SocialNetwork.Infrastructure.Context;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Profile> Profiles { get; set; }


    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=MIRANDA\\SQLEXPRESS;Database=BancoDados_RedeSocial;TrustServerCertificate=True;MultipleActiveResultSets=True;Trusted_Connection=True");
            //optionsBuilder.UseSqlServer("Server=tcp:dbinfnetazure.database.windows.net,1433;Initial Catalog=DbSocialNetworkInfnet;Persist Security Info=False;User ID=AdminServer;Password=S3nh@infnet;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
    

}

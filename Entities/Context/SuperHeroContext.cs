using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Entities.Models;

namespace SuperHeroApi.Entities.Context;

public class SuperHeroContext: IdentityDbContext 
{
    public SuperHeroContext(DbContextOptions<SuperHeroContext> options): base(options)
    {
        
    }

    public DbSet<SuperHero> SuperHero { get; set; }
}
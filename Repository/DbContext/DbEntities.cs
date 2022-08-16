using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Plantsist.AppProGateway.Repository.Repositories.DbContext;

public class DbEntities : Microsoft.EntityFrameworkCore.DbContext
{
    public DbEntities(DbContextOptions<DbEntities> options) : base(options)
    {

    }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Area> Areas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
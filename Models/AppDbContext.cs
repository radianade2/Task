using Microsoft.EntityFrameworkCore;

namespace PlanningWebAgit.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<RencanaModel> RencanaModel { get; set; }
}
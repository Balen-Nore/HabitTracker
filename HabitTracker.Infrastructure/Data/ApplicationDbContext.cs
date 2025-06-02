using HabitTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Habit> Habits => Set<Habit>();
        public DbSet<HabitLog> HabitLogs => Set<HabitLog>();
    }
}

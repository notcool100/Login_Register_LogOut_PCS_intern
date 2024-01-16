using Microsoft.EntityFrameworkCore;
using login.Models;

namespace login.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
		}
		public DbSet<User>Users { get; set; }
	}
}

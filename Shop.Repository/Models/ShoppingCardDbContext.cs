using Microsoft.EntityFrameworkCore;

namespace Shop.DataModels.Models;

public partial class ShoppingCardDbContext : DbContext
{
	public ShoppingCardDbContext()
	{
	}

	public ShoppingCardDbContext(DbContextOptions<ShoppingCardDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<AdminInfo> AdminInfos { get; set; }

	public virtual DbSet<Category> Categories { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			//optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=ShoppingCardDb; User Id=sa; Password=123456aA@; Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AdminInfo>(entity =>
		{
			entity.ToTable("AdminInfo");

			entity.Property(e => e.CreatedOn).HasMaxLength(25);
			entity.Property(e => e.Email).HasMaxLength(30);
			entity.Property(e => e.LastLogin).HasMaxLength(25);
			entity.Property(e => e.Name).HasMaxLength(100);
			entity.Property(e => e.Password).HasMaxLength(6);
			entity.Property(e => e.UpdatedOn).HasMaxLength(20);
		});

		modelBuilder.Entity<Category>(entity =>
		{
			entity.ToTable("Category");

			entity.Property(e => e.Name).HasMaxLength(100);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
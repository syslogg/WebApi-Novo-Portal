using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class DbTIContext : DbContext
    {
        public DbTIContext(DbContextOptions<DbTIContext> options) 
            : base (options)
        { }
        /*public DbSet<Post> Post { get; set; }
        public DbSet<Author> Author { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ForSqlServerUseIdentityColumns();

			ConfigurePost(modelBuilder);
			ConfigureAuthor(modelBuilder);
			ConfigureComment(modelBuilder);
			ConfigureSideBar(modelBuilder);
			ConfigureCategory(modelBuilder);
		}

        private void ConfigurePost(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(model => {
                model.HasKey(x => x.Id);

                model.Property(x => x.Body);
                model.Property(x => x.Subtitle);
                model.Property(x => x.Title);
				model.Property(x => x.ImageUrl);

                /*model.HasMany(x => x.Comments)
                    .WithOne()
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Cascade);*/

                model.HasOne(x => x.Author)
                    .WithMany()
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

				model.HasOne<Category>()
					.WithMany(x => x.Posts)
					.HasForeignKey(x => x.CategoryId)
					.IsRequired(false)
					.OnDelete(DeleteBehavior.SetNull);
					
            });
        }

		private void ConfigureCategory (ModelBuilder modelBuider)
		{
			modelBuider.Entity<Category>(model => {
				model.HasKey(x => x.Id);

				model.Property(x => x.Name);
				model.Property(x => x.Description);

				model.HasMany(x => x.Posts)
					.WithOne()
					.HasForeignKey(x => x.CategoryId)
					.IsRequired(false)
					.OnDelete(DeleteBehavior.SetNull);

			});
		}
        private void ConfigureAuthor(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>(model => {

                model.HasKey(x => x.Id);

				model.Property(x => x.LevelAccess);
				model.Property(x => x.Password);
				model.Property(x => x.Photo);
				model.Property(x => x.FullName);
				model.Property(x => x.Biography);
				model.Property(x => x.Email);

				model.HasMany<Post>()
					.WithOne(x => x.Author)
					.HasForeignKey(x => x.AuthorId);

            });

        }
		private void ConfigureComment(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Comment>(model => {

				model.HasKey(x => x.Id);

				model.Property(x => x.Body);
				model.Property(x => x.Email);
				model.Property(x => x.FullName);

			});
		}
		private void ConfigureSideBar(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<SidebarFeature>(model => {

				model.HasKey(x => x.Id);

				model.Property(x => x.Title);
				model.Property(x => x.Body);

			});

		}
    }
}

using Microsoft.EntityFrameworkCore;
using SampleZoo.Domain.Entities.Animal;
using SampleZoo.Domain.Entities.User;

namespace SampleZoo.DataLayer.Context
{
    public class SampleZooDbContext : DbContext
    {
        public SampleZooDbContext(DbContextOptions<SampleZooDbContext> options) : base(options)
        {

        }

        #region User

        public DbSet<User> Users { get; set; }

        #endregion

        #region animal

        public DbSet<Animal> Animals { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Cascade

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            #endregion

            #region Seed Data

            #region User

            modelBuilder.Entity<User>().HasData(new User("itsShaab", "+989026150241", "shahab0060")
            {
                Id = 1,
            });

            #endregion

            #region animal

            modelBuilder.Entity<Animal>().HasData(new Animal("Brad the Dog", 3)
            {
                Id = 1,
            });

            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }


}
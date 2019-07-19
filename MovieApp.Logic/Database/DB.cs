namespace MovieApp.Logic.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=MovieDB")
        {
        }

        public virtual DbSet<Cinemas> Cinemas { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinemas>()
                .HasMany(e => e.Movies)
                .WithRequired(e => e.Cinemas)
                .HasForeignKey(e => e.CinemaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movies>()
                .HasOptional(e => e.Sessions)
                .WithRequired(e => e.Movies);
        }
    }
}

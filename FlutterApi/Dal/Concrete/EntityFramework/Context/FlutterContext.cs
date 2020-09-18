namespace Dal.Concrete.EntityFramework.Context
{
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public  class FlutterContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true).UseSqlServer(@"Data Source=hasansahin.net\MSSQLSERVER2016;Initial Catalog=hasansa1_flutter;Integrated Security=False;User ID=hasansa1_flutter;Password=hasan123*;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); 
            //optionsBuilder.UseLazyLoadingProxies(true).UseSqlServer("server=.;database=FlutterStore;trusted_connection=true;"); 
        }
        public FlutterContext()
        {
        }
        public FlutterContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<OfferDetail> OfferDetail { get; set; }
        public virtual DbSet<SellDetail> SellDetail { get; set; }
        public virtual DbSet<Stars> Stars { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<UserFavorites> UserFavorites { get; set; }
        public virtual DbSet<UserFavoritesCategories> UserFavoritesCategories { get; set; }
        public virtual DbSet<Users> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
               .HasOne(p => p.Categories)
               .WithMany(b => b.Books).HasForeignKey(x => x.categoryId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OfferDetail>()
             .HasOne(p => p.SellDetail)
             .WithMany(b => b.OfferDetail).HasForeignKey(x => x.SellDetalId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OfferDetail>()
             .HasOne(p => p.Users)
             .WithMany(b => b.OfferDetail).HasForeignKey(x => x.userId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SellDetail>()
          .HasOne(p => p.Users)
          .WithMany(b => b.SellDetail).HasForeignKey(x => x.userId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comments>()
            .HasOne(p => p.Users)
            .WithMany(b => b.Comments).HasForeignKey(x => x.usersId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comments>()
           .HasOne(p => p.Books)
           .WithMany(b => b.Comments).HasForeignKey(x => x.booksId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Stars>()
            .HasOne(p => p.Users)
            .WithMany(b => b.UserStars).HasForeignKey(x => x.userId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Stars>()
           .HasOne(p => p.Books)
           .WithMany(b => b.UserStars).HasForeignKey(x => x.bookId).OnDelete(DeleteBehavior.NoAction);


        }



    }
}

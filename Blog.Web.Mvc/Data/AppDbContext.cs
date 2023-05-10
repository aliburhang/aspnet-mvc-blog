using System;
using System.Collections.Generic;
using Blog.Web.Mvc.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Blog.Web.Mvc.Data
{
    public class AppDbContext : DbContext
    {
        // 1. Tablo Konfigrasyonu
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPost> CategoryPosts { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> Users { get; set; }


        //  2. Veritabanı Konfigrasyonu
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    //string connectionString = "Server=(localdb)\\MSSQLLocalDb; Database=AspNetMvcBlog;";
        //    string connectionString = "Server=localhost,1433; Database=AspNetMvcBlog; User Id=sa; Password=SiliconMade123..; TrustServerCertificate=True;";
        //    builder.UseSqlServer(connectionString);
        //    base.OnConfiguring(builder);
        //}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed: Örnek test verilerinin eklenmesi
            DbSeeder.SeedTestData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}


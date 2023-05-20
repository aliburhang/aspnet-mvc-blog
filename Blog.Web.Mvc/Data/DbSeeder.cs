using System;
using System.Reflection.Emit;
using Blog.Web.Mvc.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Mvc.Data
{
    public class DbSeeder
    {
        public static void SeedTestData(ModelBuilder modelBuilder)
        {
            SeedCategories(modelBuilder);
            SeedCategoryPosts(modelBuilder);
            SeedPages(modelBuilder);
            SeedPosts(modelBuilder);
            SeedPostComments(modelBuilder);
            SeedPostImages(modelBuilder);
            SeedSettings(modelBuilder);
            SeedUsers(modelBuilder);
        }

        public static void SeedCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new List<Category>
            {
                new() { Id = 1, Name = "Elektronik", Slug="Elektronik"},
                new() { Id = 2, Name = "Kitap", Slug="Kitap"},
                new() { Id = 3, Name = "Giyim", Slug="Giyim"},
            });
        }

        public static void SeedCategoryPosts(ModelBuilder modelBuilder)
        {
            var categoryPosts = new List<CategoryPost>();
            for (int i = 1; i <= 20; i++)
            {
                categoryPosts.Add(new CategoryPost
                {
                    Id = i,
                    CategoryId = Random.Shared.Next(1, 3),
                    PostId = Random.Shared.Next(1, 20),
                });
            }
            modelBuilder.Entity<CategoryPost>().HasData(categoryPosts);
        }

        public static void SeedPages(ModelBuilder modelBuilder)
        {
            var pages = new List<Page>();
            for (int i = 1; i <= 100; i++)
            {
                pages.Add(new Page
                {
                    Id = i,
                    Title = "Title " + i,
                    Content = "Content " + i,
                    IsActive = true,
                });
            }
            modelBuilder.Entity<Page>().HasData(pages);
        }

        public static void SeedPosts(ModelBuilder modelBuilder)
        {
            var posts = new List<Post>();
            for (int i = 1; i <= 20; i++)
            {
                posts.Add(new Post
                {
                    Id = i,
                    UserId = Random.Shared.Next(1, 8),
                    Title = "Post Title " + i,
                    Content = "Post content " + i,
                    CategoryId = Random.Shared.Next(1, 4),
                });
            }
            modelBuilder.Entity<Post>().HasData(posts);
        }

        public static void SeedPostComments(ModelBuilder modelBuilder)
        {
            var postComments = new List<PostComment>();
            for (int i = 1; i <= 100; i++)
            {
                postComments.Add(new PostComment
                {
                    Id = i,
                    PostId = Random.Shared.Next(1, 20),
                    UserId = Random.Shared.Next(1,8),
                    Comment = "Comment " + i,
                    IsActive = true,
                });
            }
            modelBuilder.Entity<PostComment>().HasData(postComments);
        }

        public static void SeedPostImages(ModelBuilder modelBuilder)
        {
            var postImages = new List<PostImage>();
            for (int i = 1; i <= 100; i++)
            {
                postImages.Add(new PostImage
                {
                    Id = i,
                    PostId = Random.Shared.Next(1, 20),
                    ImagePath = "Link " ,
                });
            }
            modelBuilder.Entity<PostImage>().HasData(postImages);
        }

        public static void SeedSettings(ModelBuilder modelBuilder)
        {
            var settings = new List<Setting>();
            for (int i = 1; i <= 10; i++)
            {
                settings.Add(new Setting
                {
                    Id = i,
                    UserId = Random.Shared.Next(1, 8),
                    Name = "Name " + i,
                    Value = "Value " + i,
                });
            }
            modelBuilder.Entity<Setting>().HasData(settings);
        }

        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new() { Id = 1, Email = "guncan@gmail.com", Password = "guncan", Name = "Ali Burhan Güncan", City = "Mersin", Phone = "+905000000000", Definition="My name is Ali Burhan Güncan, i am from Mersin"},
                new() { Id = 2, Email = "kılıc@gmail.com", Password = "kılıc", Name = "Murat Esat Kılıç", City = "Ankara", Phone = "+905000000000", Definition="My name is Murat Esat Kılıç, i am from Ankara"},
                new() { Id = 3, Email = "aras@gmail.com", Password = "aras", Name = "Ümit Can Aras", City = "Ankara", Phone = "+905000000000", Definition="My name is Ümit Can Aras, i am from Ankara"},
                new() { Id = 4, Email = "gencer@gmail.com", Password = "gencer", Name = "Kerem Gencer", City = "İstanbul", Phone = "+905000000000", Definition="My name is Kerem Gencer, i am from İstanbul"},
                new() { Id = 5, Email = "coskun@gmail.com", Password = "coskun", Name = "Onur Eymen Coşkun", City = "İstanbul", Phone = "+905000000000", Definition="My name is Onur Eymen Coşkun, i am from İstanbul"},
                new() { Id = 6, Email = "gunduzoglu@gmail.com", Password = "gunduzoglu", Name = "Cem Gündüzoğlu", City = "İstanbul", Phone = "+905000000000", Definition="My name is Cem Gündüzoğlu, i am from İstanbul"},
                new() { Id = 7, Email = "yilmaz@gmail.com", Password = "yilmaz", Name = "Muhammet Yılmaz", City = "İstanbul", Phone = "+905000000000", Definition="My name is Muhammet Yılmaz, i am from İstanbul"},
            });
        }


    }
}


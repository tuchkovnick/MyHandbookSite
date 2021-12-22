using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyHandbookSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { set; get; }
        public DbSet<ItemType> ItemTypes { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var firstTypeGuid = Guid.NewGuid();
            modelBuilder.Entity<ItemType>().HasData(new ItemType
            {
                Id = firstTypeGuid,
                Title = "Первый тип"
            });

            var secondTypeGuid = Guid.NewGuid();
            modelBuilder.Entity<ItemType>().HasData(new ItemType
            {
                Id = secondTypeGuid,
                Title = "Второй тип"
            });

            var thirdTypeGuid = Guid.NewGuid();
            modelBuilder.Entity<ItemType>().HasData(new ItemType
            {
                Id = thirdTypeGuid,
                Title = "Третий тип"
            });


            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.NewGuid(),
                Title = "Первый элемент",
                TypeId = firstTypeGuid,
                ImageSource = "1.jpg",
                Description = "Описание 1"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.NewGuid(),
                Title = "Второй элемент",
                TypeId = firstTypeGuid,
                ImageSource = "2.jpg",
                Description = "Описание 2"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.NewGuid(),
                Title = "Третий элемент",
                TypeId = secondTypeGuid,
                ImageSource = "3.jpg",
                Description = "Описание 3"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.NewGuid(),
                Title = "Четвертый элемент",
                TypeId = secondTypeGuid,
                ImageSource = "4.jpg",
                Description = "Описание 4"
            });
            
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.NewGuid(),
                Title = "Пятый элемент",
                TypeId = thirdTypeGuid,
                ImageSource = "5.jpg",
                Description = "Описание 5"
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = Guid.NewGuid(),
                Title = "Шестой элемент",
                TypeId = thirdTypeGuid,
                ImageSource = "6.jpg",
                Description = "Описание 6"
            });

            var adminRoleGuid = Guid.NewGuid();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleGuid.ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var adminUserGuid = Guid.NewGuid();
            modelBuilder.Entity<MyHandbookSiteUser>().HasData(new MyHandbookSiteUser
            {
                Id = adminUserGuid.ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty,
                Image = "admin.png"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleGuid.ToString(),
                UserId = adminUserGuid.ToString()
            });

        }

    }
}

using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;

namespace Data
{
    public class GameContext:DbContext
    {
        public GameContext(DbContextOptions<GameContext> options): base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<GameCategory> GamesCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Game doom = new Game { Id = 1, Name = "Doom", Author = "Id Software", Categories = new List<Category>() };
            //Game whitcher = new Game { Id = 2, Name = "Whitcher", Author = "CD Project Red", Categories = new List<Category>() };
            Category shooter = new Category { Id = 1, Name = "Shooter", Games = new List<Game>() };
            //Category rpg = new Category { Id = 2, Name = "RPG", Games = new List<Game>() };

            modelBuilder.Entity<Game>().HasData(
                new Game[]
                {
                    doom
                });
            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                    shooter
                });

            modelBuilder
                .Entity<Game>()
                .HasMany(g => g.Categories)
                .WithMany(c => c.Games)
                .UsingEntity(j => j.ToTable("GamesCategories")
                .HasData(new { GamesId = 1, CategoriesId = 1 })); 

            //modelBuilder
            //    .Entity<Game>()
            //    .HasData(
            //        new Game { Id = 1, Name = "Doom", Author = "Bethesda" },
            //        new Game { Id = 2, Name = "Whitcher", Author = "CD Project Red" }
            //        );
            //modelBuilder
            //    .Entity<Category>()
            //    .HasData(
            //        new Category { Id = 1, Name = "Shooter" },
            //        new Category { Id = 2, Name = "RPG" }
            //        );
            //modelBuilder
            //    .Entity<Game>()
            //    .HasMany(g => g.Categories)
            //    .WithMany(c => c.Games)
            //    .UsingEntity(j => j.HasData(
            //            new { GamesId = 1, CategoriesId = 1 },
            //            new { GamesId = 2, CategoriesId = 2 }
            //            ));

            //modelBuilder.Entity<GameCategory>()
            //    .HasKey(bc => new { bc.GameId, bc.CategoryId });
            //modelBuilder.Entity<GameCategory>()
            //    .HasOne(bc => bc.Game)
            //    .WithMany(b => b.GameCategories)
            //    .HasForeignKey(bc => bc.GameId);
            //modelBuilder.Entity<GameCategory>()
            //    .HasOne(bc => bc.Category)
            //    .WithMany(c => c.GameCategories)
            //    .HasForeignKey(bc => bc.CategoryId);
            //modelBuilder
            //    .Entity<Game>()
            //    .HasData(
            //        new Game { Name = "Doom", Author = "Bethesda" },
            //        new Game { Name = "Whitcher", Author = "CD Project Red" }
            //        );
            //modelBuilder
            //    .Entity<Category>()
            //    .HasData(
            //        new Category { Name = "Shooter" },
            //        new Category { Name = "RPG" }
            //        );
            //modelBuilder
            //    .Entity<GameCategory>()
            //    .HasData(
            //        new GameCategory { GameId = 1, CategoryId = 1 },
            //        new GameCategory { GameId = 2, CategoryId = 2 }
            //        );

            
        }

    }
}

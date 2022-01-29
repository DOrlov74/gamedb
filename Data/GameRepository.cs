using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(GameContext context) : base(context) {}

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var games = await Context.Games
                .Include(g => g.Categories)
                .ToListAsync();
            return games;
        }

        public async Task<Game> AddAsync(Game entity)
        {
            Game game = await FindByNameAsync(entity.Name);
            if (game == null)
            {
                game = entity;
                game = await CheckForCategoriesAsync(game);
                Context.Games.Add(game);
                await Context.SaveChangesAsync(); 
            }
            return game;
        }

        public async Task DeleteAsync(Game entity)
        {
            Context.Games.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<Game> FindByIdAsync(int id)
        {
            var game = await Context.Games.Where(e => e.Id == id)
                .Include(g => g.Categories)
                .FirstOrDefaultAsync();
            return game;
        }

        public async Task<Game> FindByNameAsync(string name)
        {
            var game = await Context.Games.Where(e => e.Name == name)
                .Include(g => g.Categories)
                .FirstOrDefaultAsync();
            return game;
        }

        public async Task UpdateAsync(Game game)
        {
            game = await CheckForCategoriesAsync(game);
            Context.Games.Update(game);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> FindByCategoryIdAsync(int id)
        {
            var games = await Context.Games
                .Where(p => p.Categories.Any(c => c.Id == id))
                .Include(g => g.Categories)
                .ToListAsync();
            return games;
        }

        public async Task<IEnumerable<Game>> FindByCategoryNameAsync(string name)
        {
            var games = await Context.Games
                .Where(p => p.Categories.Any(c => c.Name == name))
                .Include(g => g.Categories)
                .ToListAsync();
            return games;
        }

        public async Task<Game> AddCategoryForGameAsync(int id, Category category)
        {
            var game = await FindByIdAsync(id);
            var findedCategory = await Context.Categories.FirstOrDefaultAsync(e => e.Name == category.Name);
            if (findedCategory != null)
            {
                category = findedCategory;
            }
            game.Categories.Add(category);
            Context.Games.Update(game);
            await Context.SaveChangesAsync();
            return game;
        }
        public async Task<Game> CheckForCategoriesAsync(Game game)
        {
            if (game.Categories != null)
            {
                var categories = new HashSet<Category>();
                foreach (Category cat in game.Categories)
                {
                    var findedCategory = await Context.Categories.FirstOrDefaultAsync(e => e.Name == cat.Name);
                    if (findedCategory != null)
                    {
                        categories.Add(findedCategory);
                    }else
                    {
                        categories.Add(cat);
                    }
                }
                game.Categories = categories;
            }
            return game;
        }
    }
}

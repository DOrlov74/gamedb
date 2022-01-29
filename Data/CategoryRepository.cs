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
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public CategoryRepository(GameContext context) : base(context ) { }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await Context.Categories.ToListAsync();
        }

        public async Task<Category> AddAsync(Category entity)
        {
            Category category = await FindByNameAsync(entity.Name);
            if (category == null)
            {
                Context.Categories.Add(entity);
                await Context.SaveChangesAsync();
                category = entity;
            }
            return category;
        }

        public async Task DeleteAsync(Category entity)
        {
            Context.Categories.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await Context.Categories.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Category> FindByNameAsync(string name)
        {
            return await Context.Categories.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task UpdateAsync(Category entity)
        {
            Context.Categories.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}

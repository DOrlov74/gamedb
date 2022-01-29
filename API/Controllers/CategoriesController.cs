using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CategoriesController : BaseCategoryController
    {
        public CategoriesController(IRepository<Category> repo, IMapper mapper) : base(repo, mapper) { }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> ListAsync()
        {
            var categories = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await _repo.FindByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDTO> (category));
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CategoryDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = await _repo.AddAsync(_mapper.Map<Category>(value));
            var createdCategory = _mapper.Map<CategoryDTO>(category);
            return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.Id }, createdCategory);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] CategoryDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = await _repo.FindByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            await _repo.UpdateAsync(_mapper.Map<Category>(value));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var category = await _repo.FindByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            await _repo.DeleteAsync(category);
            return NoContent();
        }
    }
}

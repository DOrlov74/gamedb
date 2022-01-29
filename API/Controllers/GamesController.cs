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
    public class GamesController : BaseGameController
    {
        public GamesController(IGameRepository repo, IMapper mapper):base(repo, mapper) {}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTO>>> ListAsync()
        {
            var games = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GameDTO>> (games));
        }

        [HttpGet("{id}", Name ="GetGame")]
        public async Task<ActionResult<GameDTO>> GetGame(int id)
        {
            var game = await _repo.FindByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GameDTO>(game));
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetByCategoryAsync(int id)
        {
            var games = await _repo.FindByCategoryIdAsync(id);
            if (games == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<GameDTO>>(games));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] GameDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var game = await _repo.AddAsync(_mapper.Map<Game>(value));
            var createdGame = _mapper.Map<GameDTO>(game);
            return CreatedAtAction(nameof(GetGame), new { id=createdGame.Id }, createdGame);  
        }

        [HttpPost("{id}/category")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> CreateCategoryForGameAsync(int id, [FromBody] CategoryDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var game = await _repo.FindByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            game = await _repo.AddCategoryForGameAsync(id, _mapper.Map<Category>(value));
            return Ok(_mapper.Map<IEnumerable<GameDTO>>(game));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] GameDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var game = await _repo.FindByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            await _repo.UpdateAsync(_mapper.Map<Game>(value));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var game = await _repo.FindByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            await _repo.DeleteAsync(game);
            return NoContent();
        }
    }
}

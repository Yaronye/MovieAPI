using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models.DTOs;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly MovieContext _context;

        public ActorsController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorDto>>> Index()
        {
            IEnumerable<ActorDto> dtos = await _context.Actors.Select(a => new ActorDto
            (
                a.Id,
                a.Name,
                a.BirthYear))
            .ToListAsync();

            return Ok(dtos);
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDto>> GetActors(int id)
        {
            var actorDto = await _context.Actors
            .Where(a => a.Id == id)
            .Select(a => new ActorDto(a.Id,
                a.Name,
                a.BirthYear))
            .FirstOrDefaultAsync();

            return actorDto;
        }

        // POST: Actors/Create
        [HttpPost("create/{id}")]
        public async Task<ActionResult<Actor>> PostActor(int id, ActorCreateDto actorCreateDto)
        {
            var actor = new Actor
            {
                Id = actorCreateDto.Id,
                Name = actorCreateDto.Name,
                BirthYear = actorCreateDto.BirthYear,
            };
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostActor", new { id = actor.Id }, actor);
        }

        // POST: Actors/actorid/movies/movieid/
        [HttpPost("{actorid}/movies/{movieid}")]
        public async Task<ActionResult<Actor>> PostMovieActor(int actorId, int movieId)
        {
            var movieActor = new MovieActor
            {
                MovieId = movieId,
                ActorId = actorId,
            };
            _context.MovieActors.Add(movieActor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostMovieActor", new { actorId = movieActor.ActorId, movieId = movieActor.MovieId }, movieActor);
        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthYear")] Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}

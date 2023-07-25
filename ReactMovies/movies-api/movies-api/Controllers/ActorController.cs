using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies_api.DTOs;
using movies_api.Entities;
using movies_api.Helpers;
using System.Collections;

namespace movies_api.Controllers
{
    [Route("api/actors")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class ActorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private readonly string containerName = "actors";

        public ActorController(ApplicationDbContext context, IMapper mapper, IFileStorageService fileStorageService)
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = _context.Actors.AsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(queryable);

            var actors = await queryable.OrderBy(x => x.Name).Paginate(paginationDTO).ToListAsync();
            return _mapper.Map<List<ActorDTO>>(actors);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDTO>> GetActor(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actor == null)
            {
                return NotFound();
            }
            return _mapper.Map<ActorDTO>(actor);
        }
        [HttpGet("searchByName/{query}")]
        public async Task<ActionResult<List<ActorsMovieDTO>>> SearchByName(string query)
        {
            if(string.IsNullOrWhiteSpace(query)) { return new List<ActorsMovieDTO>(); }
            return await _context.Actors
                .Where(x => x.Name.Contains(query))
                .OrderBy(x => x.Name)
                .Select(x => new ActorsMovieDTO { Id = x.Id, Name = x.Name, Picture = x.Picture })
                .Take(5)
                .ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreationDTO actorCreationDTO)
        {
            var actor = _mapper.Map<Actor>(actorCreationDTO);
            if (actorCreationDTO.Picture != null)
            {
                actor.Picture = await _fileStorageService.SaveFile(containerName, actorCreationDTO.Picture);
            }
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,[FromForm] ActorCreationDTO actorCreationDTO)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actor == null)
            {
                return NotFound();
            }
            actor=_mapper.Map(actorCreationDTO,actor); //update
            if (actorCreationDTO.Picture != null)
            {
                
              actor.Picture=  await _fileStorageService.EditFile(containerName, actorCreationDTO.Picture,actor.Picture);
            }
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actor == null)
            {
                return NotFound();
            }
            _context.Actors.Remove(actor);
            await _fileStorageService.DeleteFile(actor.Picture, containerName);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

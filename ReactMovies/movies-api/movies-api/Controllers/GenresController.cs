using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using movies_api.DTOs;
using movies_api.Entities;
using movies_api.Filters;
using movies_api.Helpers;

namespace movies_api.Controllers
{
    [Route("api/genres")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> _loggger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _loggger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        //[ResponseCache(Duration =60)]
        //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        // [ServiceFilter(typeof(MyActionFilter))] //custom facut de mine

        public async Task<ActionResult<List<GenreDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            // _loggger.LogInformation("getting all the genres");

            var queryable = _context.Genres.AsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(queryable);


            var genres = await queryable.OrderBy(x => x.Name).Paginate(paginationDTO).ToListAsync();


            return _mapper.Map<List<GenreDTO>>(genres);

        }
        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GenreDTO>>> GetAll( )
        {
            var genres =await _context.Genres.OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<GenreDTO>>(genres);

        }



        [HttpGet("{id:int}", Name = "getGenre")]
        public async Task<ActionResult<GenreDTO>> GetGenre(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
            return _mapper.Map<GenreDTO>(genre);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = _mapper.Map<Genre>(genreCreationDTO);
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
            genre = _mapper.Map(genreCreationDTO, genre);  //update 
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
          //  _context.Genres.Remove(new Genre() { Id = id });
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}

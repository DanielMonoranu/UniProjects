﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies_api.DTOs;
using movies_api.Entities;
using movies_api.Helpers;
using System.Reflection.Metadata.Ecma335;

namespace movies_api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme,Policy ="IsAdmin")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private readonly UserManager<IdentityUser> _userManager;
        private string container = "movies";

        public MoviesController(ApplicationDbContext context, IMapper mapper, IFileStorageService fileStorageService,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
           _userManager = userManager;
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var movie = await _context.Movies
                .Include(x => x.MoviesGenres).ThenInclude(x => x.Genre)   //bringing information of other tables
                .Include(x => x.MoviesTheatersMovies).ThenInclude(x => x.MovieTheater)
                .Include(x => x.MoviesActors).ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) { return NotFound(); }

            var averageVote = 0.0;
            var userVote = 0;
            if(await _context.Ratings.AnyAsync(x => x.MovieId == id))
            {
                averageVote = await _context.Ratings.Where(x => x.MovieId == id)
                    .AverageAsync(x => x.Rate);

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
                    var user = await _userManager.FindByEmailAsync(email);
                    var userId = user.Id;

                    var ratingDb = await _context.Ratings.FirstOrDefaultAsync(x => x.MovieId == id && x.UserId == userId);
                    if(ratingDb != null) //the user voted for this already
                    {
                        userVote = ratingDb.Rate;
                    }
                    
                }
            }

            var dto = _mapper.Map<MovieDTO>(movie);
            dto.AverageVote = averageVote;
            dto.UserVote = userVote;
            dto.Actors = dto.Actors.OrderBy(x => x.Order).ToList();
            return dto;
        }



        [HttpGet]
        [AllowAnonymous]

        public async Task<ActionResult<LandingPageDTO>> Get()
        {
            var top = 6;
            var today = DateTime.Today;
            var upcomingReleases = await _context.Movies
                .Where(x => x.ReleaseDate > today)
                .OrderBy(x => x.ReleaseDate).Take(top).ToListAsync();

            var inTheaters = await _context.Movies.Where(x => x.InTheaters)
                .OrderBy(x => x.ReleaseDate).Take(top).ToListAsync();
            var landingPageDTO = new LandingPageDTO();
            landingPageDTO.UpcomingReleases = _mapper.Map<List<MovieDTO>>(upcomingReleases);
            landingPageDTO.InTheaters = _mapper.Map<List<MovieDTO>>(inTheaters);
            return landingPageDTO;
        }

        [HttpGet("putget/{id:int}")]
        public async Task<ActionResult<MoviePutGetDTO>> PutGet(int id)  //pt a actualiza film
        {
            var movieActionResult = await Get(id);
            if (movieActionResult.Result is NotFoundResult) { return NotFound(); }
            var movie = movieActionResult.Value;

            var genresSelectedIds = movie.Genres.Select(x => x.Id).ToList();
            var nonSelectedGenres = await _context.Genres.Where(x => !genresSelectedIds.Contains(x.Id))
                .ToListAsync();
            var nonSelectedGenresDTO = _mapper.Map<List<GenreDTO>>(nonSelectedGenres);


            var movieTheatersId = movie.MoviesTheaters.Select(x => x.Id).ToList();
            var nonSelectedMovieTheaters = await _context.MovieTheaters.Where(x => !movieTheatersId.Contains(x.Id))
                .ToListAsync();
            var nonSelectedMovieTheatersDTO = _mapper.Map<List<MovieTheaterDTO>>(nonSelectedMovieTheaters);

            var response = new MoviePutGetDTO()
            {
                Movie = movie,
                SelectedGenres = movie.Genres,
                NonSelectedGenres = nonSelectedGenresDTO,
                SelectedMovieTheaters = movie.MoviesTheaters,
                NonSelectedMovieTheaters = nonSelectedMovieTheatersDTO,
                Actors = movie.Actors,
            };
            return response;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] MovieCreationDTO movieCreationDTO)
        {
            var movie = await _context.Movies.Include(x => x.MoviesActors)
                .Include(x => x.MoviesGenres).Include(x => x.MoviesTheatersMovies)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) { return NotFound(); }
            movie = _mapper.Map(movieCreationDTO, movie);
            if (movieCreationDTO.Poster != null)
            {
                movie.Poster = await _fileStorageService.EditFile(container, movieCreationDTO.Poster, movie.Poster);
            }
            AnnotateActorsOrder(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("PostGet")]
        public async Task<ActionResult<MoviePostGetDTO>> PostGet() //for getting movietheaters and genres
        {
            var movieTheaters = await _context.MovieTheaters.ToListAsync();
            var genres = await _context.Genres.ToListAsync();
            var movieTheatersDTO = _mapper.Map<List<MovieTheaterDTO>>(movieTheaters);
            var genresDTO = _mapper.Map<List<GenreDTO>>(genres);
            return new MoviePostGetDTO()
            {
                Genres = genresDTO,
                MovieTheaters = movieTheatersDTO,
            };
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] MovieCreationDTO movieCreationDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreationDTO);
            if (movieCreationDTO.Poster != null)
            {
                movie.Poster = await _fileStorageService.SaveFile(container, movieCreationDTO.Poster);
            }
            AnnotateActorsOrder(movie);
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return movie.Id;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Remove(movie);
            await _context.SaveChangesAsync();
            await _fileStorageService.DeleteFile(movie.Poster, container);
            return NoContent();
        }


        //for filter movies:
        [HttpGet("filter")]
        [AllowAnonymous]
        public async Task<ActionResult<List<MovieDTO>>> Filter([FromQuery] FilterMoviesDTO filterMoviesDTO)
        {
            var moviesQueryable = _context.Movies.AsQueryable();
            if (!string.IsNullOrEmpty(filterMoviesDTO.Title))
            {
                moviesQueryable = moviesQueryable.Where(x => x.Title.Contains(filterMoviesDTO.Title));
            }


            if (filterMoviesDTO.InTheaters)
            {
                moviesQueryable = moviesQueryable.Where(x => x.InTheaters);
            }

            if (filterMoviesDTO.UpcomingReleases)
            {
                var today = DateTime.Today;
                moviesQueryable = moviesQueryable.Where(x => x.ReleaseDate > today);
            }
            if (filterMoviesDTO.GenreId != 0)
            {
                //query by a relationship:
                moviesQueryable = moviesQueryable
                    .Where(x => x.MoviesGenres.Select(y => y.GenreId)
                    .Contains(filterMoviesDTO.GenreId));
            }
            await HttpContext.InsertParametersPaginationInHeader(moviesQueryable);
            var movies = await moviesQueryable.OrderBy(x => x.Title).Paginate(filterMoviesDTO.PaginationDTO)
                .ToListAsync();
            return _mapper.Map<List<MovieDTO>>(movies);
        }


        private void AnnotateActorsOrder(Movie movie)
        {
            if (movie.MoviesActors != null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i;
                }
            }
        }
    }
}

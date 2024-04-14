using EntertainmentApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentApp.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovies()
    {
        var movies = await _movieService.GetPopularMoviesAsync();

        return Ok(movies);
    }
    
    [HttpGet("search/{query}")]
    public async Task<IActionResult> SearchMovie(string query)
    {
        var movies = await _movieService.SearchMovieByTitle(query);

        return Ok(movies);
    }
}

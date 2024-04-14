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
}

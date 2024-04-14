using EntertainmentApp.Models.MoviesAPI;

namespace EntertainmentApp.Services;

public class MovieService
{
    private readonly HttpClient _httpClient;

    public MovieService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("movies-client");
    }

    public async Task<ApiComumResponse<Movie>> GetPopularMoviesAsync(string language = "pt-BR")
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"movie/popular?language={language}&page=1");

        var response = await _httpClient.SendAsync(requestMessage);

        if(!response.IsSuccessStatusCode)
        {
            // TODO: implementar results
            throw new Exception("Erro ao consultar filmes populares");
        }

        var movies = await HttpContentJsonExtensions.ReadFromJsonAsync<ApiComumResponse<Movie>>(response.Content);

        return movies!;
    }

    public async Task<ApiComumResponse<Movie>> SearchMovieByTitle(string title, string language = "pt-BR", bool includeAdult = false)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"search/movie?query={title}&include_adult={includeAdult}&language={language}&page=1");

        var response = await _httpClient.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
        {
            // TODO: implementar results
            throw new Exception("Erro ao consultar filmes populares");
        }

        var movies = await HttpContentJsonExtensions.ReadFromJsonAsync<ApiComumResponse<Movie>>(response.Content);

        return movies!;
    }
}

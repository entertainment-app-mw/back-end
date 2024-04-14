namespace EntertainmentApp.Models.MoviesAPI;

public class ApiComumResponse<TResponse>
{
    public int Page { get; set; }

    public IEnumerable<TResponse> Results { get; set; } = Enumerable.Empty<TResponse>();
}

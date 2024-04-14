using System.Text.Json.Serialization;

namespace EntertainmentApp.Models.MoviesAPI;

public class Movie
{
    public int Id { get; set; }

    public bool Adult { get; set; }

    public bool Video { get; set; }

    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }

    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("backdrop_path")]
    public string BackdropPath { get; set; } = string.Empty;

    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; } = string.Empty;

    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; set; } = string.Empty;

    public string Overview { get; set; } = string.Empty;

    public double Popularity { get; set; }

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; } = string.Empty;

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; } = string.Empty;

    [JsonPropertyName("genre_ids")]
    public IEnumerable<int> GenreIds { get; set; } = Enumerable.Empty<int>();
}

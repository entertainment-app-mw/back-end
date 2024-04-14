using EntertainmentApp.Services;
using System.Net.Http.Headers;

namespace EntertainmentApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHttpClient("movies-client", (config) =>
        {
            var apiSection = builder.Configuration.GetRequiredSection("MovieDbApi");

            var apiBaseUrl = apiSection.GetValue<string>("BaseUrl") ?? throw new Exception("Erro ao obter MovieDbApi:BaseUrl");
            var apiReadToken = apiSection.GetValue<string>("ReadToken") ?? throw new Exception("Erro ao obter MovieDbApi:ReadToken");

            config.BaseAddress = new Uri(apiBaseUrl);
            config.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiReadToken);
        });

        builder.Services.AddTransient<MovieService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

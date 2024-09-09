

using ani_server.Dto;
using ani_server.Interfaces;
using ani_server.Models;

namespace ani_server.GraphQl
{
    public class AnimeMutationResolver
    {
        public record AddAnimePayload(AnimeRequestDto anime);
        private readonly IAnime _animeservice;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _hostEnviroment;
        readonly string posterFolderPath = string.Empty;

        public AnimeMutationResolver(IAnime animeservice,IConfiguration config,IWebHostEnvironment hostEnvironment)
        {
            _animeservice = animeservice;
            _config = config;
            _hostEnviroment = hostEnvironment;
            posterFolderPath = System.IO.Path.Combine(_hostEnviroment.WebRootPath, "Poster");
        }
        [GraphQLDescription("Add anime data")]
        public AddAnimePayload AddAnime(AnimeRequestDto anime)
        {
            if(!string.IsNullOrEmpty(anime.PosterPath))
            {
                anime.PosterPath = WriteImageToServer(anime);
            }
            else
            {
                anime.PosterPath = _config["DefaultPoster"];    
            }
            _animeservice.AddAnime(anime); 
            return new AddAnimePayload(anime);
        }
        string WriteImageToServer(AnimeRequestDto anime)
        {
            string fileName = Guid.NewGuid() +".jpg";
            string fullPath = System.IO.Path.Combine(posterFolderPath,fileName);
            byte[] imageBytes = Convert.FromBase64String(anime.PosterPath);
            File.WriteAllBytes(fullPath,imageBytes);

            return fileName;
        }
    }
}
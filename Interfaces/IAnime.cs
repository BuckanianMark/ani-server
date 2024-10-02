

using ani_server.Dto;
using ani_server.Models;

namespace ani_server.Interfaces
{
    public interface IAnime
    {
        Task AddAnime(AnimeRequestDto anime);
        Task<List<Genre>> GetGenre();
        Task<List<Anime>> GetAllAnimes();
        Task<List<Anime>> GetSimilarAnimes(int animeId);
    }
}
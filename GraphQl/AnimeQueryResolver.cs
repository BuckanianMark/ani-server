using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ani_server.Interfaces;
using ani_server.Models;

namespace ani_server.GraphQl
{
    public class AnimeQueryResolver
    {
        private readonly IAnime _animeService;

        public AnimeQueryResolver(IAnime animeservice)
        {
            _animeService = animeservice;
        }
        [GraphQLDescription("Get The List of genres")]
        public async Task<List<Genre>> GetGenreList()
        {
            return await _animeService.GetGenre();
        }
        [GraphQLDescription("Get the list of Movies")]
        [UseFiltering]
        public async Task<IQueryable<Anime>> GetAnimeList()
        {
            List<Anime> availableAnimes = await _animeService.GetAllAnimes();
            return availableAnimes.AsQueryable();
        }
    }
}
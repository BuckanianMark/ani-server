

using ani_server.DataBaseContext;
using ani_server.Dto;
using ani_server.Interfaces;
using ani_server.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ani_server.DataAccess
{
    public class AnimeDataAccessLayer : IAnime
    {
        private AniSaveDbContext _dbContext;
        private readonly IMapper _mapper;

        public AnimeDataAccessLayer(IDbContextFactory<AniSaveDbContext> dbContext,IMapper mapper)
        {
            _dbContext = dbContext.CreateDbContext();
            _mapper = mapper;
        }

        public async Task AddAnime(AnimeRequestDto anime)
        {
           try
           {
            var animeToAdd = _mapper.Map<Anime>(anime);
            await _dbContext.Animes.AddAsync(animeToAdd);
            await _dbContext.SaveChangesAsync();
           }
           catch (System.Exception)
           {
            
            throw;
           }
        }

        public async Task<List<Genre>> GetGenre()
        {
           try
            {
                return await _dbContext.Genres.ToListAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task<List<Anime>> GetAllAnimes()
        {
           
                return await _dbContext.Animes.Include(a => a.Characters).AsNoTracking().ToListAsync();
          
        }
    }
}
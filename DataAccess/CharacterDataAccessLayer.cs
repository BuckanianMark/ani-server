using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ani_server.DataBaseContext;
using ani_server.Dto;
using ani_server.Interfaces;
using ani_server.Models;
using Microsoft.EntityFrameworkCore;

namespace ani_server.DataAccess
{
    public class CharacterDataAccessLayer : ICharacter
    {
        private readonly AniSaveDbContext _dbContext;

        public CharacterDataAccessLayer(IDbContextFactory<AniSaveDbContext> dbContext)
        {
            _dbContext =  dbContext.CreateDbContext();
        }
        public async Task AddCharacter(CharacterRequestDto characterRequestDto)
        {
           var character = new Character
           {
            CharacterName = characterRequestDto.CharacterName,
            CharacterPosterPath = characterRequestDto.CharacterPosterPath,
            AnimeId = characterRequestDto.AnimeId
           };
           _dbContext.Characters.Add(character);

           await _dbContext.SaveChangesAsync();
        }
    }
}
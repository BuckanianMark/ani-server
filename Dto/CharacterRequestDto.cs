using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ani_server.Dto
{
    public class CharacterRequestDto
    {
     public int CharacterId { get; set; }   
     public string CharacterName { get; set; }   
     public string CharacterPosterPath { get; set; }   
     public int AnimeId {get;set;}
    }
}
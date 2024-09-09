using System.ComponentModel.DataAnnotations;

namespace ani_server.Models
{
    public class Character
    {
    [Key]
     public int CharacterId { get; set; }   
     public string CharacterName { get; set; }   
     public string CharacterPosterPath { get; set; }   
    public int AnimeId {get;set;}
    public Anime Anime {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ani_server.Models
{
    public class Anime
    {
        [Key]
        public int AnimeId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
         public string Overview { get; set; }

        public List<Character> Characters { get; set; } =new List<Character>();

        public string PosterPath { get; set; }
    }
}
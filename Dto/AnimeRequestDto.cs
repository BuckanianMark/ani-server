using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ani_server.Dto
{
    public class AnimeRequestDto
    {

        [Key]
        public int AnimeId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Overview { get; set; }
        public string PreviewUrl { get; set; }
        public int Duration { get; set; }
        public string PosterPath { get; set; }
    }
}
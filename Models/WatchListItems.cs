using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ani_server.Models
{
    public class WatchListItems
    {
    [Key]
    public int WatchlistItemId { get; set; }

    public int MovieId { get; set; }   
    }
}
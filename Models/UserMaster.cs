

using System.ComponentModel.DataAnnotations;

namespace ani_server.Models
{
    public class UserMaster
    {
     [Key]
     public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public List<WatchListItems> WatchListItems = new List<WatchListItems>();
    }
}
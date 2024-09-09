
using ani_server.Dto;
using ani_server.Models;

namespace ani_server.Interfaces
{
    public interface ICharacter
    {
        Task AddCharacter(CharacterRequestDto character);
    }
}
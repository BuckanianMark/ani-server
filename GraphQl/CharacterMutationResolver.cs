

using ani_server.Dto;
using ani_server.Interfaces;

namespace ani_server.GraphQl
{
    [ExtendObjectType(typeof(AnimeMutationResolver))]
    public class CharacterMutationResolver
    {
        public record AddCharacterPayload(CharacterRequestDto character);
        private readonly ICharacter _characterService;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _hostEnviroment;
        readonly string posterFolderPath = string.Empty;
        public CharacterMutationResolver(
        ICharacter characterService,
       IConfiguration config,
       IWebHostEnvironment hostEnvironment)
       {
        _characterService = characterService;
        _config = config;
        _hostEnviroment = hostEnvironment;
         posterFolderPath = System.IO.Path.Combine(_hostEnviroment.WebRootPath, "Poster");
       }
       [GraphQLDescription("Add character data")]
       public AddCharacterPayload AddCharacter(CharacterRequestDto character)
       {
           
             if (string.IsNullOrEmpty(character.CharacterPosterPath))
            {
                throw new ArgumentException("Character poster path is required.");
            }
             character.CharacterPosterPath = WriteImageToServer(character);
            _characterService.AddCharacter(character);
            return new AddCharacterPayload(character);
       }
       string WriteImageToServer(CharacterRequestDto character)
       {
        string fileName = Guid.NewGuid() +".jpg";
            string fullPath = System.IO.Path.Combine(posterFolderPath,fileName);
            byte[] imageBytes = Convert.FromBase64String(character.CharacterPosterPath);
            File.WriteAllBytes(fullPath,imageBytes);

            return fileName;
       }
    }
}


using ani_server.Dto;
using ani_server.Interfaces;
using ani_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ani_server.GraphQl
{
    public class UserMutationResolver
    {
        public readonly IUser _userservice;
        public UserMutationResolver(IUser userservice)
        {
            _userservice = userservice;
        }
        [GraphQLDescription("Register a user")]
        public async Task<RegistrationResponse>  RegisterUser([FromBody]RegisterRequestDto registerRequestDto){
                UserMaster user = new(){
                    FirstName = registerRequestDto.FirstName,
                    LastName = registerRequestDto.LastName,
                    Username = registerRequestDto.Username,
                    Password = registerRequestDto.Password
                };
                bool userRegistrationStatus = await _userservice.RegisterUser(user);
            if(userRegistrationStatus){
                return new RegistrationResponse {IsRegistrationSuccess = true };
            }
            else{
                return new RegistrationResponse {IsRegistrationSuccess = false,ErrorMessage = "This username is not available." };
            }
        }
    }
}
﻿using DogQuiz.Server.Dtos;

namespace DogQuiz.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto);
        Task<UserDto> UpdateUserAsync(int userId, UserUpdateDto userUpdateDto);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> AuthenticateUserAsync(string username, string password);
    }
}

using Domain.Models;
using Domain.Response;

namespace Infrastructure.Services.UserServices;

public interface IUserService
{
    Task<Responses<List<User>>> GetUsersAsync();
    Task<Responses<User>> GetUserByIdAsync(int id);
    Task<Responses<string>> AddUserAsync(User user);
    Task<Responses<string>> UpdateUserAsync(User user);
    Task<Responses<bool>> DeleteUserAsync(int id);

}

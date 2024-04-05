using Domain.Models;
using Domain.Response;

namespace Infrastructure.Services.PostServices;

public interface IPostService
{
    Task<Responses<List<Post>>> GetPostsAsync();
    Task<Responses<Post>> GetPostByIdAsync( int id);
    Task<Responses<string>> AddPostAsync(Post post);
    Task<Responses<string>> UpdatePostAsync(Post post);
    Task<Responses<bool>> DeletePostAsync(int id);
}

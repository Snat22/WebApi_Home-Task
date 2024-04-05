using Domain.Models;
using Domain.Response;

namespace Infrastructure.Services.RelationsServices;

public interface IPostCategoryService
{
    
    Task<Responses<List<PostCategory>>> GetPostCategoryAsync();
    Task<Responses<PostCategory>> GetPostCategoryByIdAsync( int id);
    Task<Responses<string>> AddPostCategoryAsync(PostCategory post);
    Task<Responses<string>> UpdatePostCategoryAsync(PostCategory post);
    Task<Responses<bool>> DeletePostCategoryAsync(int id);
}

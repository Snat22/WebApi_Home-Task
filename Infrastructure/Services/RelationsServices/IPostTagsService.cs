using Domain.Models;
using Domain.Response;

namespace Infrastructure.Services.RelationsServices;

public interface IPostTagsService
{
    Task<Responses<List<PostTag>>> GetPostTagsAsync();
    
    Task<Responses<PostTag>> GetPostTagsByIdAsync(int id);

    Task<Responses<string>> AddPostTagsAsync(PostTag add);
    Task<Responses<string>> UpdatePostTagsAsync(PostTag upd);
    Task<Responses<bool>> DeletePostTagsAsync(int id);
    
    
    
}

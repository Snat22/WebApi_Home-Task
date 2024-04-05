using Domain.Models;
using Domain.Response;

namespace Infrastructure.Services.Meta;

public interface IPostMetaService
{
    Task<Responses<List<PostMeta>>> GetPostsMetaAsync();
    
    Task<Responses<PostMeta>> GetPostMetaByIdAsync(int id);
    
    Task<Responses<string>> AddPostsMetaAsync(PostMeta add);
    
    Task<Responses<string>> UpdatePostsMetaAsync(PostMeta upd);
    
    Task<Responses<bool>> DeletePostsMetaAsync(int id);
}

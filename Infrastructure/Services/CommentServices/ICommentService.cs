using Domain.Models;
using Domain.Response;

namespace Infrastructure.Services.CommentServices;

public interface ICommentService
{
    Task<Responses <List<PostComment>>> GetCommentsAsync();
    Task<Responses<PostComment>> GetCommentByIdAsync(int id);
    Task<Responses<string>> AddCommentsAsync(PostComment comment);
    Task<Responses<string>> UpdatedCommentAsync(PostComment comment);
    Task<Responses<bool>> DeleteCommentsAsync(int id);
}

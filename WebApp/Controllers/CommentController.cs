using Domain.Models;
using Domain.Response;
using Infrastructure.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Comments")]
[ApiController]
public class CommentController(ICommentService commentService) : ControllerBase
{
    private readonly ICommentService _commentService = commentService;
    
    
    [HttpGet]
    public async Task<Responses<List<PostComment>>> GetComments()
    {
        return await _commentService.GetCommentsAsync();
    }
    
    [HttpGet("PostCommentId:int")]
    public async Task<Responses<PostComment>> GetComentsById(int PostCommentId)
    {
        return await _commentService.GetCommentByIdAsync(PostCommentId);
    }

    
    [HttpPost]
    public async Task<Responses<string>> AddComments(PostComment add)
    {
        return await _commentService.AddCommentsAsync(add);
    }

    
    [HttpPut]
    public async Task<Responses<string>> UpdateComments( PostComment upd)
    {
        return await _commentService.UpdatedCommentAsync(upd);
    }

    
    [HttpDelete("{PostCommentId:int}")]
    public async Task<Responses<bool>> DeletePostComment(int PostCommentId)
    {
        return await _commentService.DeleteCommentsAsync(PostCommentId);
    }

    
    
}

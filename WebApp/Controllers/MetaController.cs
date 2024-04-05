using Domain.Models;
using Domain.Response;
using Infrastructure.Services.Meta;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Meta")]
[ApiController]
public class MetaController(IPostMetaService postMetaService) :ControllerBase
{
    private readonly IPostMetaService _postMetaService = postMetaService;
    
    [HttpGet]
    public async Task<Responses<List<PostMeta>>> GetMetas()
    {
        return await _postMetaService.GetPostsMetaAsync();
    }
    
    [HttpGet("metasId:int")]
    public async Task<Responses<PostMeta>> GetMetasById(int metasId)
    {
        return await _postMetaService.GetPostMetaByIdAsync(metasId);
    }

    
    [HttpPost]
    public async Task<Responses<string>> AddMetas(PostMeta add)
    {
        return await _postMetaService.AddPostsMetaAsync(add);
    }

    
    [HttpPut]
    public async Task<Responses<string>> UpdateMetas(PostMeta upd)
    {
        return await _postMetaService.UpdatePostsMetaAsync(upd);
    }

    
    [HttpDelete("{MetasyId:int}")]
    public async Task<Responses<bool>> DeleteMetas(int MetasyId)
    {
        return await _postMetaService.DeletePostsMetaAsync(MetasyId);
    }

}
